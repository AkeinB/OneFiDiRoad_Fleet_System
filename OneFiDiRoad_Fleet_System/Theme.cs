using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneFiDiRoad_Fleet_System
{
    internal class Theme
    {
        // This class defines a color theme for the application, including background colors, accent colors, text colors, button colors, and border colors.
        public static class ColorTheme
        {
            // Backgrounds
            public static Color MainBackground = Color.FromArgb(49, 51, 56);
            public static Color SecondaryBackground = Color.FromArgb(33, 35, 39);
            public static Color SecondaryBackground2 = Color.FromArgb(43, 45, 49);
            public static Color TertiaryBackground = Color.FromArgb(30, 31, 34);

            // Accent
            public static Color Primary = Color.FromArgb(88, 101, 242);

            // Text
            public static Color TextPrimary = Color.FromArgb(255, 255, 255);
            public static Color TextSecondary = Color.FromArgb(181, 186, 193);

            // Buttons
            public static Color ButtonNormal = Color.FromArgb(88, 101, 242);
            public static Color ButtonHover = Color.FromArgb(71, 82, 196);
            public static Color ButtonPressed = Color.FromArgb(58, 66, 156);

            // Borders
            public static Color Border = Color.FromArgb(63, 66, 72);
        }

        public static void ApplyTheme(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                
                // Form
                if (control is Panel)
                {
                    control.BackColor = ColorTheme.SecondaryBackground;
                }

                // Labels
                if (control is Label)
                {
                    control.ForeColor = ColorTheme.TextPrimary;
                    control.BackColor = Color.Transparent;
                }

                // TextBoxes
                if (control is TextBox textbox)
                {
                    textbox.BackColor = ColorTheme.TertiaryBackground;
                    textbox.ForeColor = ColorTheme.TextPrimary;
                    textbox.BorderStyle = BorderStyle.FixedSingle;
                }

                // Buttons
                if (control is Button btn)
                {
                    btn.BackColor = ColorTheme.ButtonNormal;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;

                    btn.MouseEnter += (s, e) =>
                        btn.BackColor = ColorTheme.ButtonHover;

                    btn.MouseLeave += (s, e) =>
                        btn.BackColor = ColorTheme.ButtonNormal;

                    btn.MouseDown += (s, e) =>
                        btn.BackColor = ColorTheme.ButtonPressed;

                    btn.MouseUp += (s, e) =>
                        btn.BackColor = ColorTheme.ButtonHover;
                }

                // Recursive call
                if (control.HasChildren)
                    ApplyTheme(control);
            }
        }

       
    }
}
