using System.Diagnostics;
namespace PCLockout.Forms
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if(PasswordEnterBox.Text != Globals.Password)
            {
                Attempt a = new();
                a.wrongpassword = PasswordEnterBox.Text;
                a.time = DateTime.Now;
                a.resetattempted = false;
                Log.WriteAttempt(a);
                Utility.WriteInfo("Incorrect password, try again.", "Info");
            }
            else
            {
                Process.Start("explorer.exe");
                Environment.Exit(0);
            }
        }
        void MyForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Log.WriteInfo("Locked out! the user decided to close the form.");
            Utility.Lockout();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            Log.WriteInfo("Locked out! the user clicked cancel");
            Utility.Lockout();
        }

        private void ChangePW_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword changePW = new();
            changePW.Show();
        }
    }
}