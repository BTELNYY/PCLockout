using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCLockout.Forms
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (Globals.Password != textBox1.Text)
            {
                Utility.WriteError("Password is incorrect", "Error: Unable to change password");
                Attempt a = new();
                a.wrongpassword = textBox1.Text;
                a.time = DateTime.Now;
                a.resetattempted = true;
                Log.WriteAttempt(a);
                return;
            }
            Log.WriteInfo("Changing Password!");
            Config.SetValue("Password", textBox2.Text);
            Utility.WriteInfo("Password changed", "Info");
            Globals.ApplyConfig();
            Close();
        }
    }
}
