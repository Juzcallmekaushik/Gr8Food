namespace Gr8Food
{
    partial class ManagerForm
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
            this.lstFeedback = new System.Windows.Forms.ListBox();
            this.txtReply = new System.Windows.Forms.TextBox();
            this.btnReply = new System.Windows.Forms.Button();
            this.cmbCustomer = new System.Windows.Forms.ComboBox();
            this.dtFilter = new System.Windows.Forms.DateTimePicker();
            this.lstWallet = new System.Windows.Forms.ListBox();
            this.btnFilterWallet = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFeedback
            // 
            this.lstFeedback.FormattingEnabled = true;
            this.lstFeedback.Location = new System.Drawing.Point(18, 41);
            this.lstFeedback.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstFeedback.Name = "lstFeedback";
            this.lstFeedback.Size = new System.Drawing.Size(254, 186);
            this.lstFeedback.TabIndex = 0;
            // 
            // txtReply
            // 
            this.txtReply.Location = new System.Drawing.Point(18, 235);
            this.txtReply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtReply.Multiline = true;
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(254, 66);
            this.txtReply.TabIndex = 1;
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(18, 318);
            this.btnReply.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(61, 26);
            this.btnReply.TabIndex = 2;
            this.btnReply.Text = "Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(302, 58);
            this.cmbCustomer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(270, 21);
            this.cmbCustomer.TabIndex = 3;
            // 
            // dtFilter
            // 
            this.dtFilter.Location = new System.Drawing.Point(302, 94);
            this.dtFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtFilter.Name = "dtFilter";
            this.dtFilter.Size = new System.Drawing.Size(270, 20);
            this.dtFilter.TabIndex = 4;
            // 
            // lstWallet
            // 
            this.lstWallet.FormattingEnabled = true;
            this.lstWallet.Location = new System.Drawing.Point(302, 158);
            this.lstWallet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstWallet.Name = "lstWallet";
            this.lstWallet.Size = new System.Drawing.Size(270, 186);
            this.lstWallet.TabIndex = 5;
            // 
            // btnFilterWallet
            // 
            this.btnFilterWallet.Location = new System.Drawing.Point(514, 127);
            this.btnFilterWallet.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFilterWallet.Name = "btnFilterWallet";
            this.btnFilterWallet.Size = new System.Drawing.Size(56, 19);
            this.btnFilterWallet.TabIndex = 7;
            this.btnFilterWallet.Text = "Filter";
            this.btnFilterWallet.UseVisualStyleBackColor = true;
            this.btnFilterWallet.Click += new System.EventHandler(this.btnFilterWallet_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(480, 11);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(2);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(56, 22);
            this.btnProfile.TabIndex = 24;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(543, 11);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(56, 22);
            this.btnLogout.TabIndex = 23;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 366);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnFilterWallet);
            this.Controls.Add(this.lstWallet);
            this.Controls.Add(this.dtFilter);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.lstFeedback);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManagerForm";
            this.Text = "ManagerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstFeedback;
        private System.Windows.Forms.TextBox txtReply;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.ComboBox cmbCustomer;
        private System.Windows.Forms.DateTimePicker dtFilter;
        private System.Windows.Forms.ListBox lstWallet;
        private System.Windows.Forms.Button btnFilterWallet;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
    }
}
