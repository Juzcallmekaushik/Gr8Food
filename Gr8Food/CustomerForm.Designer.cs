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
            this.lblMenu = new System.Windows.Forms.Label();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lblWallet = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMenu
            // 
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.ItemHeight = 16;
            this.lstMenu.Location = new System.Drawing.Point(12, 78);
            this.lstMenu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(380, 260);
            this.lstMenu.TabIndex = 0;
            // 
            // lstOrders
            // 
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.ItemHeight = 16;
            this.lstOrders.Location = new System.Drawing.Point(419, 78);
            this.lstOrders.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(343, 180);
            this.lstOrders.TabIndex = 1;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(12, 348);
            this.btnOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(419, 279);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(107, 23);
            this.btnCancelOrder.TabIndex = 3;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnFeedback
            // 
            this.btnFeedback.Location = new System.Drawing.Point(656, 279);
            this.btnFeedback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(107, 23);
            this.btnFeedback.TabIndex = 4;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // btnTopUp
            // 
            this.btnTopUp.Location = new System.Drawing.Point(319, 421);
            this.btnTopUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTopUp.Name = "btnTopUp";
            this.btnTopUp.Size = new System.Drawing.Size(75, 30);
            this.btnTopUp.TabIndex = 7;
            this.btnTopUp.Text = "Top Up";
            this.btnTopUp.UseVisualStyleBackColor = true;
            this.btnTopUp.Click += new System.EventHandler(this.btnTopUp_Click);
            // 
            // lblTopUp
            // 
            this.lblTopUp.AutoSize = true;
            this.lblTopUp.Location = new System.Drawing.Point(241, 356);
            this.lblTopUp.Name = "lblTopUp";
            this.lblTopUp.Size = new System.Drawing.Size(140, 16);
            this.lblTopUp.TabIndex = 8;
            this.lblTopUp.Text = "Type amount to top up";
            // 
            // txtTopUpAmount
            // 
            this.txtTopUpAmount.Location = new System.Drawing.Point(265, 385);
            this.txtTopUpAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTopUpAmount.Name = "txtTopUpAmount";
            this.txtTopUpAmount.Size = new System.Drawing.Size(127, 22);
            this.txtTopUpAmount.TabIndex = 9;
            // 
            // lstFeedback
            // 
            this.lstFeedback.FormattingEnabled = true;
            this.lstFeedback.ItemHeight = 16;
            this.lstFeedback.Location = new System.Drawing.Point(419, 318);
            this.lstFeedback.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstFeedback.Name = "lstFeedback";
            this.lstFeedback.Size = new System.Drawing.Size(343, 132);
            this.lstFeedback.TabIndex = 10;
            this.lstFeedback.SelectedIndexChanged += new System.EventHandler(this.lstFeedback_SelectedIndexChanged);
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Location = new System.Drawing.Point(12, 46);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(40, 16);
            this.lblMenu.TabIndex = 12;
            this.lblMenu.Text = "Menu";
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Location = new System.Drawing.Point(415, 46);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(82, 16);
            this.lblOrders.TabIndex = 13;
            this.lblOrders.Text = "Your Order\'s";
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.Location = new System.Drawing.Point(15, 389);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(152, 16);
            this.lblWallet.TabIndex = 5;
            this.lblWallet.Text = "Wallet Balance: RM 0.00";
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(627, 14);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 27);
            this.btnProfile.TabIndex = 24;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(711, 14);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 27);
            this.btnLogout.TabIndex = 23;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 476);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.lblMenu);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
    }
}
