using System;
using PCLockout.Forms;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using IWshRuntimeLibrary;
#nullable disable
namespace PCLockout
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            ApplicationConfiguration.Initialize();
            try
            {
                Globals.ApplyConfig();
            }
            catch(Exception e)
            {
                Utility.WriteError("Error loading config \n \n " + e.ToString(), "Error: " + e.Message);
            }
            Log.WriteInfo("Applying config...");
            Log.WriteInfo("Starting Program + v" + Globals.Version);
            if(Globals.FirstRun == "false" || Utility.IsAdministrator())
            {
                if (!Utility.IsAdministrator())
                {
                    Utility.WriteError("You are not running as an administrator. Please run the program as an administrator. \n \n The app needs to run first run functions (auto start, etc.)", "Please run as administrator");
                    Environment.Exit(0);
                }
                else
                {
                    FirstRun();
                }
            }
            Process[] explorer = Process.GetProcessesByName("explorer");
            foreach (Process p in explorer)
            {
                p.Kill();
            }
            foreach(string app in Globals.ApplicationKillList)
            {
                Log.WriteInfo("Killing app: " + app);
                Process[] p = Process.GetProcessesByName(app);
                foreach(Process p1 in p)
                {
                    try
                    {
                        p1.Kill();
                    }catch(Exception e)
                    {
                        Log.WriteError("Failed killing app: " + app + " Error:  " + e.ToString());
                    }
                    Log.WriteInfo("Kiled app: " + p1.ProcessName);
                }
            }
            Application.Run(new PasswordForm());
        }
        static void FirstRun()
        {
            try
            {
                Log.WriteInfo("Setting up app for first run....");
                string root = Path.GetPathRoot(Environment.GetFolderPath(Environment.SpecialFolder.System));
                Directory.CreateDirectory(root + @"Program Files\btelnyy\PCLockout\");
                string path = root + @"Program Files\btelnyy\PCLockout\";
                string[] filePaths = Directory.GetFiles(@".\");
                Log.WriteInfo("Copying files to " + path);
                foreach (string file in filePaths)
                {
                    System.IO.File.Copy(file, path + Path.GetFileName(file), true);
                }
                Log.WriteInfo("Checking for explorer settings....");
                if (Globals.ExplorerAutoRestartDisabled == "false")
                {
                    try
                    {
                        Microsoft.Win32.RegistryKey ourKey = Microsoft.Win32.Registry.LocalMachine;
                        ourKey = ourKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion\Winlogon", true);
                        ourKey.SetValue("AutoRestartShell", 0);
                        Config.SetValue("ExplorerAutoRestartDisabled", "true");
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        Utility.WriteError("Access denied. Please run as administrator. \n" + ex.ToString(), "Error: " + ex.Message);
                        Environment.Exit(1);
                    }
                    catch (System.Security.SecurityException ex)
                    {
                        Utility.WriteError("Access denied. Please run as administrator. \n" + ex.ToString(), "Error: " + ex.Message);
                        Environment.Exit(1);
                    }
                }
                Utility.WriteInfo("Success! First Run has completed, the app will run when you login into this account again. \n (You can also trigger it manually by running it in Program Files\\btelnyy\\PCLockout\\PCLockout.exe)", "Done");
                string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                Log.WriteInfo("Creating Symbolic link...");
                System.IO.File.Delete(AppData + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\PCLockout.lnk");
                CreateShortcut(AppData + "\\Microsoft\\Windows\\Start Menu\\Programs\\Startup\\PCLockout.lnk", path + "PCLockout.exe");
                Config.SetValue("FirstRun", "true");
                Environment.Exit(0);
            }
            catch (Exception ex)
            {
                Utility.WriteError("Error running first run setup: \n \n " + ex.ToString(), "Error: " + ex.Message);
            }
        }
        private static void CreateShortcut(string path, string apppath)
        {
            object shDesktop = (object)"Desktop";
            WshShell shell = new WshShell();
            string shortcutAddress = path;
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutAddress);
            shortcut.TargetPath = apppath;
            shortcut.Save();
        }
    }
}