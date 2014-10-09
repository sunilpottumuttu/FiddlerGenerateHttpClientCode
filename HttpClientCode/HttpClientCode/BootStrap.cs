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
		private TabPage __codeTab;

		private GenerateHttpClientCodeView  __view;

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

            this.__codeTab = new TabPage("HttpClient Code");
            this.__view = new GenerateHttpClientCodeView();
            this.__codeTab.Controls.Add(this.__view);
            this.__view.Dock = DockStyle.Fill;
            FiddlerApplication.UI.tabsViews.TabPages.Add(this.__codeTab);
            
            
            //this.__codeTab.ImageKey = "requestToCodeView";
            if (!FiddlerApplication.UI.tabsViews.ShowToolTips)
            {
                

                FiddlerApplication.UI.tabsViews.ShowToolTips = true;
            }
            this.__codeTab.ToolTipText = "Drag sessions into this tab to generate C# HttpClient Code";
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
                    this.__frm = new FrmGenerateHttpClientCode();
                    this.__frm.SelectedSession = this.__selectedSession;
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

		private static bool CanHandle1(string command)
		{
            if (command == "HTTPCLIENTCODE")
            {
                return true;
            }
            return command == "HTTPCLIENTCODE";
		}

        public bool OnExecAction(string sCommand)
        {
            string[] strArrays = Utilities.Parameterize(sCommand);
            if ((int)strArrays.Length == 0 || !BootStrap.CanHandle1(strArrays[0].ToUpperInvariant()) || this.__codeTab == null || this.__view == null)
            {
                return false;
            }
            if ((int)strArrays.Length != 1)
            {
                List<Session> sessions = new List<Session>();
                Session[] allSessions = FiddlerApplication.UI.GetAllSessions();
                for (int i = 0; i < (int)allSessions.Length; i++)
                {
                    Session session = allSessions[i];
                    int num = 1;
                    while (num < (int)strArrays.Length)
                    {
                        if (!session.uriContains(strArrays[num]))
                        {
                            num++;
                        }
                        else
                        {
                            sessions.Add(session);
                            break;
                        }
                    }
                }
                if (sessions.Count != 0)
                {
                    FiddlerApplication.UI.tabsViews.SelectedTab = this.__codeTab;
                    this.__view.SetSessions(sessions.ToArray());
                }
                else
                {
                    FiddlerApplication.UI.sbpInfo.Text = "No sessions match your criteria.";
                }
            }
            else
            {
                FiddlerApplication.UI.tabsViews.SelectedTab = this.__codeTab;
            }
            return true;
        }

		public void OnBeforeUnload()
		{
			this.__codeTab.Controls.Remove(this.__view);
			FiddlerApplication.UI.pageBuilder.Controls.Remove(this.__codeTab);
		}

	

		
    }
}
