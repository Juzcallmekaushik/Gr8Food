using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class AdminForm : Form
    {
        private List<User> _users = new List<User>();

        public AdminForm()
        {
            InitializeComponent();
            UIStyler.ApplyPageTheme(this, UIStyler.AdminTheme);
            Text = "Admin Dashboard";
            btnViewReport.Click += btnViewReport_Click;
            dtpReportFilter.Format = DateTimePickerFormat.Custom;
            dtpReportFilter.CustomFormat = "MMMM yyyy";
            dtpReportFilter.ShowUpDown = true;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadRoleOptions();
            LoadCategories();
            RefreshData();
        }

        private void RefreshData()
        {
            LoadUsers();
            LoadChefs();
            LoadFullReport();
        }

        private void LoadRoleOptions()
        {
            cmbNewRole.Items.Clear();
            cmbNewRole.Items.AddRange(DomainRules.Roles);
            cmbNewRole.SelectedItem = DomainRules.RoleCustomer;

            cmbEditRole.Items.Clear();
            cmbEditRole.Items.AddRange(DomainRules.Roles);
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(DomainRules.ReportCategories);
            cmbCategory.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            _users = AppRepository.GetAllUsers();
            lstUsers.DataSource = null;
            lstUsers.DataSource = _users;
        }

        private void LoadChefs()
        {
            List<User> chefs = AppRepository.GetUsersByRole(DomainRules.RoleChef);
            object currentSelection = cmbChef.SelectedItem;

            cmbChef.Items.Clear();
            cmbChef.Items.Add(DomainRules.CategoryAll);
            foreach (User chef in chefs)
            {
                cmbChef.Items.Add(chef);
            }

            if (currentSelection != null && cmbChef.Items.Contains(currentSelection))
            {
                cmbChef.SelectedItem = currentSelection;
            }
            else
            {
                cmbChef.SelectedIndex = 0;
            }
        }

        private void LoadFullReport()
        {
            cmbCategory.SelectedIndex = 0;
            cmbChef.SelectedIndex = 0;
            LoadReport(false);
        }

        private void LoadFilteredReport()
        {
            LoadReport(true);
        }

        private void LoadReport(bool applyFilters)
        {
            int? chefUserId = null;
            string category = DomainRules.CategoryAll;

            if (applyFilters)
            {
                User selectedChef = cmbChef.SelectedItem as User;
                if (selectedChef != null)
                {
                    chefUserId = selectedChef.UserId;
                }

                category = cmbCategory.SelectedItem == null ? DomainRules.CategoryAll : cmbCategory.SelectedItem.ToString();
            }

            lstReport.DataSource = null;
            int? month = applyFilters ? (int?)dtpReportFilter.Value.Month : null;
            int? year = applyFilters ? (int?)dtpReportFilter.Value.Year : null;

            lstReport.DataSource = AppRepository.GetSalesReport(month, year, chefUserId, category);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text.Trim();
            string role = Convert.ToString(cmbNewRole.SelectedItem);
            string fullName = txtNewFullName.Text.Trim();

            try
            {
                if (AppRepository.UsernameExists(username, null))
                {
                    MessageBox.Show("Username already exists.");
                    return;
                }

                AppRepository.AddUser(username, fullName, password, role);
                MessageBox.Show("User added successfully.");
                txtNewFullName.Clear();
                txtNewUsername.Clear();
                txtNewPassword.Clear();
                cmbNewRole.SelectedItem = DomainRules.RoleCustomer;
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            User selectedUser = lstUsers.SelectedItem as User;
            if (selectedUser == null)
            {
                return;
            }

            if (selectedUser.UserId == AppSession.CurrentUser.UserId)
            {
                MessageBox.Show("You cannot delete your own account while logged in.");
                return;
            }

            string reason;
            if (!AppRepository.DeleteUser(selectedUser.UserId, out reason))
            {
                MessageBox.Show(reason);
                return;
            }

            MessageBox.Show("User removed successfully.");
            RefreshData();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            User selectedUser = lstUsers.SelectedItem as User;
            if (selectedUser == null)
            {
                return;
            }

            string username = txtEditUsername.Text.Trim();
            string fullName = txtEditFullName.Text.Trim();
            string password = txtEditPassword.Text.Trim();
            string role = Convert.ToString(cmbEditRole.SelectedItem);

            try
            {
                if (AppRepository.UsernameExists(username, selectedUser.UserId))
                {
                    MessageBox.Show("That username is already being used by another account.");
                    return;
                }

                AppRepository.UpdateUserByAdmin(selectedUser.UserId, username, fullName, password, role);
                MessageBox.Show("User updated successfully.");
                RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadFilteredReport();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            LoadFullReport();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = lstUsers.SelectedItem as User;
            if (user == null)
            {
                return;
            }

            txtEditUsername.Text = user.Username;
            txtEditFullName.Text = user.FullName;
            txtEditPassword.Clear();
            cmbEditRole.SelectedItem = user.Role;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            AppSession.IsLoggingOut = true;
            Close();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            using (ProfileForm profileForm = new ProfileForm())
            {
                profileForm.ShowDialog(this);
            }
        }
    }
}
