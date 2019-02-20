using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegCleanup
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DeleteKeyValues(@"Software\Microsoft\Office\16.0\Outlook\Resiliency\CrashingAddinList");
                DeleteKeyValues(@"Software\Microsoft\Office\16.0\Outlook\Resiliency\DisabledItems");
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.ToString());
            }
            Console.Write("Press any key to continue... ");

            try
            {
                Console.ReadKey();
            }
            catch (Exception)
            {
                // Do nothing
            }
        }

        private static void DeleteKeyValues(string keyName)
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                Console.WriteLine("Inspecting HKCU\\" + keyName);
                if (key == null)
                {
                    throw new InvalidOperationException("Registry key not found: " + keyName);
                }
                else
                {
                    var valueNames = key.GetValueNames();

                    if (valueNames.Length == 0)
                    {
                        Console.WriteLine("Found no values under this key");
                        return; // nothinbg to do
                    }

                    for (var xx = 0; xx < valueNames.Length; xx++)
                    {
                        Console.WriteLine("Deleting " + valueNames[xx]);
                        key.DeleteValue(valueNames[xx]);
                    }
                }
            }
        }
    }
}
