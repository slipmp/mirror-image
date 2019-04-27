namespace MirrorImage.App
{
    partial class frmMain
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
            this.picInput = new System.Windows.Forms.PictureBox();
            this.picOutput = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbImages = new System.Windows.Forms.GroupBox();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.btnMirror = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).BeginInit();
            this.grbImages.SuspendLayout();
            this.SuspendLayout();
            // 
            // picInput
            // 
            this.picInput.Location = new System.Drawing.Point(6, 51);
            this.picInput.Name = "picInput";
            this.picInput.Size = new System.Drawing.Size(300, 200);
            this.picInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picInput.TabIndex = 0;
            this.picInput.TabStop = false;
            // 
            // picOutput
            // 
            this.picOutput.Location = new System.Drawing.Point(6, 284);
            this.picOutput.Name = "picOutput";
            this.picOutput.Size = new System.Drawing.Size(300, 200);
            this.picOutput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOutput.TabIndex = 1;
            this.picOutput.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input";
            // 
            // grbImages
            // 
            this.grbImages.Controls.Add(this.txtResults);
            this.grbImages.Controls.Add(this.label3);
            this.grbImages.Controls.Add(this.txtDetails);
            this.grbImages.Controls.Add(this.btnMirror);
            this.grbImages.Controls.Add(this.label2);
            this.grbImages.Controls.Add(this.picInput);
            this.grbImages.Controls.Add(this.label1);
            this.grbImages.Controls.Add(this.picOutput);
            this.grbImages.Location = new System.Drawing.Point(12, 12);
            this.grbImages.Name = "grbImages";
            this.grbImages.Size = new System.Drawing.Size(647, 500);
            this.grbImages.TabIndex = 3;
            this.grbImages.TabStop = false;
            this.grbImages.Text = "Images";
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(312, 321);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.Size = new System.Drawing.Size(316, 163);
            this.txtResults.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Image details";
            // 
            // txtDetails
            // 
            this.txtDetails.Location = new System.Drawing.Point(312, 51);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.Size = new System.Drawing.Size(316, 200);
            this.txtDetails.TabIndex = 5;
            // 
            // btnMirror
            // 
            this.btnMirror.Location = new System.Drawing.Point(312, 284);
            this.btnMirror.Name = "btnMirror";
            this.btnMirror.Size = new System.Drawing.Size(316, 31);
            this.btnMirror.TabIndex = 4;
            this.btnMirror.Text = "Press to Mirror Image";
            this.btnMirror.UseVisualStyleBackColor = true;
            this.btnMirror.Click += new System.EventHandler(this.btnMirror_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Results";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 535);
            this.Controls.Add(this.grbImages);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Mirror Image application";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOutput)).EndInit();
            this.grbImages.ResumeLayout(false);
            this.grbImages.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picInput;
        private System.Windows.Forms.PictureBox picOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbImages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Button btnMirror;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtResults;
    }
}

