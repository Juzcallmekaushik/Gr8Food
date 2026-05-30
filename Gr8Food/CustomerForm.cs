using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class CustomerForm : Form
    {
        private readonly AppRepository _repository = new AppRepository();
        private List<MenuItem> _menuItems = new List<MenuItem>();
        private List<Order> _orders = new List<Order>();
        private List<Feedback> _feedback = new List<Feedback>();

        public CustomerForm()
        {
            InitializeComponent();
            Text = "Customer Dashboard";
            txtTopUpAmount.KeyPress += txtTopUpAmount_KeyPress;
            UIStyler.ApplyPageTheme(this, UIStyler.CustomerTheme);

            if (UIStyler.IsInDesignMode(this))
            {
                lblWallet.Text = "Customer Name\r\nWallet Balance: RM 0.00";
                return;
            }

            Setup();
        }

        private void Setup()
        {
            LoadMenu();
            LoadOrders();
            UpdateWallet();
            LoadFeedback();
        }

        private void LoadMenu()
        {
            _menuItems = _repository.GetAvailableMenu();
            lstMenu.DataSource = null;
            lstMenu.DataSource = _menuItems;
        }

        private void LoadOrders()
        {
            _orders = _repository.GetOrdersForCustomer(AppSession.CurrentUser.UserId);
            lstOrders.DataSource = null;
            lstOrders.DataSource = _orders;
        }

        private void LoadFeedback()
        {
            _feedback = _repository.GetFeedbackByCustomer(AppSession.CurrentUser.UserId);
            lstFeedback.DataSource = null;
            lstFeedback.DataSource = _feedback;
        }

        private void UpdateWallet()
        {
            AppSession.CurrentUser = _repository.GetUserById(AppSession.CurrentUser.UserId);
            lblWallet.Text = string.Format(
                "{0}\nWallet Balance: RM {1:0.00}",
                AppSession.CurrentUser.FullName,
                AppSession.CurrentUser.WalletBalance);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = lstMenu.SelectedItem as MenuItem;
            if (menuItem == null)
            {
                return;
            }

            try
            {
                _repository.PlaceOrder(AppSession.CurrentUser.UserId, menuItem.MenuItemId);
                AppSession.CurrentUser = _repository.GetUserById(AppSession.CurrentUser.UserId);
                MessageBox.Show("Order placed successfully.");
                Setup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            Order order = lstOrders.SelectedItem as Order;
            if (order == null)
            {
                return;
            }

            try
            {
                _repository.CancelOrder(order.OrderId, AppSession.CurrentUser.UserId);
                AppSession.CurrentUser = _repository.GetUserById(AppSession.CurrentUser.UserId);
                MessageBox.Show("Order cancelled and refund returned to the e-wallet.");
                Setup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            Order order = lstOrders.SelectedItem as Order;
            if (order == null)
            {
                return;
            }

            if (!string.Equals(order.Status, DomainRules.OrderStatusCompleted, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Feedback can only be sent after the order is completed.");
                return;
            }

            using (FeedbackForm feedbackForm = new FeedbackForm(order.OrderId, order.ItemName))
            {
                if (feedbackForm.ShowDialog(this) == DialogResult.OK)
                {
                    LoadFeedback();
                }
            }
        }

        private void btnTopUp_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (!decimal.TryParse(txtTopUpAmount.Text.Trim(), out amount))
            {
                MessageBox.Show("Please enter a valid top-up amount.");
                return;
            }

            try
            {
                _repository.TopUpWallet(AppSession.CurrentUser.UserId, amount);
                AppSession.CurrentUser = _repository.GetUserById(AppSession.CurrentUser.UserId);
                MessageBox.Show("Top up successful.");
                txtTopUpAmount.Clear();
                Setup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTopUpAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            if (e.KeyChar == '.' && txtTopUpAmount.Text.Contains("."))
            {
                e.Handled = true;
            }
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

        private void lstFeedback_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
