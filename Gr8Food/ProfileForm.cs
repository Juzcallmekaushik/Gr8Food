using System;
using System.Windows.Forms;

namespace Gr8Food
{
    public partial class ProfileForm : Form
    {
        private readonly AppRepository _repository = new AppRepository();

        public ProfileForm()
        {
            InitializeComponent();
            UIStyler.ApplyPageTheme(this, UIStyler.ProfileTheme);
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            if (AppSession.CurrentUser == null)
            {
                Close();
                return;
            }

            txtUsername.Text = AppSession.CurrentUser.Username;
            txtFullName.Text = AppSession.CurrentUser.FullName;
            txtRole.Text = AppSession.CurrentUser.Role;
            txtPassword.Clear();
            txtConfirm.Clear();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirm.Text.Trim();

            if (!string.Equals(password, confirmPassword, StringComparison.Ordinal))
            {
                MessageBox.Show("Password and confirm password must match.");
                return;
            }

            try
            {
                if (_repository.UsernameExists(username, AppSession.CurrentUser.UserId))
                {
                    MessageBox.Show("That username is already being used by another account.");
                    return;
                }

                AppSession.CurrentUser = _repository.UpdateOwnProfile(
                    AppSession.CurrentUser.UserId,
                    username,
                    fullName,
                    password);

                MessageBox.Show("Profile updated successfully.");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
