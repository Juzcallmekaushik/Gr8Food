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
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnFilterWallet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstFeedback
            // 
            this.lstFeedback.FormattingEnabled = true;
            this.lstFeedback.ItemHeight = 16;
            this.lstFeedback.Location = new System.Drawing.Point(12, 52);
            this.lstFeedback.Name = "lstFeedback";
            this.lstFeedback.Size = new System.Drawing.Size(338, 228);
            this.lstFeedback.TabIndex = 0;
            // 
            // txtReply
            // 
            this.txtReply.Location = new System.Drawing.Point(12, 290);
            this.txtReply.Multiline = true;
            this.txtReply.Name = "txtReply";
            this.txtReply.Size = new System.Drawing.Size(338, 80);
            this.txtReply.TabIndex = 1;
            // 
            // btnReply
            // 
            this.btnReply.Location = new System.Drawing.Point(12, 393);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(81, 32);
            this.btnReply.TabIndex = 2;
            this.btnReply.Text = "Reply";
            this.btnReply.UseVisualStyleBackColor = true;
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // cmbCustomer
            // 
            this.cmbCustomer.FormattingEnabled = true;
            this.cmbCustomer.Location = new System.Drawing.Point(393, 52);
            this.cmbCustomer.Name = "cmbCustomer";
            this.cmbCustomer.Size = new System.Drawing.Size(358, 24);
            this.cmbCustomer.TabIndex = 3;
            // 
            // dtFilter
            // 
            this.dtFilter.Location = new System.Drawing.Point(393, 92);
            this.dtFilter.Name = "dtFilter";
            this.dtFilter.Size = new System.Drawing.Size(358, 22);
            this.dtFilter.TabIndex = 4;
            // 
            // lstWallet
            // 
            this.lstWallet.FormattingEnabled = true;
            this.lstWallet.ItemHeight = 16;
            this.lstWallet.Location = new System.Drawing.Point(393, 169);
            this.lstWallet.Name = "lstWallet";
            this.lstWallet.Size = new System.Drawing.Size(358, 228);
            this.lstWallet.TabIndex = 5;
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(740, 23);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnFilterWallet
            // 
            this.btnFilterWallet.Location = new System.Drawing.Point(676, 120);
            this.btnFilterWallet.Name = "btnFilterWallet";
            this.btnFilterWallet.Size = new System.Drawing.Size(75, 23);
            this.btnFilterWallet.TabIndex = 7;
            this.btnFilterWallet.Text = "Filter";
            this.btnFilterWallet.UseVisualStyleBackColor = true;
            this.btnFilterWallet.Click += new System.EventHandler(this.btnFilterWallet_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(827, 450);
            this.Controls.Add(this.btnFilterWallet);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lstWallet);
            this.Controls.Add(this.dtFilter);
            this.Controls.Add(this.cmbCustomer);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.txtReply);
            this.Controls.Add(this.lstFeedback);
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
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnFilterWallet;
    }
}