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
            this.dtFilter = new System.Windows.Forms.DateTimePicker();
            this.btnFilter = new System.Windows.Forms.Button();
            this.lstReport = new System.Windows.Forms.ListBox();
            this.txtNewUsername = new System.Windows.Forms.TextBox();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtEditUsername = new System.Windows.Forms.TextBox();
            this.txtEditFullName = new System.Windows.Forms.TextBox();
            this.txtEditPassword = new System.Windows.Forms.TextBox();
            this.cmbEditRole = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 16;
            this.lstUsers.Location = new System.Drawing.Point(430, 71);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(228, 132);
            this.lstUsers.TabIndex = 0;
            this.lstUsers.SelectedIndexChanged += new System.EventHandler(this.lstUsers_SelectedIndexChanged);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(495, 334);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(126, 23);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(495, 363);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(126, 23);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Delete User";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Location = new System.Drawing.Point(765, 304);
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
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(106, 23);
            this.btnViewReport.TabIndex = 4;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(815, 25);
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
            this.cmbChef.Location = new System.Drawing.Point(45, 114);
            this.cmbChef.Name = "cmbChef";
            this.cmbChef.Size = new System.Drawing.Size(121, 24);
            this.cmbChef.TabIndex = 6;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(45, 71);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 24);
            this.cmbCategory.TabIndex = 7;
            // 
            // dtFilter
            // 
            this.dtFilter.Location = new System.Drawing.Point(45, 144);
            this.dtFilter.Name = "dtFilter";
            this.dtFilter.Size = new System.Drawing.Size(200, 22);
            this.dtFilter.TabIndex = 8;
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(45, 172);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(75, 23);
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
            this.lstReport.Name = "lstReport";
            this.lstReport.Size = new System.Drawing.Size(333, 180);
            this.lstReport.TabIndex = 10;
            // 
            // txtNewUsername
            // 
            this.txtNewUsername.Location = new System.Drawing.Point(501, 251);
            this.txtNewUsername.Name = "txtNewUsername";
            this.txtNewUsername.Size = new System.Drawing.Size(120, 22);
            this.txtNewUsername.TabIndex = 11;
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(501, 279);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(120, 22);
            this.txtNewPassword.TabIndex = 12;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(501, 307);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(121, 24);
            this.cmbRole.TabIndex = 13;
            // 
            // txtEditUsername
            // 
            this.txtEditUsername.Location = new System.Drawing.Point(765, 215);
            this.txtEditUsername.Name = "txtEditUsername";
            this.txtEditUsername.Size = new System.Drawing.Size(125, 22);
            this.txtEditUsername.TabIndex = 14;
            // 
            // txtEditFullName
            // 
            this.txtEditFullName.Location = new System.Drawing.Point(765, 243);
            this.txtEditFullName.Name = "txtEditFullName";
            this.txtEditFullName.Size = new System.Drawing.Size(125, 22);
            this.txtEditFullName.TabIndex = 15;
            // 
            // txtEditPassword
            // 
            this.txtEditPassword.Location = new System.Drawing.Point(765, 271);
            this.txtEditPassword.Name = "txtEditPassword";
            this.txtEditPassword.Size = new System.Drawing.Size(125, 22);
            this.txtEditPassword.TabIndex = 16;
            this.txtEditPassword.UseSystemPasswordChar = true;
            // 
            // cmbEditRole
            // 
            this.cmbEditRole.FormattingEnabled = true;
            this.cmbEditRole.Location = new System.Drawing.Point(765, 299);
            this.cmbEditRole.Name = "cmbEditRole";
            this.cmbEditRole.Size = new System.Drawing.Size(125, 24);
            this.cmbEditRole.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(663, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(663, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Role";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(501, 223);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(120, 22);
            this.txtFullName.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(431, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Full Name";
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(734, 25);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 27);
            this.btnProfile.TabIndex = 22;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(663, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 16);
            this.label6.TabIndex = 23;
            this.label6.Text = "Username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(663, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 24;
            this.label7.Text = "Full Name";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 450);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEditRole);
            this.Controls.Add(this.txtEditFullName);
            this.Controls.Add(this.txtEditUsername);
            this.Controls.Add(this.txtEditPassword);
            this.Controls.Add(this.cmbRole);
            this.Controls.Add(this.txtNewPassword);
            this.Controls.Add(this.txtNewUsername);
            this.Controls.Add(this.lstReport);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.dtFilter);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.cmbChef);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.lstUsers);
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
        private System.Windows.Forms.DateTimePicker dtFilter;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.ListBox lstReport;
        private System.Windows.Forms.TextBox txtNewUsername;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.TextBox txtEditUsername;
        private System.Windows.Forms.TextBox txtEditFullName;
        private System.Windows.Forms.TextBox txtEditPassword;
        private System.Windows.Forms.ComboBox cmbEditRole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}
