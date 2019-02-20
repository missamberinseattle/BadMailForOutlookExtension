using Microsoft.Office.Core;
using Microsoft.Office.Interop.Outlook;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;

// TODO:  Follow these steps to enable the Ribbon (XML) item:

// 1: Copy the following code block into the ThisAddin, ThisWorkbook, or ThisDocument class.

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new ContextMenus();
//  }

// 2. Create callback methods in the "Ribbon Callbacks" region of this class to handle user
//    actions, such as clicking a button. Note: if you have exported this Ribbon from the Ribbon designer,
//    move your code from the event handlers to the callback methods and modify the code to work with the
//    Ribbon extensibility (RibbonX) programming model.

// 3. Assign attributes to the control tags in the Ribbon XML file to identify the appropriate callback methods in your code.  

// For more information, see the Ribbon XML documentation in the Visual Studio Tools for Office Help.


namespace BadMailForOutlook
{
    [ComVisible(true)]
    public class ContextMenus : IRibbonExtensibility
    {
        private IRibbonUI ribbon;

        public ContextMenus()
        {
        }

        #region IRibbonExtensibility Members

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("BadMailForOutlook.ContextMenus.xml");
        }

        #endregion

        #region Ribbon Callbacks
        //Create callback methods here. For more information about adding callback methods, visit https://go.microsoft.com/fwlink/?LinkID=271226

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        public void RibbonMenuClick(IRibbonControl control)
        {
            try
            {
                var selection = control.Context as Selection;

                var mailItems = selection.OfType<MailItem>().ToList();
                SpamLibraries patternCollections;

                MailAnalyzer.ProcessItems(mailItems, out patternCollections);
            }
            catch (System.Exception ex)
            {
                
                var errorOut = new StringBuilder();
                errorOut.AppendLine(DateTime.Now.ToString("G"));
                errorOut.AppendLine(ex.ToString());
                errorOut.AppendLine();

                BadMailAddIn.LogError(errorOut.ToString());
                

                MessageBox.Show("Encountered unhandled exception. Details have been logged to " + BadMailAddIn.LogFilePath);
            }
            Trace.WriteLine($"RibbonMenuClick control: {control} type {control?.GetType().Name ?? "(null)"}");
        }
        #endregion

        #region Helpers

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
