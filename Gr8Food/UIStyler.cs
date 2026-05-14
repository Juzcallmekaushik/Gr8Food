using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gr8Food
{
    public static class UIStyler
    {
        private static readonly Color Danger = Color.FromArgb(181, 64, 64);
        private static readonly Color DefaultText = Color.FromArgb(43, 43, 43);

        public sealed class PageTheme
        {
            public Color Background { get; private set; }
            public Color Surface { get; private set; }
            public Color Primary { get; private set; }
            public Color Secondary { get; private set; }
            public Color Text { get; private set; }
            public Color ButtonText { get; private set; }

            private PageTheme(Color background, Color surface, Color primary, Color secondary, Color text, Color buttonText)
            {
                Background = background;
                Surface = surface;
                Primary = primary;
                Secondary = secondary;
                Text = text;
                ButtonText = buttonText;
            }

            public static PageTheme Create(Color background, Color surface, Color primary, Color secondary)
            {
                return new PageTheme(background, surface, primary, secondary, DefaultText, Color.White);
            }
        }

        public static readonly PageTheme LoginTheme = PageTheme.Create(
            Color.FromArgb(244, 239, 232),
            Color.FromArgb(255, 252, 248),
            Color.FromArgb(123, 55, 42),
            Color.FromArgb(211, 132, 89));

        public static readonly PageTheme AdminTheme = PageTheme.Create(
            Color.FromArgb(238, 243, 247),
            Color.FromArgb(250, 253, 255),
            Color.FromArgb(34, 77, 122),
            Color.FromArgb(91, 140, 179));

        public static readonly PageTheme CustomerTheme = PageTheme.Create(
            Color.FromArgb(247, 242, 232),
            Color.FromArgb(255, 252, 245),
            Color.FromArgb(174, 86, 42),
            Color.FromArgb(70, 139, 108));

        public static readonly PageTheme ChefTheme = PageTheme.Create(
            Color.FromArgb(241, 247, 239),
            Color.FromArgb(250, 255, 248),
            Color.FromArgb(47, 108, 76),
            Color.FromArgb(205, 117, 55));

        public static readonly PageTheme ManagerTheme = PageTheme.Create(
            Color.FromArgb(242, 240, 248),
            Color.FromArgb(252, 251, 255),
            Color.FromArgb(88, 70, 134),
            Color.FromArgb(73, 139, 160));

        public static readonly PageTheme ProfileTheme = PageTheme.Create(
            Color.FromArgb(239, 246, 244),
            Color.FromArgb(250, 255, 254),
            Color.FromArgb(36, 111, 105),
            Color.FromArgb(95, 153, 145));

        public static readonly PageTheme FeedbackTheme = PageTheme.Create(
            Color.FromArgb(250, 243, 238),
            Color.FromArgb(255, 252, 249),
            Color.FromArgb(168, 75, 67),
            Color.FromArgb(221, 132, 95));

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
            ApplyPageTheme(form, LoginTheme);
        }

        public static void ApplyPageTheme(Form form, PageTheme theme)
        {
            if (form == null || theme == null)
            {
                return;
            }

            form.SuspendLayout();
            form.BackColor = theme.Background;
            form.ForeColor = theme.Text;
            form.StartPosition = FormStartPosition.CenterScreen;
            StyleControls(form.Controls, theme);
            form.ResumeLayout();
        }

        public static void ApplyPageAccent(Form form, Control control, PageTheme theme)
        {
            if (form == null || control == null || theme == null)
            {
                return;
            }

            control.BackColor = theme.Primary;
            control.ForeColor = theme.ButtonText;
        }

        private static void StyleControls(Control.ControlCollection controls, PageTheme theme)
        {
            foreach (Control control in controls)
            {
                Button button = control as Button;
                TextBox textBox = control as TextBox;
                ListBox listBox = control as ListBox;
                ComboBox comboBox = control as ComboBox;
                DateTimePicker dateTimePicker = control as DateTimePicker;
                CheckBox checkBox = control as CheckBox;
                Label label = control as Label;

                if (button != null)
                {
                    StyleButton(button, theme);
                }
                else if (textBox != null)
                {
                    textBox.BorderStyle = BorderStyle.FixedSingle;
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = theme.Text;
                    if (textBox.Multiline)
                    {
                        textBox.ScrollBars = ScrollBars.Vertical;
                    }
                }
                else if (listBox != null)
                {
                    listBox.BackColor = theme.Surface;
                    listBox.ForeColor = theme.Text;
                    listBox.BorderStyle = BorderStyle.FixedSingle;
                    listBox.IntegralHeight = false;
                }
                else if (comboBox != null)
                {
                    comboBox.BackColor = Color.White;
                    comboBox.ForeColor = theme.Text;
                    comboBox.FlatStyle = FlatStyle.Flat;
                }
                else if (dateTimePicker != null)
                {
                    dateTimePicker.CalendarMonthBackground = Color.White;
                    dateTimePicker.CalendarForeColor = theme.Text;
                }
                else if (checkBox != null)
                {
                    checkBox.ForeColor = theme.Text;
                }
                else if (label != null)
                {
                    label.ForeColor = theme.Text;
                }

                if (control.HasChildren)
                {
                    StyleControls(control.Controls, theme);
                }
            }
        }

        private static void StyleButton(Button button, PageTheme theme)
        {
            string text = button.Text == null ? string.Empty : button.Text.ToLowerInvariant();
            Color backColor = theme.Primary;
            Color foreColor = theme.ButtonText;

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
                backColor = theme.Secondary;
            }
            else if (text.Contains("profile"))
            {
                backColor = theme.Surface;
                foreColor = Color.FromArgb(56, 41, 15);
            }

            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backColor;
            button.ForeColor = foreColor;
            button.Cursor = Cursors.Hand;
        }
    }
}
