namespace AudioStream
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ReceiveButton = new System.Windows.Forms.Button();
            this.TransmitButton = new System.Windows.Forms.Button();
            this.portBox = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.InDevice = new System.Windows.Forms.ComboBox();
            this.TxVolume = new NAudio.Gui.VolumeSlider();
            this.label1 = new System.Windows.Forms.Label();
            this.IpChooseBox = new System.Windows.Forms.ComboBox();
            this.IPL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OutDevice = new System.Windows.Forms.ComboBox();
            this.RxVolume = new NAudio.Gui.VolumeSlider();
            this.label2 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReceiveButton
            // 
            this.ReceiveButton.Location = new System.Drawing.Point(51, 71);
            this.ReceiveButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReceiveButton.Name = "ReceiveButton";
            this.ReceiveButton.Size = new System.Drawing.Size(243, 55);
            this.ReceiveButton.TabIndex = 0;
            this.ReceiveButton.Text = "Receive";
            this.ReceiveButton.UseVisualStyleBackColor = true;
            this.ReceiveButton.Click += new System.EventHandler(this.ReceiveButton_Click);
            // 
            // TransmitButton
            // 
            this.TransmitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransmitButton.Location = new System.Drawing.Point(37, 12);
            this.TransmitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TransmitButton.Name = "TransmitButton";
            this.TransmitButton.Size = new System.Drawing.Size(243, 55);
            this.TransmitButton.TabIndex = 1;
            this.TransmitButton.Text = "Transmit";
            this.TransmitButton.UseVisualStyleBackColor = true;
            this.TransmitButton.Click += new System.EventHandler(this.TransmitButton_Click);
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(272, 21);
            this.portBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(63, 22);
            this.portBox.TabIndex = 4;
            this.portBox.Text = "1005";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.InDevice);
            this.panel3.Controls.Add(this.TxVolume);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.IpChooseBox);
            this.panel3.Controls.Add(this.TransmitButton);
            this.panel3.Location = new System.Drawing.Point(12, 218);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(322, 166);
            this.panel3.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(35, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "In device: ";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Volume: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // InDevice
            // 
            this.InDevice.FormattingEnabled = true;
            this.InDevice.Location = new System.Drawing.Point(123, 128);
            this.InDevice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.InDevice.Name = "InDevice";
            this.InDevice.Size = new System.Drawing.Size(159, 24);
            this.InDevice.TabIndex = 16;
            // 
            // TxVolume
            // 
            this.TxVolume.Location = new System.Drawing.Point(123, 103);
            this.TxVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TxVolume.Name = "TxVolume";
            this.TxVolume.Size = new System.Drawing.Size(157, 18);
            this.TxVolume.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Remote IP: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // IpChooseBox
            // 
            this.IpChooseBox.CausesValidation = false;
            this.IpChooseBox.FormattingEnabled = true;
            this.IpChooseBox.Location = new System.Drawing.Point(123, 73);
            this.IpChooseBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IpChooseBox.Name = "IpChooseBox";
            this.IpChooseBox.Size = new System.Drawing.Size(159, 24);
            this.IpChooseBox.TabIndex = 4;
            // 
            // IPL
            // 
            this.IPL.AutoSize = true;
            this.IPL.Location = new System.Drawing.Point(37, 70);
            this.IPL.Name = "IPL";
            this.IPL.Size = new System.Drawing.Size(66, 17);
            this.IPL.TabIndex = 3;
            this.IPL.Text = "Local IP: ";
            this.IPL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.IPLabel);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.OutDevice);
            this.panel1.Controls.Add(this.IPL);
            this.panel1.Controls.Add(this.RxVolume);
            this.panel1.Location = new System.Drawing.Point(12, 58);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 155);
            this.panel1.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(120, 70);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 17);
            this.label8.TabIndex = 13;
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "Out device: ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Volume: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // OutDevice
            // 
            this.OutDevice.FormattingEnabled = true;
            this.OutDevice.Location = new System.Drawing.Point(123, 121);
            this.OutDevice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.OutDevice.Name = "OutDevice";
            this.OutDevice.Size = new System.Drawing.Size(159, 24);
            this.OutDevice.TabIndex = 14;
            // 
            // RxVolume
            // 
            this.RxVolume.Location = new System.Drawing.Point(123, 96);
            this.RxVolume.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.RxVolume.Name = "RxVolume";
            this.RxVolume.Size = new System.Drawing.Size(157, 18);
            this.RxVolume.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Port:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.linkLabel1.Location = new System.Drawing.Point(229, 386);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(105, 17);
            this.linkLabel1.TabIndex = 11;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "ChossenButher";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(117, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Made with 🍕 by";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(126, 70);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(84, 17);
            this.IPLabel.TabIndex = 16;
            this.IPLabel.Text = "192.168.0.2";
            this.IPLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 409);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.ReceiveButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "AudioStream";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReceiveButton;
        private System.Windows.Forms.Button TransmitButton;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox IpChooseBox;
        private System.Windows.Forms.Label IPL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox OutDevice;
        private System.Windows.Forms.Label label4;
        private NAudio.Gui.VolumeSlider TxVolume;
        private System.Windows.Forms.Label label5;
        private NAudio.Gui.VolumeSlider RxVolume;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox InDevice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label IPLabel;
    }
}

