using EmployeesMonitor.Lib;
using EmployeesMonitor.Lib.DataBase;
using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor.File;
using EmployeesMonitor.Lib.Monitor.Mouse;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeesMonitor
{
    public partial class Controller
    {
        private static readonly Controller controllerInstance = new Controller();

        public MainForm MainForm { get; set; }
        public LoginForm LoginForm { get; set; }

        public SqlConnector Connector { get; set; }
        public User User { get; set; }
        public MonitorManager MonitorManager { get; set; }

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

            MonitorManager.RegisterMonitor(new FileMonitor());
            MonitorManager.RegisterMonitor(new MouseMonitor());
        }

        public void ShowMainForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            MainForm = new MainForm();

            MainForm.Show();
            LoginForm.Hide();
        }

        public async Task LoginToApp(string login, string pass)
        {
            try
            {
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
