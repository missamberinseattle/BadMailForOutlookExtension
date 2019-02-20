using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using System;
using System.IO;

namespace BadMailForOutlook
{
    public partial class BadMailAddIn
    {
        private static NameSpace _session = null;
        private static string _mailDataPath;

        public static string LogFilePath
        {
            get
            {
                return Path.Combine(MailDataPath, "BadMailForOutlook.log");
            }
        }
        public static NameSpace Session
        {
            get
            {
                if (_session == null)
                {
                    throw new InvalidOperationException("Outlook Session not intialized");
                }

                return _session;
            }
        }

        public static string MailDataPath
        {
            get
            {
                if (_mailDataPath == null)
                {
                    _mailDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), @"Dropbox\MailData");
                }
                return _mailDataPath;
            }
        }

        protected override IRibbonExtensibility CreateRibbonExtensibilityObject()
        {
            return new ContextMenus();
        }

        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            _session = Application.Session;
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
            // Note: Outlook no longer raises this event. If you have code that 
            //    must run when Outlook shuts down, see https://go.microsoft.com/fwlink/?LinkId=506785
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        public static void LogError(string text)
        {
            var logPath = LogFilePath;
            File.AppendAllText(logPath, text);
        }

        #endregion
    }
}
