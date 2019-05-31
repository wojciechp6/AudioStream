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
            this.IPBox = new System.Windows.Forms.TextBox();
            this.IPLabel = new System.Windows.Forms.Label();
            this.receivePortBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ReceiveButton
            // 
            this.ReceiveButton.Location = new System.Drawing.Point(29, 103);
            this.ReceiveButton.Name = "ReceiveButton";
            this.ReceiveButton.Size = new System.Drawing.Size(221, 55);
            this.ReceiveButton.TabIndex = 0;
            this.ReceiveButton.Text = "Receive";
            this.ReceiveButton.UseVisualStyleBackColor = true;
            this.ReceiveButton.Click += new System.EventHandler(this.ReceiveButton_Click);
            // 
            // TransmitButton
            // 
            this.TransmitButton.Location = new System.Drawing.Point(29, 218);
            this.TransmitButton.Name = "TransmitButton";
            this.TransmitButton.Size = new System.Drawing.Size(221, 55);
            this.TransmitButton.TabIndex = 1;
            this.TransmitButton.Text = "Transmit";
            this.TransmitButton.UseVisualStyleBackColor = true;
            this.TransmitButton.Click += new System.EventHandler(this.TransmitButton_Click);
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(29, 190);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(121, 22);
            this.IPBox.TabIndex = 2;
            this.IPBox.Text = "192.168.1.70";
            // 
            // IPLabel
            // 
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(26, 83);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(28, 17);
            this.IPLabel.TabIndex = 3;
            this.IPLabel.Text = "IP: ";
            this.IPLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // receivePortBox
            // 
            this.receivePortBox.Location = new System.Drawing.Point(188, 75);
            this.receivePortBox.Name = "receivePortBox";
            this.receivePortBox.Size = new System.Drawing.Size(62, 22);
            this.receivePortBox.TabIndex = 4;
            this.receivePortBox.Text = "1000";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 353);
            this.Controls.Add(this.receivePortBox);
            this.Controls.Add(this.IPLabel);
            this.Controls.Add(this.IPBox);
            this.Controls.Add(this.TransmitButton);
            this.Controls.Add(this.ReceiveButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ReceiveButton;
        private System.Windows.Forms.Button TransmitButton;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.TextBox receivePortBox;
    }
}

