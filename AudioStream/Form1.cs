using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace AudioStream
{
    public partial class Form1 : Form
    {
        WasapiLoopbackCapture loopbackCapture;
        BufferedWaveProvider waveOutProvider;
        WaveOutEvent waveOut;

        MMDeviceCollection devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

        public Form1()
        {
            InitializeComponent();
            IPLabel.Text = Server.LocalIPAddress().ToString();

            IpChooseBox.Items.Add("Custom");
            IpChooseBox.SelectedIndex = 0;
            UpdateReceivers(true);

            IpChooseBox.Click += (s, args) => UpdateReceivers();

            for (int i = 0; i < WaveOut.DeviceCount; i++)
            {
                OutDevice.Items.Add(WaveOut.GetCapabilities(i).ProductName);
                InDevice.Items.Add(devices[i].FriendlyName);
            }
            OutDevice.SelectedIndex = 0;
            InDevice.SelectedIndex = 0;

        }

        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            (sender as Button).Text = "Stop receiving";
            OutDevice.Enabled = false;

            Server server = Server.StartListening(int.Parse(portBox.Text));
            waveOut = new WaveOutEvent();
            waveOut.DeviceNumber = OutDevice.SelectedIndex;
            waveOutProvider = new BufferedWaveProvider(new WasapiLoopbackCapture().WaveFormat);

            waveOut.Init(waveOutProvider);
            waveOut.Volume = RxVolume.Volume;
            waveOut.Play();

            void volumeChanged(object s, EventArgs args) => waveOut.Volume = RxVolume.Volume;
            RxVolume.VolumeChanged += volumeChanged;

            void onDataFunc(byte[] data, int bytesCount) { waveOutProvider.AddSamples(data, 0, bytesCount); Console.WriteLine(bytesCount); }
            server.OnDataReceived += onDataFunc;
            FormClosed += (s, args) =>
            {
                server.OnDataReceived -= onDataFunc;
                RxVolume.VolumeChanged -= volumeChanged;
                server.Close();
            };
        }

        private void TransmitButton_Click(object sender, EventArgs e)
        {
            byte[] addr = (IpChooseBox.SelectedItem as System.Net.IPAddress)?.GetAddressBytes();

            if (addr == null)
            {
                addr = new CustomIPForm().GetIP();
                if (addr == null)
                {
                    MessageBox.Show("Select remote IP!");
                    return;
                }
                else
                {
                    IpChooseBox.SelectedItem = null;
                    IpChooseBox.SelectedText = string.Join(".", addr);
                }
            }
            Server client = Server.Connect(addr, int.Parse(portBox.Text));
            loopbackCapture = new WasapiLoopbackCapture(devices[InDevice.SelectedIndex]);

            void onCapturedFunc(object s, WaveInEventArgs args) =>
                client.Send(AdjustVolume(args.Buffer, TxVolume.Volume), args.BytesRecorded);
            loopbackCapture.DataAvailable += onCapturedFunc;
            loopbackCapture.StartRecording();

            FormClosed += (s, args) =>
            {
                loopbackCapture.StopRecording();
                loopbackCapture.DataAvailable -= onCapturedFunc;
                loopbackCapture.Dispose();
                client.Close();
            };
        }

        private void UpdateReceivers(bool resetIndex = false)
        {
            Server.SearchForLocalReceivers(int.Parse(portBox.Text), list =>
                Invoke((MethodInvoker)delegate ()
                {
                    IpChooseBox.Items.Clear();
                    IpChooseBox.Items.AddRange(list.ToArray());
                    IpChooseBox.Items.Add("Custom");
                    if (resetIndex)
                        IpChooseBox.SelectedIndex = 0;
                }));
        }

        private byte[] AdjustVolume(byte[] audioSamples, float volume)
        {
            byte[] array = new byte[audioSamples.Length];
            for (int i = 0; i < array.Length; i += 2)
            {
                // convert byte pair to int
                short audioSample = (short)(((audioSamples[i + 1] & 0xff) << 8) | (audioSamples[i] & 0xff));

                audioSample = (short)(audioSample * volume);

                // convert back
                array[i] = (byte)audioSample;
                array[i + 1] = (byte)(audioSample >> 8);

            }
            return array;
        }
    }
}
