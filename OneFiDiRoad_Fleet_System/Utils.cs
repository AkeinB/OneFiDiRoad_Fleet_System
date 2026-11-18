using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;


namespace OneFiDiRoad_Fleet_System
{
    internal class Utils
    {
        public static Label animatedLabel;
        public static Label activeLabel;
        public static GroupBox activeGroupBox;
        public static Point originalLocation;
        public static Point targetLocation;
        public static bool growing;
        public static bool isHovering;
        public static Timer hoverTimer = new Timer();
        public static Timer hoverTimerGBs =  new Timer();
        public static System.Drawing.Color originalBackColor;
        public static System.Drawing.Color originalForeColor;
        public static System.Drawing.Color originalGroupBoxBackColor;

        // This method takes a password as input and returns its SHA256 hash as a hexadecimal string
        public static string HashPassword(string password)
        {
            SHA256 sha = SHA256.Create();

            //Convert the password to a byte array and hash it
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes(password));


            // Create a new StringBuilder to collect the bytes
            // and create a string
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

        // This method returns the SHA256 hash of the default password "Password@123" as a hexadecimal string
        public static string DefaultHashPassword()
        {
            SHA256 sha = SHA256.Create();

            //Convert the password to a byte array and hash it
            byte[] data = sha.ComputeHash(Encoding.UTF8.GetBytes("Password@123"));


            // Create a new StringBuilder to collect the bytes
            // and create a string
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }


        //==========================================================================================================================================================
        //Highlight and Animation helper functions

        // Highlight the label when hovered over
        public static void HighlightLabel(Label lbl)
        {
            originalBackColor = lbl.BackColor;
            originalForeColor = lbl.ForeColor;

            lbl.BackColor = System.Drawing.Color.Yellow;
            lbl.ForeColor = System.Drawing.Color.Black;
        }

        public static void RestoreLabel(Label lbl)
        {
            lbl.BackColor = originalBackColor;
            lbl.ForeColor = originalForeColor;
        }


        // Animate the label when hovered over
        public static void AnimateLabelStart( Label lbl)
        {
            animatedLabel = lbl;
            growing = true;
            hoverTimer.Start();
        }

        public static void AnimateLabelStop(Label lbl)
        {
            animatedLabel = lbl;
            growing = false;
            hoverTimer.Start();
        }

        // This method is called on each tick of the hoverTimer to animate the font size of the label
        public static void HoverTimer_TickLabels(object sender, EventArgs e)
        {
            // Animate the font size of the label
            float currentSize = animatedLabel.Font.Size;

            if (growing)
            {
                if (currentSize < 12f)
                {
                    animatedLabel.Font =
                        new Font(animatedLabel.Font.FontFamily,
                                 currentSize + 0.5f,
                                 FontStyle.Bold);
                }
                else
                {
                    hoverTimer.Stop();
                }
            }
            else
            {
                if (currentSize > 10f)
                {
                    animatedLabel.Font =
                        new Font(animatedLabel.Font.FontFamily,
                                 currentSize - 0.5f,
                                 FontStyle.Regular);
                }
                else
                {
                    hoverTimer.Stop();
                }
            }
        }
        // Animate the group box when hovered over
        public static void AnimateGroupBoxStart(GroupBox gb)
        {
            originalGroupBoxBackColor = gb.BackColor;
            originalLocation = gb.Location;

            gb.Location = new Point(
                gb.Location.X,
                gb.Location.Y - 5);

            isHovering = true;
            //gb.BackColor = System.Drawing.Color.LightYellow;
        }

        public static void AnimateGroupBoxStop(GroupBox gb)
        {
            activeGroupBox = gb;

            gb.Location = originalLocation;
            isHovering = false;
            //gb.BackColor = originalGroupBoxBackColor;
        }

        // this method is called on each tick of the hoverTimerGroups to animate the background color of the group box
        public static void HoverTimer_TickGroupBox(object sender, EventArgs e)
        {
            //
            originalLocation = activeGroupBox.Location;

            if (activeGroupBox == null)
                return;

            Point destination;

            if (isHovering)
            {
                destination = targetLocation;
            }
            else
            {
                destination = originalLocation;
            }

            int speed = 1;

            if (activeGroupBox.Top > destination.Y)
            {
                activeGroupBox.Top -= speed;
            }
            else if (activeGroupBox.Top < destination.Y)
            {
                activeGroupBox.Top += speed;
            }

            if (activeGroupBox.Top == destination.Y)
            {
                hoverTimer.Stop();
            }
        
        }

        public static void SetActiveLabel(Label lbl)
        {
            if (activeLabel != null)
            {
                activeLabel.BackColor = System.Drawing.Color.Transparent;
                activeLabel.ForeColor = System.Drawing.Color.White;
            }

            activeLabel = lbl;
            activeLabel.BackColor = System.Drawing.Color.Yellow;
            activeLabel.ForeColor = System.Drawing.Color.Black;
        }
    }
}
