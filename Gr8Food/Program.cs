using System;
using System.Windows.Forms;

namespace Gr8Food
{
    internal static class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Database.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The application could not connect to SQL Server LocalDB.\n\n" +
                    "Please ensure LocalDB is installed or update the connection string in App.config.\n\n" +
                    ex.Message,
                    "Database Setup Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new LoginForm());
        }
    }
}
