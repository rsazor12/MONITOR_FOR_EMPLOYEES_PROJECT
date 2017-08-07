using EmployeesMonitor.Lib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                }
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Start")
            {
                startButton.Text = "Pause";
            }
               
        }
        public void ValidateStartButton()
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

            var taskSupervisedProjects = await Controller.Instance.Connector.FindSupervisedProjects(user);
            userProjectComboBox.Items.AddRange(taskSupervisedProjects.ToArray());
        }

        private async void userProjectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = Controller.Instance.User;
            Project chosenProject = (Project)userProjectComboBox.SelectedItem;
            var taskUsers = await Controller.Instance.Connector.FindProjectUsers(chosenProject);
            userComboBox.Items.Clear();
            userComboBox.Items.AddRange(taskUsers.ToArray());
        }
    }
}
