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
            UIStyler.ApplyTheme(this, "Admin Dashboard", "Manage users and review the monthly sales activity.");
            Text = "Admin Dashboard";
            btnViewReport.Click += btnViewReport_Click;
            dtFilter.Format = DateTimePickerFormat.Custom;
            dtFilter.CustomFormat = "MMMM yyyy";
            dtFilter.ShowUpDown = true;
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
            LoadReport();
        }

        private void LoadRoleOptions()
        {
            cmbRole.Items.Clear();
            cmbRole.Items.AddRange(new object[] { "Admin", "Manager", "Chef", "Customer" });
            cmbRole.SelectedIndex = 3;

            cmbEditRole.Items.Clear();
            cmbEditRole.Items.AddRange(new object[] { "Admin", "Manager", "Chef", "Customer" });
        }

        private void LoadCategories()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(new object[] { "All", "Breakfast", "Lunch", "Dinner", "Snacks", "Drinks" });
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
            List<User> chefs = AppRepository.GetUsersByRole("Chef");
            object currentSelection = cmbChef.SelectedItem;

            cmbChef.Items.Clear();
            cmbChef.Items.Add("All");
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

        private void LoadReport()
        {
            int? chefUserId = null;
            User selectedChef = cmbChef.SelectedItem as User;
            if (selectedChef != null)
            {
                chefUserId = selectedChef.UserId;
            }

            string category = cmbCategory.SelectedItem == null ? "All" : cmbCategory.SelectedItem.ToString();
            lstReport.DataSource = null;
            lstReport.DataSource = AppRepository.GetSalesReport(dtFilter.Value.Month, dtFilter.Value.Year, chefUserId, category);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            string username = txtNewUsername.Text.Trim();
            string password = txtNewPassword.Text.Trim();
            string role = Convert.ToString(cmbRole.SelectedItem);
            string fullName = txtFullName.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(role) ||
                string.IsNullOrWhiteSpace(fullName))
            {
                MessageBox.Show("Please fill in full name, username, password, and role.");
                return;
            }

            if (AppRepository.UsernameExists(username, null))
            {
                MessageBox.Show("Username already exists.");
                return;
            }

            AppRepository.AddUser(username, fullName, password, role);
            MessageBox.Show("User added successfully.");
            txtFullName.Clear();
            txtNewUsername.Clear();
            txtNewPassword.Clear();
            cmbRole.SelectedIndex = 3;
            RefreshData();
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

            MessageBox.Show("User deleted successfully.");
            RefreshData();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            User selectedUser = lstUsers.SelectedItem as User;
            if (selectedUser == null)
            {
                return;
            }

            string password = txtEditPassword.Text.Trim();
            string role = Convert.ToString(cmbEditRole.SelectedItem);

            if (string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(role))
            {
                MessageBox.Show("Please provide a password and role to update the selected user.");
                return;
            }

            AppRepository.UpdateUserByAdmin(selectedUser.UserId, password, role);
            MessageBox.Show("User updated successfully.");
            RefreshData();
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        private void lstUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            User user = lstUsers.SelectedItem as User;
            if (user == null)
            {
                return;
            }

            txtEditPassword.Text = user.Password;
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
