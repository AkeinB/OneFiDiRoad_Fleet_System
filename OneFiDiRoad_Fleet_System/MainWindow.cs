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

        private Color originalBackColor;
        private Color originalForeColor;

        public MainWindow(Login loginForm, User userinfo)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(MainWindow_FormClosing);
            OneFiDiRoad = new ONE_FI_DI_ROAD_DBEntities();
            ShowScreen(new HomeScreen());
            Theme.ApplyTheme(this);
            _loginForm = loginForm;
            _userinfo = userinfo;
        }

        //Loads the main window and displays the user's name and role
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Display the user's name and role in the labels
            LB_DisplayUserName.Text = _userinfo.FirstName + " " + _userinfo.LastName;
            LB_DisplayUserRoles.Text = _userinfo.Role;

            // Set the interval for the hover timer and attach the Tick event handler
            Utils.hoverTimer.Interval = 15;
            Utils.hoverTimer.Tick += Utils.HoverTimer_TickLabels;


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

        //======================================================================================================================================================
        //helper method to show a new screen in the main content panel
        public void ShowScreen(UserControl newScreen)
        {
            // Dispose of the current screen if it exists
            if (PL_MainContent.Controls.Count > 0)
            {
                PL_MainContent.Controls[0].Dispose();
            }

            //Clear whatever screen is currently showing
            PL_MainContent.Controls.Clear();

            //Make the new screen stretch to fill the panel completely
            newScreen.Dock = DockStyle.Fill;

            // Inject the new screen into the panel
            PL_MainContent.Controls.Add(newScreen);

        }
        //======================================================================================================================================================
        //Mouse enter and leave events for labels to highlight them
        private void label2_MouseEnter(object sender, EventArgs e)
        {
            Utils.HighlightLabel((Label)sender);
            Utils.AnimateLabelStart((Label)sender);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            Utils.RestoreLabel((Label)sender);
            Utils.AnimateLabelStop((Label)sender);
        }

        


        // Animate the label when hovered over
        //private void AnimateLabelStart( Label lbl)
        //{
        //    //animatedLabel = lbl;
        //    //growing = true;

        //    //hoverTimer.Start();
        //}

        //private void AnimateLabelStop(Label lbl)
        //{
        //    animatedLabel = lbl;
        //    growing = false;
        //    hoverTimer.Start();
        //}


        


    }
   }
