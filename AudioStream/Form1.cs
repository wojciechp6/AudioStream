using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;

namespace AudioStream
{
    public partial class Form1 : Form
    {
        WasapiLoopbackCapture loopbackCapture = new WasapiLoopbackCapture();
        BufferedWaveProvider waveProvider;

        public Form1()
        {
            InitializeComponent();
            IPLabel.Text += Server.LocalIPAddress();

            Server.SearchForLocalReceivers(1000, list => list.ForEach(x => Console.WriteLine(x)));
        }

        private void ReceiveButton_Click(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;
            Server server = Server.StartListening(int.Parse(receivePortBox.Text));
            WaveOutEvent waveOut = new WaveOutEvent();
            waveProvider = new BufferedWaveProvider(loopbackCapture.WaveFormat);

            waveOut.Init(waveProvider);
            waveOut.Play();

            void onDataFunc(byte[] data, int bytesCount) { waveProvider.AddSamples(data, 0, bytesCount); Console.WriteLine(bytesCount); }
            server.OnDataReceived += onDataFunc;
            FormClosed += (s, args) => server.OnDataReceived -= onDataFunc;
        }

        private void TransmitButton_Click(object sender, EventArgs e)
        {
            Server client = Server.Connect(IPBox.Text.Split('.').ParseByte().ToArray(), 1000);

            loopbackCapture.StartRecording();

            void onCapturedFunc (object s, WaveInEventArgs args) => client.Send(args.Buffer, args.BytesRecorded);
            loopbackCapture.DataAvailable += onCapturedFunc;
            FormClosed += (s, args) => loopbackCapture.DataAvailable -= onCapturedFunc;
        }


    }
}
