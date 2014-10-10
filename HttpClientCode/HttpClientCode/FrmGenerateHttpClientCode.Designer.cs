namespace HttpClientCode
{
    partial class FrmGenerateHttpClientCode
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
            this.rtbCode = new System.Windows.Forms.RichTextBox();
            this.btnCopyToClipBoard = new System.Windows.Forms.Button();
            this.lblDevelopedBy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbCode
            // 
            this.rtbCode.Location = new System.Drawing.Point(12, 12);
            this.rtbCode.Name = "rtbCode";
            this.rtbCode.Size = new System.Drawing.Size(818, 357);
            this.rtbCode.TabIndex = 0;
            this.rtbCode.Text = "";
            // 
            // btnCopyToClipBoard
            // 
            this.btnCopyToClipBoard.Location = new System.Drawing.Point(703, 385);
            this.btnCopyToClipBoard.Name = "btnCopyToClipBoard";
            this.btnCopyToClipBoard.Size = new System.Drawing.Size(127, 23);
            this.btnCopyToClipBoard.TabIndex = 1;
            this.btnCopyToClipBoard.Text = "Copy To ClipBoard";
            this.btnCopyToClipBoard.UseVisualStyleBackColor = true;
            this.btnCopyToClipBoard.Click += new System.EventHandler(this.btnCopyToClipBoard_Click);
            // 
            // lblDevelopedBy
            // 
            this.lblDevelopedBy.AutoSize = true;
            this.lblDevelopedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevelopedBy.Location = new System.Drawing.Point(12, 385);
            this.lblDevelopedBy.Name = "lblDevelopedBy";
            this.lblDevelopedBy.Size = new System.Drawing.Size(187, 13);
            this.lblDevelopedBy.TabIndex = 2;
            this.lblDevelopedBy.Text = "Developed By:-Sunil Pottumuttu";
            // 
            // FrmGenerateHttpClientCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 419);
            this.Controls.Add(this.lblDevelopedBy);
            this.Controls.Add(this.btnCopyToClipBoard);
            this.Controls.Add(this.rtbCode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmGenerateHttpClientCode";
            this.Text = "C# HttpClient Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbCode;
        private System.Windows.Forms.Button btnCopyToClipBoard;
        private System.Windows.Forms.Label lblDevelopedBy;
    }
}