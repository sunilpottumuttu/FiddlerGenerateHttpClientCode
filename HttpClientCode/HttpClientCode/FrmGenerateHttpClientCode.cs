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
        public Session SelectedSession { get; set; }

        public FrmGenerateHttpClientCode()
        {
            InitializeComponent();
        }

        
        public void GenerateHttpClientCode()
        {
            
        }

    }
}
