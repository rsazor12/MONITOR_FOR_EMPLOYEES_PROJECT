using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesMonitor
{
    public partial class Controller
    {
        private static readonly Controller controllerInstance = new Controller();

        public MainForm MainForm { get; set; }
        public LoginForm LoginForm { get; set; }

        EmployeesMonitor.Lib.DataBase.SqlConnector connector;
        EmployeesMonitor.Lib.Model.User user;

        static Controller()
        {
        }

        private Controller()
        {
            Initialize();
        }

        public static Controller Instance
        {
            get
            {
                return controllerInstance;
            }
        }

        void Initialize()
        {
            user = new EmployeesMonitor.Lib.Model.User();
            connector = new EmployeesMonitor.Lib.DataBase.SqlConnector();
        }

        public void ShowMainForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            MainForm = new MainForm();

            if (user.UserRole == EmployeesMonitor.Lib.Model.Role.Admin)
            {

            }
            else
            {

            }
          //  MainForm.UsersManagerToolStripMenuItem.Visible = user != null && user.Role == Role.Admin;
          //  MainForm.NameLabel.Text += " " + user.Login + " !";

            MainForm.Show();
            LoginForm.Hide();
        }

        public async Task LoginToApp(string login, string pass)
        {
            try
            {
                //SqlConnector connector = new SqlConnector();
                //User user = await connector.FindUser(login, pass);

                user = await connector.FindUser(login, pass);

                if (user != null)
                {
                    ShowMainForm();
                }
                else
                {
                    MessageBox.Show("Incorrect Login or Password!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
