using EmployeesMonitor.Lib.DataBase;
using EmployeesMonitor.Lib.Model;
using System;
using System.Windows.Forms;

namespace EmployeesMonitor
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            Controller.Instance.LoginForm = this;
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            loginButton.Enabled = false;
            loginTextBox.Enabled = false;
            passTextBox.Enabled = false;

            Cursor.Current = Cursors.WaitCursor;
            await Controller.Instance.LoginToApp(loginTextBox.Text, passTextBox.Text);

            loginTextBox.Text = "";
            passTextBox.Text = "";

            loginTextBox.Focus();

            loginButton.Enabled = true;
            loginTextBox.Enabled = true;
            passTextBox.Enabled = true;
        }

        private void loginTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                passTextBox.Focus();
            }
        }

        private void passTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                loginButton_Click(null, null);
            }
        }
    }
}
