namespace Gr8Food
{
    partial class ChefForm
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
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.btnMarkProgress = new System.Windows.Forms.Button();
            this.btnMarkComplete = new System.Windows.Forms.Button();
            this.btnEditMenu = new System.Windows.Forms.Button();
            this.btnDeleteMenu = new System.Windows.Forms.Button();
            this.chkAvailable = new System.Windows.Forms.CheckBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtMenuName = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblMenuName = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstMenu
            // 
            this.lstMenu.FormattingEnabled = true;
            this.lstMenu.Location = new System.Drawing.Point(273, 43);
            this.lstMenu.Margin = new System.Windows.Forms.Padding(2);
            this.lstMenu.Name = "lstMenu";
            this.lstMenu.Size = new System.Drawing.Size(211, 186);
            this.lstMenu.TabIndex = 0;
            this.lstMenu.Click += new System.EventHandler(this.lstMenu_SelectedIndexChanged);
            this.lstMenu.SelectedIndexChanged += new System.EventHandler(this.lstMenu_SelectedIndexChanged);
            // 
            // lstOrders
            // 
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.Location = new System.Drawing.Point(9, 43);
            this.lstOrders.Margin = new System.Windows.Forms.Padding(2);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(253, 251);
            this.lstOrders.TabIndex = 1;
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.Location = new System.Drawing.Point(521, 84);
            this.btnAddMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(80, 19);
            this.btnAddMenu.TabIndex = 2;
            this.btnAddMenu.Text = "Add Menu";
            this.btnAddMenu.UseVisualStyleBackColor = true;
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // btnMarkProgress
            // 
            this.btnMarkProgress.Location = new System.Drawing.Point(9, 304);
            this.btnMarkProgress.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkProgress.Name = "btnMarkProgress";
            this.btnMarkProgress.Size = new System.Drawing.Size(101, 24);
            this.btnMarkProgress.TabIndex = 3;
            this.btnMarkProgress.Text = "Mark In Progress";
            this.btnMarkProgress.UseVisualStyleBackColor = true;
            this.btnMarkProgress.Click += new System.EventHandler(this.btnMarkProgress_Click);
            // 
            // btnMarkComplete
            // 
            this.btnMarkComplete.Location = new System.Drawing.Point(161, 304);
            this.btnMarkComplete.Margin = new System.Windows.Forms.Padding(2);
            this.btnMarkComplete.Name = "btnMarkComplete";
            this.btnMarkComplete.Size = new System.Drawing.Size(101, 24);
            this.btnMarkComplete.TabIndex = 4;
            this.btnMarkComplete.Text = "Mark Complete";
            this.btnMarkComplete.UseVisualStyleBackColor = true;
            this.btnMarkComplete.Click += new System.EventHandler(this.btnMarkComplete_Click);
            // 
            // btnEditMenu
            // 
            this.btnEditMenu.Location = new System.Drawing.Point(521, 118);
            this.btnEditMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnEditMenu.Name = "btnEditMenu";
            this.btnEditMenu.Size = new System.Drawing.Size(80, 19);
            this.btnEditMenu.TabIndex = 5;
            this.btnEditMenu.Text = "Edit Menu";
            this.btnEditMenu.UseVisualStyleBackColor = true;
            this.btnEditMenu.Click += new System.EventHandler(this.btnEditMenu_Click);
            // 
            // btnDeleteMenu
            // 
            this.btnDeleteMenu.Location = new System.Drawing.Point(521, 152);
            this.btnDeleteMenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnDeleteMenu.Name = "btnDeleteMenu";
            this.btnDeleteMenu.Size = new System.Drawing.Size(80, 19);
            this.btnDeleteMenu.TabIndex = 6;
            this.btnDeleteMenu.Text = "Delete Menu";
            this.btnDeleteMenu.UseVisualStyleBackColor = true;
            this.btnDeleteMenu.Click += new System.EventHandler(this.btnDeleteMenu_Click);
            // 
            // chkAvailable
            // 
            this.chkAvailable.AutoSize = true;
            this.chkAvailable.Location = new System.Drawing.Point(532, 190);
            this.chkAvailable.Margin = new System.Windows.Forms.Padding(2);
            this.chkAvailable.Name = "chkAvailable";
            this.chkAvailable.Size = new System.Drawing.Size(69, 17);
            this.chkAvailable.TabIndex = 7;
            this.chkAvailable.Text = "Available";
            this.chkAvailable.UseVisualStyleBackColor = true;
            this.chkAvailable.CheckedChanged += new System.EventHandler(this.chkAvailable_CheckedChanged);
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(509, 221);
            this.cmbCategory.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(92, 21);
            this.cmbCategory.TabIndex = 9;
            // 
            // txtMenuName
            // 
            this.txtMenuName.Location = new System.Drawing.Point(375, 246);
            this.txtMenuName.Margin = new System.Windows.Forms.Padding(2);
            this.txtMenuName.Name = "txtMenuName";
            this.txtMenuName.Size = new System.Drawing.Size(76, 20);
            this.txtMenuName.TabIndex = 10;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(309, 274);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(2);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(76, 20);
            this.txtPrice.TabIndex = 11;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtPrice_TextChanged);
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.Location = new System.Drawing.Point(270, 253);
            this.lblMenuName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(101, 13);
            this.lblMenuName.TabIndex = 12;
            this.lblMenuName.Text = "Food /Drinks name:";
            this.lblMenuName.Click += new System.EventHandler(this.lblMenuName_Click);
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(271, 281);
            this.lblPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(34, 13);
            this.lblPrice.TabIndex = 13;
            this.lblPrice.Text = "Price:";
            this.lblPrice.Click += new System.EventHandler(this.lblPrice_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(482, 11);
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
            this.btnLogout.Location = new System.Drawing.Point(545, 11);
            this.btnLogout.Margin = new System.Windows.Forms.Padding(2);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(56, 22);
            this.btnLogout.TabIndex = 23;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // ChefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 366);
            this.Controls.Add(this.btnProfile);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblMenuName);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtMenuName);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.chkAvailable);
            this.Controls.Add(this.btnDeleteMenu);
            this.Controls.Add(this.btnEditMenu);
            this.Controls.Add(this.btnMarkComplete);
            this.Controls.Add(this.btnMarkProgress);
            this.Controls.Add(this.btnAddMenu);
            this.Controls.Add(this.lstOrders);
            this.Controls.Add(this.lstMenu);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ChefForm";
            this.Text = "ChefForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstMenu;
        private System.Windows.Forms.ListBox lstOrders;
        private System.Windows.Forms.Button btnAddMenu;
        private System.Windows.Forms.Button btnMarkProgress;
        private System.Windows.Forms.Button btnMarkComplete;
        private System.Windows.Forms.Button btnEditMenu;
        private System.Windows.Forms.Button btnDeleteMenu;
        private System.Windows.Forms.CheckBox chkAvailable;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtMenuName;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblMenuName;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnLogout;
    }
}
