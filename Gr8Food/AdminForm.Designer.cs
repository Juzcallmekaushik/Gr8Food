namespace Gr8Food
{
    partial class AdminForm
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
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.btnViewReport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.cmbChef = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.dtpReportFilter = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lstReport = new System.Windows.Forms.ListBox();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.cmbNewRole = new System.Windows.Forms.ComboBox();
            this.txtEditUsername = new System.Windows.Forms.TextBox();
            this.txtEditFullName = new System.Windows.Forms.TextBox();
            this.txtEditPassword = new System.Windows.Forms.TextBox();
            this.cmbEditRole = new System.Windows.Forms.ComboBox();
            this.lblNewUsername = new System.Windows.Forms.Label();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.lblEditPassword = new System.Windows.Forms.Label();
            this.lblEditRole = new System.Windows.Forms.Label();
            this.txtNewFullName = new System.Windows.Forms.TextBox();
            this.lblNewFullName = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.lblEditUsername = new System.Windows.Forms.Label();
            this.lblEditFullName = new System.Windows.Forms.Label();
            this.lblNewRole = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(429, 71);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(461, 132);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(508, 340);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(114, 23);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(508, 377);
            this.btnDeleteUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(114, 23);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(765, 340);
            this.btnUpdateUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(125, 23);
            this.btnUpdateUser.TabIndex = 3;
            this.btnUpdateUser.Text = "Update User";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Location = new System.Drawing.Point(45, 25);
            this.btnViewReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(130, 30);
            this.btnViewReport.TabIndex = 4;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(817, 25);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 27);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // cmbChef
            // 
            this.cmbChef.FormattingEnabled = true;
            this.cmbChef.Location = new System.Drawing.Point(45, 108);
            this.cmbChef.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbChef.Name = "cmbChef";
            this.cmbChef.Size = new System.Drawing.Size(333, 24);
            this.cmbChef.TabIndex = 6;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(45, 71);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(333, 24);
            this.cmbCategory.TabIndex = 7;
            // 
            // dtpReportFilter
            // 
            this.dtpReportFilter.Location = new System.Drawing.Point(45, 144);
            this.dtpReportFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpReportFilter.Name = "dtpReportFilter";
            this.dtpReportFilter.Size = new System.Drawing.Size(333, 22);
            this.dtpReportFilter.TabIndex = 8;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(45, 175);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(335, 23);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // lstReport
            // 
            this.lstReport.FormattingEnabled = true;
            this.lstReport.ItemHeight = 16;
            this.lstReport.Location = new System.Drawing.Point(45, 229);
            this.lstReport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstReport.Name = "lstReport";
            this.lstReport.Size = new System.Drawing.Size(333, 180);
            this.lstReport.TabIndex = 10;
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.Location = new System.Drawing.Point(508, 246);
            this.txtNewUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(114, 22);
            this.txtNewUsername.TabIndex = 11;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(508, 274);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(114, 22);
            this.txtNewPassword.TabIndex = 12;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // cmbNewRole
            // 
            this.cmbNewRole.FormattingEnabled = true;
            this.cmbNewRole.Location = new System.Drawing.Point(508, 309);
            this.cmbNewRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbNewRole.Name = "cmbNewRole";
            this.cmbNewRole.Size = new System.Drawing.Size(114, 24);
            this.cmbNewRole.TabIndex = 13;
            // 
            // txtEditUsername
            // 
            this.txtEditUsername.Location = new System.Drawing.Point(765, 218);
            this.txtEditUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEditUsername.Name = "txtEditUsername";
            this.txtEditUsername.Size = new System.Drawing.Size(125, 22);
            this.txtEditUsername.TabIndex = 14;
            // 
            // txtEditFullName
            // 
            this.txtEditFullName.Location = new System.Drawing.Point(765, 245);
            this.txtEditFullName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEditFullName.Name = "txtEditFullName";
            this.txtEditFullName.Size = new System.Drawing.Size(125, 22);
            this.txtEditFullName.TabIndex = 15;
            // 
            // txtEditPassword
            // 
            this.txtEditPassword.Location = new System.Drawing.Point(765, 274);
            this.txtEditPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEditPassword.Name = "txtEditPassword";
            this.txtEditPassword.Size = new System.Drawing.Size(125, 22);
            this.txtEditPassword.TabIndex = 16;
            this.txtEditPassword.UseSystemPasswordChar = true;
            // 
            // cmbEditRole
            // 
            this.cmbEditRole.FormattingEnabled = true;
            this.cmbEditRole.Location = new System.Drawing.Point(765, 306);
            this.cmbEditRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEditRole.Name = "cmbEditRole";
            this.cmbEditRole.Size = new System.Drawing.Size(125, 24);
            this.cmbEditRole.TabIndex = 17;
            // 
            // lblNewUsername
            // 
            this.lblNewUsername.AutoSize = true;
            this.lblNewUsername.Location = new System.Drawing.Point(432, 246);
            this.lblNewUsername.Name = "lblNewUsername";
            this.lblNewUsername.Size = new System.Drawing.Size(70, 16);
            this.lblNewUsername.TabIndex = 16;
            this.lblNewUsername.Text = "Username";
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(432, 274);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(67, 16);
            this.lblNewPassword.TabIndex = 17;
            this.lblNewPassword.Text = "Password";
            // 
            // lblEditPassword
            // 
            this.lblEditPassword.AutoSize = true;
            this.lblEditPassword.Location = new System.Drawing.Point(663, 277);
            this.lblEditPassword.Name = "lblEditPassword";
            this.lblEditPassword.Size = new System.Drawing.Size(67, 16);
            this.lblEditPassword.TabIndex = 18;
            this.lblEditPassword.Text = "Password";
            // 
            // lblEditRole
            // 
            this.lblEditRole.AutoSize = true;
            this.lblEditRole.Location = new System.Drawing.Point(663, 314);
            this.lblEditRole.Name = "lblEditRole";
            this.lblEditRole.Size = new System.Drawing.Size(36, 16);
            this.lblEditRole.TabIndex = 19;
            this.lblEditRole.Text = "Role";
            // 
            // txtNewFullName
            // 
            this.txtNewFullName.Location = new System.Drawing.Point(508, 218);
            this.txtNewFullName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNewFullName.Name = "txtNewFullName";
            this.txtNewFullName.Size = new System.Drawing.Size(114, 22);
            this.txtNewFullName.TabIndex = 20;
            // 
            // lblNewFullName
            // 
            this.lblNewFullName.AutoSize = true;
            this.lblNewFullName.Location = new System.Drawing.Point(432, 221);
            this.lblNewFullName.Name = "lblNewFullName";
            this.lblNewFullName.Size = new System.Drawing.Size(68, 16);
            this.lblNewFullName.TabIndex = 21;
            this.lblNewFullName.Text = "Full Name";
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(733, 25);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 27);
            this.btnProfile.TabIndex = 22;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // lblEditUsername
            // 
            this.lblEditUsername.AutoSize = true;
            this.lblEditUsername.Location = new System.Drawing.Point(663, 221);
            this.lblEditUsername.Name = "lblEditUsername";
            this.lblEditUsername.Size = new System.Drawing.Size(70, 16);
            this.lblEditUsername.TabIndex = 23;
            this.lblEditUsername.Text = "Username";
            // 
            // lblEditFullName
            // 
            this.lblEditFullName.AutoSize = true;
            this.lblEditFullName.Location = new System.Drawing.Point(663, 249);
            this.lblEditFullName.Name = "lblEditFullName";
            this.lblEditFullName.Size = new System.Drawing.Size(68, 16);
            this.lblEditFullName.TabIndex = 24;
            this.lblEditFullName.Text = "Full Name";
            // 
            // lblNewRole
            // 
            this.lblNewRole.AutoSize = true;
            this.lblNewRole.Location = new System.Drawing.Point(432, 314);
            this.lblNewRole.Name = "lblNewRole";
            this.lblNewRole.Size = new System.Drawing.Size(36, 16);
            this.lblNewRole.TabIndex = 25;
            this.lblNewRole.Text = "Role";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 450);
            this.Controls.Add(this.lblNewRole);
            this.Controls.Add(this.lblEditFullName);
            this.Controls.Add(this.lblEditUsername);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.lblNewFullName);
            this.Controls.Add(this.txtNewFullName);
            this.Controls.Add(this.lblEditRole);
            this.Controls.Add(this.lblEditPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.lblNewUsername);
            this.Controls.Add(this.cmbEditRole);
            this.Controls.Add(this.txtEditFullName);
            this.Controls.Add(this.txtEditUsername);
            this.Controls.Add(this.txtEditPassword);
            this.Controls.Add(this.cmbNewRole);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtNewUsername);
            this.Controls.Add(this.lstReport);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dtpReportFilter);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbChef);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lstUsers);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstUsers;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnUpdateUser;
        private System.Windows.Forms.Button btnViewReport;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.ComboBox cmbChef;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.DateTimePicker dtpReportFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ListBox lstReport;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.ComboBox cmbNewRole;
        private System.Windows.Forms.TextBox txtEditUsername;
        private System.Windows.Forms.TextBox txtEditFullName;
        private System.Windows.Forms.TextBox txtEditPassword;
        private System.Windows.Forms.ComboBox cmbEditRole;
        private System.Windows.Forms.Label lblNewUsername;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Label lblEditPassword;
        private System.Windows.Forms.Label lblEditRole;
        private System.Windows.Forms.TextBox txtNewFullName;
        private System.Windows.Forms.Label lblNewFullName;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Label lblEditUsername;
        private System.Windows.Forms.Label lblEditFullName;
        private System.Windows.Forms.Label lblNewRole;
    }
}
