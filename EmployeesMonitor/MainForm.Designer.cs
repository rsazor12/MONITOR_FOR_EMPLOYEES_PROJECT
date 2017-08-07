namespace EmployeesMonitor
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.monitorTabPage = new System.Windows.Forms.TabPage();
            this.workspaceButton = new System.Windows.Forms.Button();
            this.workspaceLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.projectComboBox = new System.Windows.Forms.ComboBox();
            this.startButton = new System.Windows.Forms.Button();
            this.raportsTabPage = new System.Windows.Forms.TabPage();
            this.toDateTime = new System.Windows.Forms.DateTimePicker();
            this.fromDateTime = new System.Windows.Forms.DateTimePicker();
            this.userProjectLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.userProjectComboBox = new System.Windows.Forms.ComboBox();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.toDateLabel = new System.Windows.Forms.Label();
            this.helloLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.monitorTabPage.SuspendLayout();
            this.raportsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.monitorTabPage);
            this.tabControl1.Controls.Add(this.raportsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 234);
            this.tabControl1.TabIndex = 0;
            // 
            // monitorTabPage
            // 
            this.monitorTabPage.Controls.Add(this.helloLabel);
            this.monitorTabPage.Controls.Add(this.workspaceButton);
            this.monitorTabPage.Controls.Add(this.workspaceLabel);
            this.monitorTabPage.Controls.Add(this.label1);
            this.monitorTabPage.Controls.Add(this.projectComboBox);
            this.monitorTabPage.Controls.Add(this.startButton);
            this.monitorTabPage.Location = new System.Drawing.Point(4, 22);
            this.monitorTabPage.Name = "monitorTabPage";
            this.monitorTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.monitorTabPage.Size = new System.Drawing.Size(523, 208);
            this.monitorTabPage.TabIndex = 0;
            this.monitorTabPage.Text = "Monitor";
            this.monitorTabPage.UseVisualStyleBackColor = true;
            // 
            // workspaceButton
            // 
            this.workspaceButton.Location = new System.Drawing.Point(31, 152);
            this.workspaceButton.Name = "workspaceButton";
            this.workspaceButton.Size = new System.Drawing.Size(96, 23);
            this.workspaceButton.TabIndex = 4;
            this.workspaceButton.Text = "Workspace";
            this.workspaceButton.UseVisualStyleBackColor = true;
            this.workspaceButton.Click += new System.EventHandler(this.workspaceButton_Click);
            // 
            // workspaceLabel
            // 
            this.workspaceLabel.AutoSize = true;
            this.workspaceLabel.Location = new System.Drawing.Point(28, 127);
            this.workspaceLabel.Name = "workspaceLabel";
            this.workspaceLabel.Size = new System.Drawing.Size(105, 13);
            this.workspaceLabel.TabIndex = 3;
            this.workspaceLabel.Text = "Current workspace...";
            this.workspaceLabel.TextChanged += new System.EventHandler(this.workspaceLabel_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose project:";
            // 
            // projectComboBox
            // 
            this.projectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectComboBox.Location = new System.Drawing.Point(31, 66);
            this.projectComboBox.Name = "projectComboBox";
            this.projectComboBox.Size = new System.Drawing.Size(256, 21);
            this.projectComboBox.TabIndex = 1;
            this.projectComboBox.SelectedIndexChanged += new System.EventHandler(this.projectComboBox_SelectedIndexChanged);
            // 
            // startButton
            // 
            this.startButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(406, 127);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(79, 48);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // raportsTabPage
            // 
            this.raportsTabPage.Controls.Add(this.toDateLabel);
            this.raportsTabPage.Controls.Add(this.fromDateLabel);
            this.raportsTabPage.Controls.Add(this.toDateTime);
            this.raportsTabPage.Controls.Add(this.fromDateTime);
            this.raportsTabPage.Controls.Add(this.userProjectLabel);
            this.raportsTabPage.Controls.Add(this.userLabel);
            this.raportsTabPage.Controls.Add(this.userProjectComboBox);
            this.raportsTabPage.Controls.Add(this.userComboBox);
            this.raportsTabPage.Location = new System.Drawing.Point(4, 22);
            this.raportsTabPage.Name = "raportsTabPage";
            this.raportsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.raportsTabPage.Size = new System.Drawing.Size(523, 208);
            this.raportsTabPage.TabIndex = 1;
            this.raportsTabPage.Text = "Raports";
            this.raportsTabPage.UseVisualStyleBackColor = true;
            // 
            // toDateTime
            // 
            this.toDateTime.Location = new System.Drawing.Point(69, 163);
            this.toDateTime.Name = "toDateTime";
            this.toDateTime.Size = new System.Drawing.Size(201, 20);
            this.toDateTime.TabIndex = 5;
            // 
            // fromDateTime
            // 
            this.fromDateTime.Location = new System.Drawing.Point(69, 122);
            this.fromDateTime.Name = "fromDateTime";
            this.fromDateTime.Size = new System.Drawing.Size(201, 20);
            this.fromDateTime.TabIndex = 4;
            this.fromDateTime.Value = new System.DateTime(2017, 8, 7, 19, 32, 20, 0);
            // 
            // userProjectLabel
            // 
            this.userProjectLabel.AutoSize = true;
            this.userProjectLabel.Location = new System.Drawing.Point(17, 16);
            this.userProjectLabel.Name = "userProjectLabel";
            this.userProjectLabel.Size = new System.Drawing.Size(40, 13);
            this.userProjectLabel.TabIndex = 3;
            this.userProjectLabel.Text = "Project";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(17, 59);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(29, 13);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "User";
            // 
            // userProjectComboBox
            // 
            this.userProjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userProjectComboBox.FormattingEnabled = true;
            this.userProjectComboBox.Location = new System.Drawing.Point(20, 35);
            this.userProjectComboBox.Name = "userProjectComboBox";
            this.userProjectComboBox.Size = new System.Drawing.Size(250, 21);
            this.userProjectComboBox.TabIndex = 1;
            this.userProjectComboBox.SelectedIndexChanged += new System.EventHandler(this.userProjectComboBox_SelectedIndexChanged);
            // 
            // userComboBox
            // 
            this.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(20, 78);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(250, 21);
            this.userComboBox.TabIndex = 0;
            // 
            // fromDateLabel
            // 
            this.fromDateLabel.AutoSize = true;
            this.fromDateLabel.Location = new System.Drawing.Point(17, 128);
            this.fromDateLabel.Name = "fromDateLabel";
            this.fromDateLabel.Size = new System.Drawing.Size(30, 13);
            this.fromDateLabel.TabIndex = 6;
            this.fromDateLabel.Text = "From";
            // 
            // toDateLabel
            // 
            this.toDateLabel.AutoSize = true;
            this.toDateLabel.Location = new System.Drawing.Point(20, 169);
            this.toDateLabel.Name = "toDateLabel";
            this.toDateLabel.Size = new System.Drawing.Size(20, 13);
            this.toDateLabel.TabIndex = 7;
            this.toDateLabel.Text = "To";
            // 
            // helloLabel
            // 
            this.helloLabel.AutoSize = true;
            this.helloLabel.Location = new System.Drawing.Point(338, 16);
            this.helloLabel.Name = "helloLabel";
            this.helloLabel.Size = new System.Drawing.Size(31, 13);
            this.helloLabel.TabIndex = 5;
            this.helloLabel.Text = "Hello";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 258);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.tabControl1.ResumeLayout(false);
            this.monitorTabPage.ResumeLayout(false);
            this.monitorTabPage.PerformLayout();
            this.raportsTabPage.ResumeLayout(false);
            this.raportsTabPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage monitorTabPage;
        private System.Windows.Forms.Button workspaceButton;
        private System.Windows.Forms.Label workspaceLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox projectComboBox;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.TabPage raportsTabPage;
        private System.Windows.Forms.DateTimePicker toDateTime;
        private System.Windows.Forms.DateTimePicker fromDateTime;
        private System.Windows.Forms.Label userProjectLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.ComboBox userProjectComboBox;
        private System.Windows.Forms.ComboBox userComboBox;
        private System.Windows.Forms.Label toDateLabel;
        private System.Windows.Forms.Label fromDateLabel;
        private System.Windows.Forms.Label helloLabel;
    }
}