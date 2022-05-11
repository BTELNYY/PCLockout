using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
#nullable disable
namespace PCLockout
{
    internal class Registry
    {
        public static string ReturnValue(RegistryKey key, string name)
        {
            //returns the value of a key
            try
            {

                string result = key.GetValue(name).ToString();
                Log.WriteDebug("Getting data for " + name);
                return result;
            }
            catch (Exception e)
            {
                //returns error as string
                Log.WriteError("Failed during registry operation: " + e.ToString());
                return e.ToString();
            }
        }
        public static string EditValue(RegistryKey key, int value, string name)
        {
            //edits the value of a key
            try
            {
                key.SetValue(name, value);
                Log.WriteDebug("Set value for key " + name + " to " + value.ToString());
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                Log.WriteError("Failed edit: " + e.ToString());
                return e.ToString();
            }
        }
        public static string CreateValue(RegistryKey key, int value, string name)
        {
            //creates a key
            try
            {
                key.SetValue(name, value);
                Log.WriteDebug("Created a new registry value: " + name);
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                return e.ToString();
            }
        }
        public static string Delete(RegistryKey key, string name)
        {
            //creates a key
            try
            {
                key.DeleteValue(name);
                Log.WriteDebug("Deleted registry value " + name);
                return "succeeded";
            }
            catch (Exception e)
            {
                //returns error as string
                Log.WriteError("Failure during registry operation: " + e.ToString());
                return e.ToString();
            }
        }
    }
}
