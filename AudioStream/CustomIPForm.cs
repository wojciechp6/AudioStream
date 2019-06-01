using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AudioStream
{
    public partial class CustomIPForm : Form
    {
        public CustomIPForm()
        {
            InitializeComponent();
            AcceptButton = OkButton;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            byte[] ip = IP.Text.Split('.').ParseByte().ToArray();
            if (ip.Length == 4)
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Your IP is not IP");
        }

        public byte[] GetIP()
        {
            ShowDialog();
            byte[] ip = IP.Text.Split('.').ParseByte().ToArray();
            if (DialogResult == DialogResult.OK)
            {
                return ip;
            }
            else
            {
                return null;
            }
        }
    }
}
