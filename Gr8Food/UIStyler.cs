using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public static class UIStyler
    {
        private static readonly Color Background = Color.FromArgb(247, 243, 236);
        private static readonly Color Surface = Color.FromArgb(255, 252, 248);
        private static readonly Color Header = Color.FromArgb(38, 70, 55);
        private static readonly Color Accent = Color.FromArgb(230, 111, 81);
        private static readonly Color AccentAlt = Color.FromArgb(42, 157, 143);
        private static readonly Color Danger = Color.FromArgb(181, 64, 64);
        private static readonly Color Text = Color.FromArgb(43, 43, 43);
        private static readonly Color Muted = Color.FromArgb(102, 102, 102);

        public static void ApplyTheme(Form form, string title, string subtitle)
        {
            if (form.Controls.ContainsKey("__appHeader"))
            {
                return;
            }

            form.SuspendLayout();
            form.BackColor = Background;
            form.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            form.ForeColor = Text;
            form.StartPosition = FormStartPosition.CenterScreen;

            const int headerHeight = 82;
            List<Control> controls = new List<Control>();
            foreach (Control control in form.Controls)
            {
                controls.Add(control);
            }

            foreach (Control control in controls)
            {
                control.Location = new Point(control.Left, control.Top + headerHeight);
            }

            form.ClientSize = new Size(form.ClientSize.Width, form.ClientSize.Height + headerHeight);

            Panel headerPanel = new Panel();
            headerPanel.Name = "__appHeader";
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Height = headerHeight;
            headerPanel.BackColor = Header;

            Label lblTitle = new Label();
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(26, 18);
            lblTitle.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.White;
            lblTitle.Text = title;

            Label lblSubtitle = new Label();
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(29, 50);
            lblSubtitle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            lblSubtitle.ForeColor = Color.FromArgb(223, 236, 230);
            lblSubtitle.Text = subtitle;

            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);
            form.Controls.Add(headerPanel);
            headerPanel.BringToFront();

            StyleControls(form.Controls);
            form.ResumeLayout();
        }

        private static void StyleControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Name == "__appHeader")
                {
                    continue;
                }

                if (control is Button button)
                {
                    StyleButton(button);
                }
                else if (control is TextBox textBox)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Text;
                    if (textBox.Multiline)
                    {
                        textBox.ScrollBars = ScrollBars.Vertical;
                    }
                }
                else if (control is ListBox listBox)
                {
                    listBox.BackColor = Surface;
                    listBox.ForeColor = Text;
                    listBox.BorderStyle = BorderStyle.FixedSingle;
                    listBox.IntegralHeight = false;
                }
                else if (control is ComboBox comboBox)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Text;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (control is DateTimePicker dateTimePicker)
                {
                    dateTimePicker.CalendarMonthBackground = Color.White;
                    dateTimePicker.CalendarForeColor = Text;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.ForeColor = Text;
                }
                else if (control is Label label)
                {
                    label.ForeColor = Text;
                    label.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
                }

                if (control.HasChildren)
                {
                    StyleControls(control.Controls);
                }
            }
        }

        private static void StyleButton(Button button)
        {
            string text = button.Text == null ? string.Empty : button.Text.ToLowerInvariant();
            Color backColor = AccentAlt;
            Color foreColor = Color.White;

            if (text.Contains("logout") || text.Contains("cancel"))
            {
                backColor = Color.FromArgb(132, 41, 41);
            }
            else if (text.Contains("delete"))
            {
                backColor = Danger;
            }
            else if (text.Contains("filter") || text.Contains("reply"))
            {
                backColor = Accent;
            }
            else if (text.Contains("profile"))
            {
                backColor = Color.FromArgb(233, 196, 106);
                foreColor = Color.FromArgb(56, 41, 15);
            }

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button.Cursor = Cursors.Hand;
            button.Height = button.Height < 32 ? 32 : button.Height;
        }
    }
}
