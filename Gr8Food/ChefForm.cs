using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class ChefForm : Form
    {
        private List<MenuItem> _menuItems = new List<MenuItem>();
        private List<Order> _orders = new List<Order>();

        public ChefForm()
        {
            InitializeComponent();
            Text = "Chef Dashboard";
            AddProfileButton();
            UIStyler.ApplyTheme(this, "Chef Dashboard", "Manage menu items and keep customer orders moving.");
            Setup();
        }

        private void AddProfileButton()
        {
            Button btnProfile = new Button();
            btnProfile.Name = "btnProfile";
            btnProfile.Text = "Profile";
            btnProfile.Size = new System.Drawing.Size(75, 23);
            btnProfile.Location = new System.Drawing.Point(608, 28);
            btnProfile.Click += btnProfile_Click;
            Controls.Add(btnProfile);
            btnProfile.BringToFront();
        }

        private void Setup()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.AddRange(DomainRules.MenuCategories);
            cmbCategory.SelectedIndex = 0;
            LoadMenu();
            LoadOrders();
        }

        private void LoadMenu()
        {
            _menuItems = AppRepository.GetMenuForChef(AppSession.CurrentUser.UserId);
            lstMenu.DataSource = null;
            lstMenu.DataSource = _menuItems;
        }

        private void LoadOrders()
        {
            _orders = AppRepository.GetOrdersForChef(AppSession.CurrentUser.UserId);
            lstOrders.DataSource = null;
            lstOrders.DataSource = _orders;
        }

        private void btnAddMenu_Click(object sender, EventArgs e)
        {
            string name = txtMenuName.Text.Trim();
            decimal price;

            if (!decimal.TryParse(txtPrice.Text.Trim(), out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            try
            {
                AppRepository.AddMenuItem(AppSession.CurrentUser.UserId, name, cmbCategory.Text, price, chkAvailable.Checked);
                ClearMenuInputs();
                LoadMenu();
                MessageBox.Show("Menu item added successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditMenu_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = lstMenu.SelectedItem as MenuItem;
            if (menuItem == null)
            {
                return;
            }

            decimal price;
            if (!decimal.TryParse(txtPrice.Text.Trim(), out price))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            try
            {
                AppRepository.UpdateMenuItem(menuItem.MenuItemId, AppSession.CurrentUser.UserId, txtMenuName.Text.Trim(), cmbCategory.Text, price, chkAvailable.Checked);
                MessageBox.Show("Menu item updated successfully.");
                LoadMenu();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteMenu_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = lstMenu.SelectedItem as MenuItem;
            if (menuItem == null)
            {
                return;
            }

            AppRepository.DeleteMenuItem(menuItem.MenuItemId, AppSession.CurrentUser.UserId);
            ClearMenuInputs();
            LoadMenu();
            MessageBox.Show("Menu item deleted successfully.");
        }

        private void lstMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            MenuItem menuItem = lstMenu.SelectedItem as MenuItem;
            if (menuItem == null)
            {
                return;
            }

            txtMenuName.Text = menuItem.Name;
            txtPrice.Text = menuItem.Price.ToString("0.00");
            cmbCategory.SelectedItem = menuItem.Category;
            chkAvailable.Checked = menuItem.IsAvailable;
        }

        private void btnMarkProgress_Click(object sender, EventArgs e)
        {
            Order order = lstOrders.SelectedItem as Order;
            if (order == null)
            {
                return;
            }

            if (!string.Equals(order.Status, DomainRules.OrderStatusPending, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Only pending orders can be marked as In Progress.");
                return;
            }

            AppRepository.UpdateOrderStatus(order.OrderId, AppSession.CurrentUser.UserId, DomainRules.OrderStatusPending, DomainRules.OrderStatusInProgress);
            LoadOrders();
            MessageBox.Show("Order marked as In Progress.");
        }

        private void btnMarkComplete_Click(object sender, EventArgs e)
        {
            Order order = lstOrders.SelectedItem as Order;
            if (order == null)
            {
                return;
            }

            if (!string.Equals(order.Status, DomainRules.OrderStatusInProgress, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Only In Progress orders can be marked as Completed.");
                return;
            }

            AppRepository.UpdateOrderStatus(order.OrderId, AppSession.CurrentUser.UserId, DomainRules.OrderStatusInProgress, DomainRules.OrderStatusCompleted);
            LoadOrders();
            MessageBox.Show("Order marked as Completed.");
        }

        private void ClearMenuInputs()
        {
            txtMenuName.Clear();
            txtPrice.Clear();
            chkAvailable.Checked = false;
            cmbCategory.SelectedIndex = 0;
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
