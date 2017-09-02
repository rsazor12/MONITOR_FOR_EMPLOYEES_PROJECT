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
            this.groupLabel = new System.Windows.Forms.Label();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.toDateLabel = new System.Windows.Forms.Label();
            this.fromDateLabel = new System.Windows.Forms.Label();
            this.toDateTime = new System.Windows.Forms.DateTimePicker();
            this.fromDateTime = new System.Windows.Forms.DateTimePicker();
            this.userProjectLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.userProjectComboBox = new System.Windows.Forms.ComboBox();
            this.userComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.monitorTabPage.SuspendLayout();
            this.raportsTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.monitorTabPage);
            this.tabControl1.Controls.Add(this.raportsTabPage);
            this.tabControl1.Location = new System.Drawing.Point(18, 18);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(466, 360);
            this.tabControl1.TabIndex = 0;
            // 
            // monitorTabPage
            // 
            this.monitorTabPage.Controls.Add(this.workspaceButton);
            this.monitorTabPage.Controls.Add(this.workspaceLabel);
            this.monitorTabPage.Controls.Add(this.label1);
            this.monitorTabPage.Controls.Add(this.projectComboBox);
            this.monitorTabPage.Controls.Add(this.startButton);
            this.monitorTabPage.Location = new System.Drawing.Point(4, 29);
            this.monitorTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.monitorTabPage.Name = "monitorTabPage";
            this.monitorTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.monitorTabPage.Size = new System.Drawing.Size(458, 327);
            this.monitorTabPage.TabIndex = 0;
            this.monitorTabPage.Text = "Monitor";
            this.monitorTabPage.UseVisualStyleBackColor = true;
            // 
            // workspaceButton
            // 
            this.workspaceButton.Location = new System.Drawing.Point(30, 174);
            this.workspaceButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.workspaceButton.Name = "workspaceButton";
            this.workspaceButton.Size = new System.Drawing.Size(144, 35);
            this.workspaceButton.TabIndex = 4;
            this.workspaceButton.Text = "Workspace";
            this.workspaceButton.UseVisualStyleBackColor = true;
            this.workspaceButton.Click += new System.EventHandler(this.workspaceButton_Click);
            // 
            // workspaceLabel
            // 
            this.workspaceLabel.AutoSize = true;
            this.workspaceLabel.Location = new System.Drawing.Point(26, 135);
            this.workspaceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.workspaceLabel.Name = "workspaceLabel";
            this.workspaceLabel.Size = new System.Drawing.Size(154, 20);
            this.workspaceLabel.TabIndex = 3;
            this.workspaceLabel.Text = "Current workspace...";
            this.workspaceLabel.TextChanged += new System.EventHandler(this.workspaceLabel_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Choose project:";
            // 
            // projectComboBox
            // 
            this.projectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.projectComboBox.Location = new System.Drawing.Point(30, 65);
            this.projectComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.projectComboBox.Name = "projectComboBox";
            this.projectComboBox.Size = new System.Drawing.Size(382, 28);
            this.projectComboBox.TabIndex = 1;
            this.projectComboBox.SelectedIndexChanged += new System.EventHandler(this.projectComboBox_SelectedIndexChanged);
            // 
            // startButton
            // 
            this.startButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startButton.Location = new System.Drawing.Point(296, 208);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(118, 74);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // raportsTabPage
            // 
            this.raportsTabPage.Controls.Add(this.groupLabel);
            this.raportsTabPage.Controls.Add(this.groupComboBox);
            this.raportsTabPage.Controls.Add(this.generateButton);
            this.raportsTabPage.Controls.Add(this.toDateLabel);
            this.raportsTabPage.Controls.Add(this.fromDateLabel);
            this.raportsTabPage.Controls.Add(this.toDateTime);
            this.raportsTabPage.Controls.Add(this.fromDateTime);
            this.raportsTabPage.Controls.Add(this.userProjectLabel);
            this.raportsTabPage.Controls.Add(this.userLabel);
            this.raportsTabPage.Controls.Add(this.userProjectComboBox);
            this.raportsTabPage.Controls.Add(this.userComboBox);
            this.raportsTabPage.Location = new System.Drawing.Point(4, 29);
            this.raportsTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.raportsTabPage.Name = "raportsTabPage";
            this.raportsTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.raportsTabPage.Size = new System.Drawing.Size(458, 327);
            this.raportsTabPage.TabIndex = 1;
            this.raportsTabPage.Text = "Reports";
            this.raportsTabPage.UseVisualStyleBackColor = true;
            // 
            // groupLabel
            // 
            this.groupLabel.AutoSize = true;
            this.groupLabel.Location = new System.Drawing.Point(28, 143);
            this.groupLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(74, 20);
            this.groupLabel.TabIndex = 10;
            this.groupLabel.Text = "Group by";
            // 
            // groupComboBox
            // 
            this.groupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(114, 138);
            this.groupComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(290, 28);
            this.groupComboBox.TabIndex = 9;
            this.groupComboBox.SelectedIndexChanged += new System.EventHandler(this.groupComboBox_SelectedIndexChanged);
            // 
            // generateButton
            // 
            this.generateButton.Enabled = false;
            this.generateButton.Location = new System.Drawing.Point(320, 235);
            this.generateButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(100, 52);
            this.generateButton.TabIndex = 8;
            this.generateButton.Text = "Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // toDateLabel
            // 
            this.toDateLabel.AutoSize = true;
            this.toDateLabel.Location = new System.Drawing.Point(28, 268);
            this.toDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.toDateLabel.Name = "toDateLabel";
            this.toDateLabel.Size = new System.Drawing.Size(27, 20);
            this.toDateLabel.TabIndex = 7;
            this.toDateLabel.Text = "To";
            // 
            // fromDateLabel
            // 
            this.fromDateLabel.AutoSize = true;
            this.fromDateLabel.Location = new System.Drawing.Point(24, 212);
            this.fromDateLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.fromDateLabel.Name = "fromDateLabel";
            this.fromDateLabel.Size = new System.Drawing.Size(46, 20);
            this.fromDateLabel.TabIndex = 6;
            this.fromDateLabel.Text = "From";
            // 
            // toDateTime
            // 
            this.toDateTime.Location = new System.Drawing.Point(78, 258);
            this.toDateTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.toDateTime.Name = "toDateTime";
            this.toDateTime.Size = new System.Drawing.Size(192, 26);
            this.toDateTime.TabIndex = 5;
            // 
            // fromDateTime
            // 
            this.fromDateTime.Location = new System.Drawing.Point(78, 203);
            this.fromDateTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fromDateTime.Name = "fromDateTime";
            this.fromDateTime.Size = new System.Drawing.Size(192, 26);
            this.fromDateTime.TabIndex = 4;
            this.fromDateTime.Value = new System.DateTime(2017, 8, 7, 19, 32, 20, 0);
            // 
            // userProjectLabel
            // 
            this.userProjectLabel.AutoSize = true;
            this.userProjectLabel.Location = new System.Drawing.Point(44, 32);
            this.userProjectLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userProjectLabel.Name = "userProjectLabel";
            this.userProjectLabel.Size = new System.Drawing.Size(58, 20);
            this.userProjectLabel.TabIndex = 3;
            this.userProjectLabel.Text = "Project";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Location = new System.Drawing.Point(60, 88);
            this.userLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(43, 20);
            this.userLabel.TabIndex = 2;
            this.userLabel.Text = "User";
            // 
            // userProjectComboBox
            // 
            this.userProjectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userProjectComboBox.FormattingEnabled = true;
            this.userProjectComboBox.Location = new System.Drawing.Point(114, 28);
            this.userProjectComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userProjectComboBox.Name = "userProjectComboBox";
            this.userProjectComboBox.Size = new System.Drawing.Size(290, 28);
            this.userProjectComboBox.TabIndex = 1;
            this.userProjectComboBox.SelectedIndexChanged += new System.EventHandler(this.userProjectComboBox_SelectedIndexChanged);
            // 
            // userComboBox
            // 
            this.userComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userComboBox.FormattingEnabled = true;
            this.userComboBox.Location = new System.Drawing.Point(114, 83);
            this.userComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.userComboBox.Name = "userComboBox";
            this.userComboBox.Size = new System.Drawing.Size(290, 28);
            this.userComboBox.TabIndex = 0;
            this.userComboBox.SelectedIndexChanged += new System.EventHandler(this.userComboBox_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 397);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Label groupLabel;
    }
}