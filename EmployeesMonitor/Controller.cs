using EmployeesMonitor.Lib;
using EmployeesMonitor.Lib.DataBase;
using EmployeesMonitor.Lib.Model;
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

        public EmployeesMonitor.Lib.DataBase.SqlConnector Connector { get; set; }
        public EmployeesMonitor.Lib.Model.User User { get; set; }
        public EmployeesMonitor.Lib.MonitorManager MonitorManager { get; set; }

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
            User = new User();
            Connector = new EmployeesMonitor.Lib.DataBase.SqlConnector();
            MonitorManager = new EmployeesMonitor.Lib.MonitorManager(60);
        }

        public void ShowMainForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            MainForm = new MainForm();

            if (User.UserRole == EmployeesMonitor.Lib.Model.Role.Admin)
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

                User = await Connector.FindUser(login, pass);

                if (User != null)
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
