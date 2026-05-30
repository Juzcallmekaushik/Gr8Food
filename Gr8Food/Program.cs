using System;
using System.Windows.Forms;

namespace Gr8Food
{
    public class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Database database = new Database();
                database.InitializeDatabase();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "The application could not connect to SQL Server.\n\n" +
                    "Please ensure SQL Server is running or update the connection string in App.config.\n\n" +
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
