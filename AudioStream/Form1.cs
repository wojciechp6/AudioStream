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
        BufferedWaveProvider waveProvider;
        MMDeviceCollection devices = new MMDeviceEnumerator().EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

        public Form1()
        {
            InitializeComponent();
            IPLabel.Text += Server.LocalIPAddress();

            Server.SearchForLocalReceivers(1000, list =>
                Invoke((MethodInvoker)delegate ()
                {
                    var l = list.ToArray();
                    IpChooseBox.Items.AddRange(l);
                    if (l.Length > 0)
                        IpChooseBox.SelectedIndex = 0;
                }));

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

            Server server = Server.StartListening(int.Parse(receivePortBox.Text));
            WaveOutEvent waveOut = new WaveOutEvent();
            waveOut.DeviceNumber = OutDevice.SelectedIndex;
            waveProvider = new BufferedWaveProvider(new WasapiLoopbackCapture().WaveFormat);

            waveOut.Init(waveProvider);
            waveOut.Play();

            void onDataFunc(byte[] data, int bytesCount) { waveProvider.AddSamples(data, 0, bytesCount); Console.WriteLine(bytesCount); }
            server.OnDataReceived += onDataFunc;
            FormClosed += (s, args) => server.OnDataReceived -= onDataFunc;
        }

        private void TransmitButton_Click(object sender, EventArgs e)
        {
            Server client = Server.Connect((IpChooseBox.SelectedValue as System.Net.IPAddress).GetAddressBytes(), 1000);
            loopbackCapture = new WasapiLoopbackCapture(devices[InDevice.SelectedIndex]);

            loopbackCapture.StartRecording();

            void onCapturedFunc(object s, WaveInEventArgs args) => client.Send(args.Buffer, args.BytesRecorded);
            loopbackCapture.DataAvailable += onCapturedFunc;
            FormClosed += (s, args) => loopbackCapture.DataAvailable -= onCapturedFunc;
        }
    }
}
