using EmployeesMonitor.Lib;
using EmployeesMonitor.Lib.DataBase;
using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor.File;
using EmployeesMonitor.Lib.Monitor.Mouse;
using EmpoleeysMonitor.Lib;
using EmpoleeysMonitor.Lib.Monitor.Sample;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace EmployeesMonitor
{
    public class Controller
    {
        private static readonly Controller controllerInstance = new Controller();

        public MainForm MainForm { get; set; }
        public LoginForm LoginForm { get; set; }
        public ReportForm ReportForm { get; set; }
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
            Connector = new SqlConnector();
            MonitorManager = new MonitorManager(60);
            FileMonitorOb = new FileMonitor();

            MonitorManager.RegisterMonitor(FileMonitorOb);
            MonitorManager.RegisterMonitor(new MouseMonitor());
            MonitorManager.RegisterMonitor(new KeyboardMonitor());
        }

        public void ShowMainForm()
        {
            Cursor.Current = Cursors.WaitCursor;
            MainForm = new MainForm();

            MainForm.Show();
            LoginForm.Hide();
        }

        public async Task ShowReport(User user, Project project, GroupingType groupType, DateTime start, DateTime end)
        {
            string filename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, user.Login + "_" + project.Name + ".pdf");
            IList<UserAction> actions = await Connector.GetDataToReport(user.UserId, project.ProjectId, start, end);
            ReportGenerator.GenerateReport(filename, actions, groupType, user, project, start, end);
            System.Diagnostics.Process.Start(filename);
        }

        public void ShowReportForm(User user, Project project, GroupingType groupType, DateTime start, DateTime end)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.ReportForm = new ReportForm(user, project, groupType, start, end);
            Cursor.Current = Cursors.Arrow;
            this.ReportForm.ShowDialog();
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
