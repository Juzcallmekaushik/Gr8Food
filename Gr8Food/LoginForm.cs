using System;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class LoginForm : Form
    {
        private readonly AppRepository _repository = new AppRepository();

        public LoginForm()
        {
            InitializeComponent();
            UIStyler.ApplyPageTheme(this, UIStyler.LoginTheme);
            AcceptButton = btnLogin;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Text = "Gr8Food Management System";
            lblTitle.Visible = true;
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

            User user = _repository.Authenticate(username, password);
            if (user == null)
            {
                MessageBox.Show("Invalid login. Please check your username and password.");
                return;
            }

            AppSession.CurrentUser = user;

            Form destinationForm;
            switch (user.Role)
            {
                case DomainRules.RoleAdmin:
                    destinationForm = new AdminForm();
                    break;
                case DomainRules.RoleManager:
                    destinationForm = new ManagerForm();
                    break;
                case DomainRules.RoleChef:
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

        private void picLoginImage_Click(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblUsername_Click(object sender, EventArgs e)
        {

        }
    }
}
