using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fiddler;

namespace HttpClientCode
{
    public partial class FrmGenerateHttpClientCode : Form
    {
        private string MESSAGEBOXTEXT = "HttpClientCode";

        public FrmGenerateHttpClientCode()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.rtbCode.Text = text;
        }
        


        private void btnCopyToClipBoard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(rtbCode.Text);
            MessageBox.Show("Text Copied to ClipBoard", this.MESSAGEBOXTEXT, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
