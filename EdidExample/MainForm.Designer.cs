namespace EdidExample
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.deviceTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dimensionsTextBox = new System.Windows.Forms.TextBox();
            this.resolutionTextBox = new System.Windows.Forms.TextBox();
            this.dpiTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deviceTextBox
            // 
            this.deviceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deviceTextBox.Location = new System.Drawing.Point(92, 12);
            this.deviceTextBox.Name = "deviceTextBox";
            this.deviceTextBox.Size = new System.Drawing.Size(329, 20);
            this.deviceTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dimensions";
            // 
            // dimensionsTextBox
            // 
            this.dimensionsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dimensionsTextBox.Location = new System.Drawing.Point(92, 38);
            this.dimensionsTextBox.Name = "dimensionsTextBox";
            this.dimensionsTextBox.Size = new System.Drawing.Size(329, 20);
            this.dimensionsTextBox.TabIndex = 3;
            // 
            // resolutionTextBox
            // 
            this.resolutionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resolutionTextBox.Location = new System.Drawing.Point(92, 64);
            this.resolutionTextBox.Name = "resolutionTextBox";
            this.resolutionTextBox.Size = new System.Drawing.Size(329, 20);
            this.resolutionTextBox.TabIndex = 3;
            // 
            // dpiTextBox
            // 
            this.dpiTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dpiTextBox.Location = new System.Drawing.Point(92, 90);
            this.dpiTextBox.Name = "dpiTextBox";
            this.dpiTextBox.Size = new System.Drawing.Size(329, 20);
            this.dpiTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Resolution";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "DPI";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 124);
            this.Controls.Add(this.dpiTextBox);
            this.Controls.Add(this.resolutionTextBox);
            this.Controls.Add(this.dimensionsTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deviceTextBox);
            this.Name = "MainForm";
            this.Text = "EdidExample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox deviceTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dimensionsTextBox;
        private System.Windows.Forms.TextBox resolutionTextBox;
        private System.Windows.Forms.TextBox dpiTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

