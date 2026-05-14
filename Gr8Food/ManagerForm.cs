using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class ManagerForm : Form
    {
        private List<Feedback> _feedback = new List<Feedback>();

        public ManagerForm()
        {
            InitializeComponent();
            Text = "Manager Dashboard";
            dtpWalletFilter.Format = DateTimePickerFormat.Custom;
            dtpWalletFilter.CustomFormat = "MMMM yyyy";
            dtpWalletFilter.ShowUpDown = true;
            lstFeedback.SelectedIndexChanged += lstFeedback_SelectedIndexChanged;
            UIStyler.ApplyPageTheme(this, UIStyler.ManagerTheme);

            if (UIStyler.IsInDesignMode(this))
            {
                return;
            }

            Setup();
        }

        private void Setup()
        {
            LoadFeedback();
            LoadCustomers();
            LoadWallet();
        }

        private void LoadFeedback()
        {
            _feedback = AppRepository.GetAllFeedback();
            lstFeedback.DataSource = null;
            lstFeedback.DataSource = _feedback;
        }

        private void LoadCustomers()
        {
            List<User> customers = AppRepository.GetUsersByRole(DomainRules.RoleCustomer);
            cmbCustomer.Items.Clear();
            cmbCustomer.Items.Add("All");
            foreach (User customer in customers)
            {
                cmbCustomer.Items.Add(customer);
            }

            cmbCustomer.SelectedIndex = 0;
        }

        private void LoadWallet()
        {
            int? customerUserId = null;
            User selectedCustomer = cmbCustomer.SelectedItem as User;
            if (selectedCustomer != null)
            {
                customerUserId = selectedCustomer.UserId;
            }

            lstWallet.DataSource = null;
            lstWallet.DataSource = AppRepository.GetWalletTransactions(customerUserId, dtpWalletFilter.Value.Month, dtpWalletFilter.Value.Year);
        }

        private void btnReply_Click(object sender, EventArgs e)
        {
            Feedback feedback = lstFeedback.SelectedItem as Feedback;
            if (feedback == null)
            {
                return;
            }

            if (!string.IsNullOrWhiteSpace(feedback.Reply))
            {
                DialogResult overwriteReply = MessageBox.Show(
                    "This feedback already has a reply. Do you want to replace it?",
                    "Replace Reply",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (overwriteReply != DialogResult.Yes)
                {
                    return;
                }
            }

            string reply = txtReply.Text.Trim();
            if (string.IsNullOrWhiteSpace(reply))
            {
                MessageBox.Show("Please enter a reply before saving.");
                return;
            }

            try
            {
                AppRepository.ReplyToFeedback(feedback.FeedbackId, reply);
                MessageBox.Show("Reply sent successfully.");
                txtReply.Clear();
                LoadFeedback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFilterWallet_Click(object sender, EventArgs e)
        {
            LoadWallet();
        }

        private void lstFeedback_SelectedIndexChanged(object sender, EventArgs e)
        {
            Feedback feedback = lstFeedback.SelectedItem as Feedback;
            if (feedback != null)
            {
                txtReply.Text = feedback.Reply;
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
    }
}
