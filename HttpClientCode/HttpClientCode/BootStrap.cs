using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fiddler;
using System.Windows.Forms;
using System.Dynamic;

namespace HttpClientCode
{
    public class BootStrap: IHandleExecAction, IFiddlerExtension
    {

        private MenuItem __menuItem;
        private Session __selectedSession;
        private FrmGenerateHttpClientCode __frm;
        private string MESSAGEBOXTEXT = "HttpClientCode";

        public BootStrap()
		{
		}


        public void OnLoad()
        {
            this.__menuItem = new MenuItem("Generate Http Client Code");
            FiddlerApplication.UI.lvSessions.ContextMenu.MenuItems.Add(this.__menuItem);
            this.__menuItem.Click += new EventHandler(__menuItem_Click);
        }

        string CanHandle()
        {
            if (this.__selectedSession.isTunnel)
            {
                return "This Not a HTTP/HTTPS Request..Please Choose HTTP/HTTPS Request";
            }
            if (this.__selectedSession.isFTP)
            {
                return "This is a FTP Request...Please Choose HTTP/HTTPS Request";
            }
            return string.Empty;
        }


        void __menuItem_Click(object sender, EventArgs e)
        {
            if (FiddlerApplication.UI.lvSessions.SelectedItems.Count == 1)
            {
                this.__selectedSession = FiddlerApplication.UI.GetFirstSelectedSession();

                var result = this.CanHandle();

                if (result == string.Empty)//Check whether this can handle or not
                {
                    string text = this.GenerateHttpClientCode();

                    this.__frm = new FrmGenerateHttpClientCode();
                    this.__frm.SetText(text);
                    this.__frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show(result, this.MESSAGEBOXTEXT, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Select Only One Session", this.MESSAGEBOXTEXT, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return ;
            }
        }


        public string GenerateHttpClientCode()
        {
            var template = new GenerateCode();
            //template.Session = new Dictionary<string, object>(){ { "SelectedSession",this.__selectedSession }};
            template.Session = new Dictionary<string, object>();
            
            template.Session.Add("uri", this.__selectedSession.fullUrl);
            template.Session.Add("host", this.__selectedSession.host);
            template.Session.Add("httpmethod", this.__selectedSession.RequestMethod);

            #region Add HttpHeaders
            var headers = new Dictionary<string, string>();
            foreach (var item in this.__selectedSession.oRequest.headers)
            {
                headers.Add(item.Name, item.Value);
            } 
            #endregion
                
            template.Session.Add("headers", headers);
            
            
            
            template.Initialize();
            var generatedCode = template.TransformText();
            return generatedCode;
        }


        public bool OnExecAction(string sCommand)
        {
            return true;
        }

		public void OnBeforeUnload()
		{
            this.__frm.Dispose();
		}
     
    }
}
