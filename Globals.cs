using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace PCLockout
{
    internal class Globals
    {
        public static readonly string[] args = Environment.GetCommandLineArgs();
        public static readonly string Version = "1.0.0";
        public static string LogPath { get; private set; }
        public static string ExplorerAutoRestartDisabled { get; private set; }
        public static string Password { get; private set; }
        public static string FirstRun { get; private set; }
        public static string RegistryVersion { get; private set; }
        public static string[] ApplicationKillList = { };

        static readonly string[] DefaultKillList = { "Discord", "steam", "spotify", "vlc", "chrome", "firefox", "edge", "opera", "safari", "iexplore", "taskmgr", "Command Prompt", "powershell", "Minecraft Launcher" , "Java SE Binary" };
        public static void ApplyConfig()
        {
            string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string AppDataPath = AppData + "\\btelnyy\\PCLockout\\";
            LogPath = Config.GetValue("LogPath", AppDataPath + "\\Logs\\");
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
            ExplorerAutoRestartDisabled = Config.GetValue("ExplorerAutoRestartDisabled", "false");
            //not the most secure, but it works.
            Password = Config.GetValue("Password", "ExamplePassword");
            FirstRun = Config.GetValue("FirstRun", "false");
            RegistryVersion = Config.GetValue("RegistryVersion", Version);
            if (!File.Exists(AppDataPath + "app_kill_list.txt"))
            {
                foreach (string app in DefaultKillList)
                {
                    StreamWriter sw = new(AppDataPath + "app_kill_list.txt", append: true);
                    sw.WriteLine(app);
                    sw.Close();
                }
            }
            StreamReader sr = new StreamReader(AppDataPath + "app_kill_list.txt");
            string temp = sr.ReadToEnd();
            ApplicationKillList = temp.Split('\n');
            sr.Close();
            foreach (string app in ApplicationKillList)
            {
                Log.WriteInfo("Loading app kill list: " + app);
            }
        }
    }
}
