using EmployeesMonitor.Lib;
using EmployeesMonitor.Lib.DataBase;
using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor.File;
using EmployeesMonitor.Lib.Monitor.Mouse;
using EmpoleeysMonitor.Lib.Monitor.Sample;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
namespace EmployeesMonitor
{
    public class Controller
    {
        private static readonly Controller controllerInstance = new Controller();

        public MainForm MainForm { get; set; }
        public LoginForm LoginForm { get; set; }
        public Raport RaportForm { get; set; }
        public SqlConnector Connector { get; set; }
        public User User { get; set; }
        public MonitorManager MonitorManager { get; set; }

        public FileMonitor FileMonitorOb { get; set; }

        public int FileMonitorInterval {get; set; } = 1000;



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

         this.FileMonitorOb = new FileMonitor();

       //     MonitorManager.RegisterMonitor(new SampleMonitor());
            MonitorManager.RegisterMonitor(this.FileMonitorOb);
  
            MonitorManager.RegisterMonitor(new MouseMonitor());
        }

        public void ShowMainForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            MainForm = new MainForm();

            MainForm.Show();
            LoginForm.Hide();
        }

        public void ShowRaportForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            this.RaportForm = new Raport();

            this.RaportForm.Show();

            //this.RaportForm.refreshRaportData(this.Connector.getDataToChart(this.RaportForm.selectedMonitorType).Keys.t);
        }

        public async Task LoginToApp(string login, string pass)
        {
            try
            {
                User = await Connector.FindUser(login, pass);

                if (User != null)
                {
                    MonitorManager.User = User;
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
