using System;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            UIStyler.ApplyTheme(this, "Gr8Food", "Sign in to continue to the restaurant management system.");
            AcceptButton = btnLogin;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Text = "Gr8Food Management System";
            lblTitle.Visible = false;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            User user = AppRepository.Authenticate(username, password);
            if (user == null)
            {
                MessageBox.Show("Invalid login. Please check your username and password.");
                return;
            }

            AppSession.CurrentUser = user;

            Form destinationForm;
            switch (user.Role)
            {
                case "Admin":
                    destinationForm = new AdminForm();
                    break;
                case "Manager":
                    destinationForm = new ManagerForm();
                    break;
                case "Chef":
                    destinationForm = new ChefForm();
                    break;
                default:
                    destinationForm = new CustomerForm();
                    break;
            }

            Hide();
            destinationForm.FormClosed += DestinationForm_FormClosed;
            destinationForm.Show();
        }

        private void DestinationForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (AppSession.IsLoggingOut)
            {
                AppSession.IsLoggingOut = false;
                AppSession.CurrentUser = null;
                txtUsername.Clear();
                txtPassword.Clear();
                Show();
                Activate();
                return;
            }

            Close();
        }
    }
}
