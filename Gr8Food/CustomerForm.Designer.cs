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
            this.lblWallet = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnTopUp = new System.Windows.Forms.Button();
            this.lblTopUp = new System.Windows.Forms.Label();
            this.txtTopUpAmount = new System.Windows.Forms.TextBox();
            this.lstFeedback = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lstMenu
            // 
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.ItemHeight = 16;
            this.lstMenu.Location = new System.Drawing.Point(12, 77);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(380, 260);
            this.lstMenu.TabIndex = 0;
            // 
            // lstOrders
            // 
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.ItemHeight = 16;
            this.lstOrders.Location = new System.Drawing.Point(418, 77);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(342, 180);
            this.lstOrders.TabIndex = 1;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(12, 355);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "Order";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Location = new System.Drawing.Point(440, 279);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(107, 23);
            this.btnCancelOrder.TabIndex = 3;
            this.btnCancelOrder.Text = "Cancel Order";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // btnFeedback
            // 
            this.btnFeedback.Location = new System.Drawing.Point(614, 279);
            this.btnFeedback.Name = "btnFeedback";
            this.btnFeedback.Size = new System.Drawing.Size(107, 23);
            this.btnFeedback.TabIndex = 4;
            this.btnFeedback.Text = "Feedback";
            this.btnFeedback.UseVisualStyleBackColor = true;
            this.btnFeedback.Click += new System.EventHandler(this.btnFeedback_Click);
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.Location = new System.Drawing.Point(21, 401);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(44, 16);
            this.lblWallet.TabIndex = 5;
            this.lblWallet.Text = "label1";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(713, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 30);
            this.btnLogout.TabIndex = 6;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnTopUp
            // 
            this.btnTopUp.Location = new System.Drawing.Point(317, 394);
            this.btnTopUp.Name = "btnTopUp";
            this.btnTopUp.Size = new System.Drawing.Size(75, 32);
            this.btnTopUp.TabIndex = 7;
            this.btnTopUp.Text = "Top Up";
            this.btnTopUp.UseVisualStyleBackColor = true;
            this.btnTopUp.Click += new System.EventHandler(this.btnTopUp_Click);
            // 
            // lblTopUp
            // 
            this.lblTopUp.AutoSize = true;
            this.lblTopUp.Location = new System.Drawing.Point(176, 376);
            this.lblTopUp.Name = "lblTopUp";
            this.lblTopUp.Size = new System.Drawing.Size(140, 16);
            this.lblTopUp.TabIndex = 8;
            this.lblTopUp.Text = "Type amount to top up";
            // 
            // txtTopUpAmount
            // 
            this.txtTopUpAmount.Location = new System.Drawing.Point(179, 402);
            this.txtTopUpAmount.Name = "txtTopUpAmount";
            this.txtTopUpAmount.Size = new System.Drawing.Size(100, 22);
            this.txtTopUpAmount.TabIndex = 9;
            // 
            // lstFeedback
            // 
            this.lstFeedback.FormattingEnabled = true;
            this.lstFeedback.ItemHeight = 16;
            this.lstFeedback.Location = new System.Drawing.Point(418, 317);
            this.lstFeedback.Name = "lstFeedback";
            this.lstFeedback.Size = new System.Drawing.Size(342, 100);
            this.lstFeedback.TabIndex = 10;
            this.lstFeedback.SelectedIndexChanged += new System.EventHandler(this.lstFeedback_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Menu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(425, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Your Order\'s";
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstFeedback);
            this.Controls.Add(this.txtTopUpAmount);
            this.Controls.Add(this.lblTopUp);
            this.Controls.Add(this.btnTopUp);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblWallet);
            this.Controls.Add(this.btnFeedback);
            this.Controls.Add(this.btnCancelOrder);
            this.Controls.Add(this.btnOrder);
            this.Controls.Add(this.lstOrders);
            this.Controls.Add(this.lstMenu);
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
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnTopUp;
        private System.Windows.Forms.Label lblTopUp;
        private System.Windows.Forms.TextBox txtTopUpAmount;
        private System.Windows.Forms.ListBox lstFeedback;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}