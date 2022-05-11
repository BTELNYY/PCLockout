using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
#nullable disable
namespace PCLockout
{
    internal class Config
    {
        private static string ProjectName = "PCLockout";
        public static string GetValue(string name, string defaultvalue)
        {

            //checks if a value with that name exists, if no, make a new one with a default value
            RegistryKey reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\btelnyy\" + ProjectName, true);
            if (reg == null)
            {
                //creates a key if the key does not exist already.
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\btelnyy\" + ProjectName, true);
                reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\btelnyy\" + ProjectName, true);
            }
            if (!reg.GetValueNames().Contains(name))
            {
                reg.SetValue(name, defaultvalue);
                return defaultvalue;
            }
            else
            {
                if (reg.GetValue(name).ToString() == null)
                {
                    return defaultvalue;
                }
                else
                {
                    return reg.GetValue(name).ToString();
                }
            }
        }
        public static void SetValue(string name, string value)
        {
            //sets a config value
            RegistryKey reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\btelnyy\" + ProjectName, true);
            if (reg == null)
            {
                //creates a key if the key does not exist already.
                Microsoft.Win32.Registry.CurrentUser.CreateSubKey(@"SOFTWARE\btelnyy\" + ProjectName, true);
            }
            reg.SetValue(name, value);
        }
        public static void DeleteAll()
        {
            //deletes everything from the registry regarding this application, used for uninstalls
            RegistryKey reg = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\btelnyy\", true);
            reg.DeleteSubKey(ProjectName);
        }
    }
}