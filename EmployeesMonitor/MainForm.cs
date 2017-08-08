using EmployeesMonitor.Lib.Model;
using EmpoleeysMonitor.Lib;
using System;
using System.Collections.Generic;
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
            string workspace = Properties.Settings.Default["Workspace"].ToString();
            if (!string.IsNullOrWhiteSpace(workspace))
            {
                workspaceLabel.Text = workspace; 
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

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Start")
            {
                startButton.Text = "Pause";
                Controller.Instance.MonitorManager.StartMonitoring();
            }
            else
            {
                startButton.Text = "Start";
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
    }
}
