using EmployeesMonitor.Lib.Model;
using EmpoleeysMonitor.Lib;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EmployeesMonitor
{
    public partial class MainForm : Form
    {
        private string folderPath;

        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            Controller.Instance.MainForm = this;
            fromDateTime.Value = DateTime.Now.AddMonths(-1);
            folderPath = Properties.Settings.Default["Workspace"].ToString();
            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                workspaceLabel.Text = folderPath; 
            }
            groupComboBox.Items.AddRange(Enum.GetValues(typeof(GroupingType)).Cast<GroupingType>().Select(x =>(object)x).ToArray());
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void workspaceButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    folderPath = fbd.SelectedPath;
                    workspaceLabel.Text = folderPath;
                    Properties.Settings.Default["Workspace"] = folderPath;
                    Properties.Settings.Default.Save();
                }
            }
        }

        private async void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Start")
            {
                projectComboBox.Enabled = false;
                startButton.Text = "Pause";
                await Controller.Instance.Connector.AddUserAction(CreateAction(ActionType.StartWorking));
                Controller.Instance.FileMonitorOb.SetUp(folderPath, 60);
                Controller.Instance.MonitorManager.StartMonitoring();
            }
            else
            {
                projectComboBox.Enabled = true;
                startButton.Text = "Start";
                await Controller.Instance.Connector.AddUserAction(CreateAction(ActionType.EndWorking));
                Controller.Instance.MonitorManager.EndMonitoring();
            }
        }

        private void ValidateGenerateButton()
        {
            generateButton.Enabled = userProjectComboBox.SelectedIndex >= 0 && userComboBox.SelectedIndex >= 0 && groupComboBox.SelectedIndex >= 0;
        }

        private void ValidateStartButton()
        {
            startButton.Enabled = !string.IsNullOrWhiteSpace(projectComboBox.Text) && !string.IsNullOrWhiteSpace(workspaceLabel.Text) && (Directory.Exists(workspaceLabel.Text));
        }

        private void workspaceLabel_TextChanged(object sender, EventArgs e)
        {
            ValidateStartButton();
        }

        private void projectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateStartButton();
            Controller.Instance.MonitorManager.Project = projectComboBox.SelectedItem as Project;
        }

        private async void MainForm_Shown(object sender, EventArgs e)
        {
            User user = Controller.Instance.User;

            var taskProjects = await Controller.Instance.Connector.FindUserProjects(user);
            projectComboBox.Items.AddRange(taskProjects.ToArray());

            object[] projectArray;
            if (user.UserRole == Role.Admin)
            {
                projectArray = (await Controller.Instance.Connector.GetAllProjects()).ToArray();
            }
            else
            {
                projectArray = taskProjects.ToArray();
            }

            userProjectComboBox.Items.AddRange(projectArray);
        }

        private async void userProjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = Controller.Instance.User;
            Project chosenProject = (Project)userProjectComboBox.SelectedItem;

            userComboBox.Items.Clear();
            if (chosenProject.SupervisorId == user.UserId || user.UserRole == Role.Admin)
            {
                var taskUsers = await Controller.Instance.Connector.FindProjectUsers(chosenProject);
                userComboBox.Items.AddRange(taskUsers.ToArray());
            }
            else 
            {
                userComboBox.Items.Add(user);
            }
            ValidateGenerateButton();
        }

        private void userComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateGenerateButton();
        }

        private void groupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidateGenerateButton();
        }

        private UserAction CreateAction(ActionType actionType)
        {
            return new UserAction()
            {
                ActionType = actionType,
                Date = DateTime.UtcNow,
                ProjectId = Controller.Instance.MonitorManager.Project.ProjectId,
                UserId = Controller.Instance.User.UserId
            };
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            Controller.Instance.ShowRaportForm();
        }
    }
}
