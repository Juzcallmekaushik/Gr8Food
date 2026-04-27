using System.ComponentModel;
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

        public static bool IsInDesignMode(Control control)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return true;
            }

            return control != null
                && control.Site != null
                && control.Site.DesignMode;
        }

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

                Button button = control as Button;
                TextBox textBox = control as TextBox;
                ListBox listBox = control as ListBox;
                ComboBox comboBox = control as ComboBox;
                DateTimePicker dateTimePicker = control as DateTimePicker;
                CheckBox checkBox = control as CheckBox;
                Label label = control as Label;

                if (button != null)
                {
                    StyleButton(button);
                }
                else if (textBox != null)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Text;
                    if (textBox.Multiline)
                    {
                        textBox.ScrollBars = ScrollBars.Vertical;
                    }
                }
                else if (listBox != null)
                {
                    listBox.BackColor = Surface;
                    listBox.ForeColor = Text;
                    listBox.BorderStyle = BorderStyle.FixedSingle;
                    listBox.IntegralHeight = false;
                }
                else if (comboBox != null)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = Text;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (dateTimePicker != null)
                {
                    dateTimePicker.CalendarMonthBackground = Color.White;
                    dateTimePicker.CalendarForeColor = Text;
                }
                else if (checkBox != null)
                {
                    checkBox.ForeColor = Text;
                }
                else if (label != null)
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
