using System;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class FeedbackForm : Form
    {
        private readonly int _orderId;
        private readonly string _itemName;

        public FeedbackForm(int orderId, string itemName)
        {
            InitializeComponent();
            _orderId = orderId;
            _itemName = itemName;
            Text = "Send Feedback";
            UIStyler.ApplyTheme(this, "Send Feedback", "Share your dining experience for the completed order.");
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string message = txtFeedback.Text.Trim();
            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Please enter your feedback.");
                return;
            }

            try
            {
                AppRepository.AddFeedback(_orderId, AppSession.CurrentUser.UserId, message);
                MessageBox.Show(string.Format("Feedback for {0} submitted successfully.", _itemName));
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
