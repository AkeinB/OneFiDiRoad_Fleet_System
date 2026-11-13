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
                var user = OneFiDiRoad.Users.FirstOrDefault(u =>
                    u.UserName == userName && u.PasswordHash == password && u.IsActive == true);


                if (user == null)
                {
                    MessageBox.Show("Please provide valid credentials");
                    return;
                }
                else
                {

                    //function to track login in history



                    var mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Hide();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Please enter your username and password.");
            }
        }

        private void CB_ShowPassword_CheckedChanged(object sender, EventArgs e)
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
