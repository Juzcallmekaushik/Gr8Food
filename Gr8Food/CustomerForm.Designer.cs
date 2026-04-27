namespace Gr8Food
{
    partial class CustomerForm
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
            this.lstMenu = new System.Windows.Forms.ListBox();
            this.lstOrders = new System.Windows.Forms.ListBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.btnFeedback = new System.Windows.Forms.Button();
            this.btnTopUp = new System.Windows.Forms.Button();
            this.lblTopUp = new System.Windows.Forms.Label();
            this.txtTopUpAmount = new System.Windows.Forms.TextBox();
            this.lstFeedback = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWallet = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMenu
            // 
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.Location = new System.Drawing.Point(9, 63);
            this.lstMenu.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(286, 212);
            this.lstMenu.TabIndex = 0;
            // 
            // lstOrders
            // 
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.Location = new System.Drawing.Point(314, 63);
            this.lstOrders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(258, 147);
            this.lstOrders.TabIndex = 1;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(9, 283);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(56, 19);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(314, 227);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(80, 19);
            this.btnCancelOrder.TabIndex = 3;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnFeedback
            // 
            this.btnFeedback.Location = new System.Drawing.Point(492, 227);
            this.btnFeedback.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(80, 19);
            this.btnFeedback.TabIndex = 4;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // btnTopUp
            // 
            this.btnTopUp.Location = new System.Drawing.Point(239, 342);
            this.btnTopUp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnTopUp.Name = "btnTopUp";
            this.btnTopUp.Size = new System.Drawing.Size(56, 24);
            this.btnTopUp.TabIndex = 7;
            this.btnTopUp.Text = "Top Up";
            this.btnTopUp.UseVisualStyleBackColor = true;
            this.btnTopUp.Click += new System.EventHandler(this.btnTopUp_Click);
            // 
            // lblTopUp
            // 
            this.lblTopUp.AutoSize = true;
            this.lblTopUp.Location = new System.Drawing.Point(181, 289);
            this.lblTopUp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTopUp.Name = "lblTopUp";
            this.lblTopUp.Size = new System.Drawing.Size(114, 13);
            this.lblTopUp.TabIndex = 8;
            this.lblTopUp.Text = "Type amount to top up";
            // 
            // txtTopUpAmount
            // 
            this.txtTopUpAmount.Location = new System.Drawing.Point(199, 313);
            this.txtTopUpAmount.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtTopUpAmount.Name = "txtTopUpAmount";
            this.txtTopUpAmount.Size = new System.Drawing.Size(96, 20);
            this.txtTopUpAmount.TabIndex = 9;
            // 
            // lstFeedback
            // 
            this.lstFeedback.FormattingEnabled = true;
            this.lstFeedback.Location = new System.Drawing.Point(314, 258);
            this.lstFeedback.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstFeedback.Name = "lstFeedback";
            this.lstFeedback.Size = new System.Drawing.Size(258, 108);
            this.lstFeedback.TabIndex = 10;
            this.lstFeedback.SelectedIndexChanged += new System.EventHandler(this.lstFeedback_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Menu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(319, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Your Order\'s";
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.Location = new System.Drawing.Point(11, 316);
            this.lblWallet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(35, 13);
            this.lblWallet.TabIndex = 5;
            this.lblWallet.Text = "label1";
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(470, 11);
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
            this.btnLogout.Location = new System.Drawing.Point(533, 11);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(56, 22);
            this.btnLogout.TabIndex = 23;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 387);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstFeedback);
            this.Controls.Add(this.txtTopUpAmount);
            this.Controls.Add(this.lblTopUp);
            this.Controls.Add(this.btnTopUp);
            this.Controls.Add(this.lblWallet);
            this.Controls.Add(this.btnFeedback);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.lstOrders);
            this.Controls.Add(this.lstMenu);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CustomerForm";
            this.Text = "CustomerForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMenu;
        private System.Windows.Forms.ListBox lstOrders;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnFeedback;
        private System.Windows.Forms.Button btnTopUp;
        private System.Windows.Forms.Label lblTopUp;
        private System.Windows.Forms.TextBox txtTopUpAmount;
        private System.Windows.Forms.ListBox lstFeedback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
    }
}
