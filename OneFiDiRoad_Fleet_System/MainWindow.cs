using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OneFiDiRoad_Fleet_System
{
    public partial class MainWindow : Form
    {
        private readonly ONE_FI_DI_ROAD_DBEntities OneFiDiRoad;
        private readonly Login _loginForm;
        private readonly User _userinfo;
        
        public MainWindow(Login loginForm, User userinfo)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(MainWindow_FormClosing);
            OneFiDiRoad = new ONE_FI_DI_ROAD_DBEntities();
            ShowScreen(new HomeScreen());
            _loginForm = loginForm;
            _userinfo = userinfo;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            LB_DisplayUserName.Text = _userinfo.FirstName + " " + _userinfo.LastName;
            LB_DisplayUserRoles.Text = _userinfo.Role;
        }

        // event handler to close open forms when the main window is closed
        public void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?",
                 "Confirm Exit", MessageBoxButtons.YesNo,
                 MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Prevents closing
                return;
            }
            else
            {
                if (_loginForm != null && !_loginForm.IsDisposed)
                    _loginForm.Close();
            }

            //close all other open forms when the main window is closed
            foreach (Form form in Application.OpenForms.Cast<Form>().ToList())
            {
                if (form != this)
                    form.Close();
            }

            // dispose of the database context
            if (OneFiDiRoad != null)
                OneFiDiRoad.Dispose();
        }

        //helper method to show a new screen in the main content panel
        public void ShowScreen(UserControl newScreen)
        {
            // 1. Clear whatever screen is currently showing
            PL_MainContent.Controls.Clear();

            // 2. Make the new screen stretch to fill the panel completely
            newScreen.Dock = DockStyle.Fill;

            // 3. Inject the new screen into the panel
            PL_MainContent.Controls.Add(newScreen);

        }

       
    }
   }
