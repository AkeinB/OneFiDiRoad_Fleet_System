using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace OneFiDiRoad_Fleet_System
{
    public partial class MainWindow : Form
    {
        private readonly ONE_FI_DI_ROAD_DBEntities OneFiDiRoad;
        private readonly Login _loginForm;
        private readonly User _userinfo;
        private UserControl currentScreen;
        public Label VehiclesLabel => LB_Vehicles;
        public Label DriversLabel => LB_Drivers;
        public Label TripsLabel => LB_Trips;
        public Label FuelLabel => LB_Fuel;
        public Label ServiceScheduleLabel => LB_ServiceSchedule;


        [DllImport("dwmapi.dll")]
        private static extern int DwmSetWindowAttribute(
        IntPtr hwnd,
        int attr,
        ref int attrValue,
        int attrSize);

        private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;

        public MainWindow(Login loginForm, User userinfo)
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(MainWindow_FormClosing);
            OneFiDiRoad = new ONE_FI_DI_ROAD_DBEntities();
            ShowScreen(new HomeScreen1(this), LB_Home);
            Theme.ApplyTheme(this);
            _loginForm = loginForm;
            _userinfo = userinfo;

            

            //======================================================================================================================================================
            //Mouse enter and leave events for labels to highlight them
            //LB_Home.MouseEnter += (s, e) => Utils.AnimateLabelStart(LB_Home);
            //LB_Home.MouseLeave += (s, e) => Utils.AnimateLabelStop(LB_Home);
            LB_Home.MouseEnter += (s, e) => Utils.HighlightLabel(LB_Home);
            LB_Home.MouseLeave += (s, e) => Utils.RestoreLabel(LB_Home);

            //
            //LB_Vehicles.MouseEnter += (s, e) =>Utils.AnimateLabelStart(LB_Vehicles);
            //LB_Vehicles.MouseLeave += (s, e) => Utils.AnimateLabelStop(LB_Vehicles);
            LB_Vehicles.MouseEnter += (s, e) => Utils.HighlightLabel(LB_Vehicles);
            LB_Vehicles.MouseLeave += (s, e) => Utils.RestoreLabel(LB_Vehicles);

            //
            //LB_Drivers.MouseEnter += (s, e) => Utils.AnimateLabelStart(LB_Drivers);
            //LB_Drivers.MouseLeave += (s, e) => Utils.AnimateLabelStop(LB_Drivers);
            LB_Drivers.MouseEnter += (s, e) => Utils.HighlightLabel(LB_Drivers);
            LB_Drivers.MouseLeave += (s, e) => Utils.RestoreLabel(LB_Drivers);

            //
            //LB_Assingments.MouseEnter += (s, e) => Utils.AnimateLabelStart(LB_Assingments);
            //LB_Assingments.MouseLeave += (s, e) => Utils.AnimateLabelStop(LB_Assingments);
            LB_Assingments.MouseEnter += (s, e) => Utils.HighlightLabel(LB_Assingments);
            LB_Assingments.MouseLeave += (s, e) => Utils.RestoreLabel(LB_Assingments);

            //
            //LB_Trips.MouseEnter += (s, e) => Utils.AnimateLabelStart(LB_Trips);
            //LB_Trips.MouseLeave += (s, e) => Utils.AnimateLabelStop(LB_Trips);
            LB_Trips.MouseEnter += (s, e) => Utils.HighlightLabel(LB_Trips);
            LB_Trips.MouseLeave += (s, e) => Utils.RestoreLabel(LB_Trips);

            //
            //LB_Fuel.MouseEnter += (s, e) => Utils.AnimateLabelStart(LB_Fuel);
            //LB_Fuel.MouseLeave += (s, e) => Utils.AnimateLabelStop(LB_Fuel);
            LB_Fuel.MouseEnter += (s, e) => Utils.HighlightLabel(LB_Fuel);
            LB_Fuel.MouseLeave += (s, e) => Utils.RestoreLabel(LB_Fuel);

            //
            LB_Maintenance.MouseEnter += (e, s) => Utils.HighlightLabel(LB_Maintenance);
            LB_Maintenance.MouseLeave += (e, s) => Utils.RestoreLabel(LB_Maintenance);

            //
            LB_ServiceSchedule.MouseEnter += (e, s) => Utils.HighlightLabel(LB_ServiceSchedule);
            LB_ServiceSchedule.MouseLeave += (e, s) => Utils.RestoreLabel(LB_ServiceSchedule);

            //
            LB_Incidents.MouseEnter += (e, s) => Utils.HighlightLabel(LB_Incidents);
            LB_Incidents.MouseLeave += (E, S) => Utils.RestoreLabel(LB_Incidents);

            //
            LB_Reports.MouseEnter += (e, s) => Utils.HighlightLabel(LB_Reports);
            LB_Reports.MouseLeave += (e, s) => Utils.RestoreLabel(LB_Reports);

            //
            LB_ManageUsers.MouseEnter += (e, s) => Utils.HighlightLabel(LB_ManageUsers);
            LB_ManageUsers.MouseLeave += (e, s) => Utils.RestoreLabel(LB_ManageUsers);

        }

        //Loads the main window and displays the user's name and role
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Display the user's name and role in the labels
            LB_DisplayUserName.Text = _userinfo.FirstName + " " + _userinfo.LastName;
            LB_DisplayUserRoles.Text = _userinfo.Role;

            if (_userinfo.Role == "Staff")
            {
                LB_ManageUsers.Visible = false;
            }

            // Set the background color of the Home label to indicate it's the active screen
            LB_Home.BackColor = Theme.ColorTheme.SecondaryBackground2;

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

        private void LB_Home_Click(object sender, EventArgs e)
        {
            ShowScreen(new HomeScreen1(this), LB_Home);
            
        }

        
        private void LB_Vehicles_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Vehicles(), LB_Vehicles);
            
        }

        private void LB_Drivers_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Drivers(), LB_Drivers);
            
        }

        private void LB_Assingments_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Assignments(), LB_Assingments);
            
        }

        private void LB_Trips_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Trips(), LB_Trips);
            
        }

        private void LB_Fuel_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_FuelManagement(), LB_Fuel);
            
        }

        private void LB_Maintenance_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Maintenance(), LB_Maintenance);
            
        }

        private void LB_ServiceSchedule_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_ServiceShedule(), LB_ServiceSchedule);
            
        }

        private void LB_Incidents_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_IncidentManagement(), LB_Incidents);
            
        }

        private void LB_Reports_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_Reports(), LB_Reports);
            
        }

        private void LB_ManageUsers_Click(object sender, EventArgs e)
        {
            ShowScreen(new UC_ManageUsers(), LB_ManageUsers);
        }

        //======================================================================================================================================================
        //helper method to show a new screen in the main content panel
        public void ShowScreen(UserControl newScreen, Label navLabel)
        {
            // Check if the new screen is the same as the current screen
            if (currentScreen?.GetType() == newScreen.GetType())
                return;

            // Highlight the active label
            Utils.SetActiveLabel(navLabel);

            // Dispose of the current screen if it exists
            if (PL_MainContent.Controls.Count > 0)
            {
                PL_MainContent.Controls[0].Dispose();
            }

            //Clear whatever screen is currently showing
            PL_MainContent.Controls.Clear();

            //Make the new screen stretch to fill the panel completely
            //newScreen.Dock = DockStyle.Fill;

            // Inject the new screen into the panel
            PL_MainContent.Controls.Add(newScreen);

            currentScreen = newScreen;

        }
        //protected override void OnHandleCreated(EventArgs e)
        //{
        //    base.OnHandleCreated(e);

        //    int useDarkMode = 1;

        //    DwmSetWindowAttribute(
        //        this.Handle,
        //        DWMWA_USE_IMMERSIVE_DARK_MODE,
        //        ref useDarkMode,
        //        sizeof(int));
        //}
    }
}
