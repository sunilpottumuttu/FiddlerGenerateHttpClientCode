using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fiddler;

namespace HttpClientCode
{
    public partial class GenerateHttpClientCodeView : UserControl
    {

        private Session[] __sessions;

        public GenerateHttpClientCodeView()
        {
            InitializeComponent();
            this.rtbCode.AllowDrop = true;
            this.__sessions = new Session[0];
            this.rtbCode.DragEnter += new DragEventHandler(rtbCode_DragEnter);
            this.rtbCode.DragDrop += new DragEventHandler(rtbCode_DragDrop);
            this.rtbCode.DragOver += new DragEventHandler(rtbCode_DragOver);
            
        }

        void rtbCode_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent("Fiddler.Session[]") ? DragDropEffects.Copy : DragDropEffects.None);
        }
        
        void rtbCode_DragDrop(object sender, DragEventArgs e)
        {
            Session[] data = (Session[])e.Data.GetData("Fiddler.Session[]");
            if (data == null || (int)data.Length < 1)
            {
                return;
            }
            this.SetSessions(data);
        }

        void rtbCode_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = (e.Data.GetDataPresent("Fiddler.Session[]") ? DragDropEffects.Copy : DragDropEffects.None);
        }

        


        public bool SetSessions(Session[] sessions)
        {
            string str;
            SessionsProperties sessionsProperties = Utility.GetSessionsProperties(sessions);
            if (!sessionsProperties.AreOnlyHTTP)
            {
                MessageBox.Show("Only HTTP and HTTPS requests are supported.", "Not Supported", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            
            int length = (int)sessions.Length;
            if (length >= 10000 && MessageBox.Show(string.Concat("Processing more than ", 10000, " records may take a few seconds or more. Do you want to continue?"), "Continue", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return false;
            }
            //this.__sessions = sessions;
            //this._codeIsAboutToChangeText = true;
            //this.rtbCode.Clear();
            //FiddlerApplication.UI.sbpInfo.Text = string.Concat("Codifying ", length, " sessions");
            //if (!this._generator.TryGenerateCode(this.__sessions, out str))
            //{
            //    FiddlerApplication.UI.sbpInfo.Text = "Error: Could not codify sessions.";
            //    return false;
            //}
            //this._codeIsAboutToChangeText = true;
            //this.rtbCode.Text = str;
            //if (!sessionsProperties.ContainsCONNECT)
            //{
            //    this.HideNotification(true);
            //}
            //else if (!FiddlerApplication.Prefs.GetBoolPref("r2c.UI.ConnectsNotGenerated", false))
            //{
            //    this.ShowNotification("CONNECT requests are not generated.", true);
            //    this._onNotificationGotIt = () => FiddlerApplication.Prefs.SetBoolPref("r2c.UI.ConnectsNotGenerated", true);
            //}
            //FiddlerApplication.UI.sbpInfo.Text = string.Concat("Codified ", length, " sessions");
            return true;
        }


    }
}
