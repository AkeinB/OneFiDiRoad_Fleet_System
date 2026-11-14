using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneFiDiRoad_Fleet_System
{
    public partial class Login : Form
    {
        private readonly ONE_FI_DI_ROAD_DBEntities OneFiDiRoad;
        public Login()
        {
            InitializeComponent();
            OneFiDiRoad = new ONE_FI_DI_ROAD_DBEntities();

        }

        private void BTN_Login_Click(object sender, EventArgs e)
        {
            try
            {
                SHA256 sha = SHA256.Create();// Create a SHA256 hash object


                var userName = TB_UserName.Text.Trim();
                var password = Utils.HashPassword(TB_Password.Text);



                //Query the database to find a user with the provided username, hashed password and active flag
                //==============================================================================================
                // Check if the user name exists in the database
                var user = OneFiDiRoad.Users.FirstOrDefault(u =>
                    u.UserName == userName);

                if (user == null)
                {
                    MessageBox.Show("Please provide valid credentials");
                    return;
                }

                // Check if the password is correct and the user is active
                bool isLoginValid = (user.PasswordHash == password && user.IsActive == true);
                
                // Get the user ID of the found user
                var userId = user.UserID;

                //track login in history and applies it to the database
                var loginhistory = new LoginHistory();
                {
                    loginhistory.UserID = userId;
                    loginhistory.LoginDateTime = DateTime.Now;
                    loginhistory.GainedAccess = isLoginValid;//applies "True" or "False" to the database depending on the validity of the login
                }
                //Add the login history to the database and save changes
                OneFiDiRoad.LoginHistories.Add(loginhistory);
                OneFiDiRoad.SaveChanges();
                

                //Block entry if invalid, or proceed if valid
                if (!isLoginValid)
                {
                    MessageBox.Show("Please provide valid credentials");
                    return;
                }

                // If the login is valid, open the main window and hide the login form
                var mainWindow = new MainWindow(this, user);
                mainWindow.Show();
                this.Hide();
                
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter your username and password.");
            }
        }
        
        private void CB_ShowPassword_CheckedChanged(object sender, EventArgs e)//event handler to show or hide the password in the password textbox
        {
            if (CHB_ShowPassword.Checked)
            {
                TB_Password.PasswordChar = '\0'; //shows plain text

            }
            else
            {
                TB_Password.PasswordChar = '*';
            }
        }
    }
}
