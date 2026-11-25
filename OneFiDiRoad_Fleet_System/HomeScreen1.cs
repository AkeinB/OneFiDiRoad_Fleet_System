using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static OneFiDiRoad_Fleet_System.Theme;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Drawing.Drawing2D;

namespace OneFiDiRoad_Fleet_System
{
    public partial class HomeScreen1 : UserControl
    {
        private readonly ONE_FI_DI_ROAD_DBEntities OneFiDiRoad;
        private readonly MainWindow _mainWindow;
        private UserControl currentScreen;
        public HomeScreen1(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            OneFiDiRoad = new ONE_FI_DI_ROAD_DBEntities();

            Utils.hoverTimerGBs.Interval = 15;
            Utils.hoverTimerGBs.Tick += Utils.HoverTimer_TickGroupBox;
            Theme.ApplyTheme(this);
            this.BackColor = ColorTheme.SecondaryBackground2;

            this.DoubleBuffered = true;
            this.ResizeRedraw = true;


            // allows theVehicle's group box and its child controls to be clickable and navigate to the Vehicles screen when clicked
            RegisterCardClick(
                GB_Vehicles,
                () => _mainWindow.ShowScreen(new UC_Vehicles(), _mainWindow.VehiclesLabel));

            RegisterCardClick(
                GB_Drivers,
                () => _mainWindow.ShowScreen(new UC_Drivers(), _mainWindow.DriversLabel));

            RegisterCardClick(
                GB_TripsThisMonth,
                () => _mainWindow.ShowScreen(new UC_Trips(), _mainWindow.TripsLabel));

            RegisterCardClick(
                GB_VehiclesDueForService,
                () => _mainWindow.ShowScreen(new UC_Vehicles(), _mainWindow.ServiceScheduleLabel));

            RegisterCardClick(
                GB_FuelCostThisMonth,
                () => _mainWindow.ShowScreen(new UC_FuelManagement(), _mainWindow.FuelLabel));

            //=============================================================================================================================================
            //MouseEnter and MouseLeave events to highlight the groupbox when hovering over it or its child controls
            //Vehcles GroupBox
            GB_Vehicles.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            GB_Vehicles.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);
            LB_TitleVehicles.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            LB_TitleVehicles.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);
            LB_TotalVehicleAmount.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            LB_TotalVehicleAmount.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);
            LB_TotalVehicles.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            LB_TotalVehicles.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);
            LB_AvailableVehicles.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            LB_AvailableVehicles.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);
            LB_AvailableVehicleAmount.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            LB_AvailableVehicleAmount.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);
            PB_Vehicles.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            PB_Vehicles.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);
            TLP_Vehicles.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            TLP_Vehicles.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);


            //Drivers GroupBox
            GB_Drivers.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Drivers);
            GB_Drivers.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Drivers);
            LB_TitleDrivers.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Drivers);
            LB_TitleDrivers.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Drivers);
            LB_TotalDriversAmount.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Drivers);
            LB_TotalDriversAmount.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Drivers);
            LB_TotalDrivers.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Drivers);
            LB_TotalDrivers.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Drivers);
            LB_AvailableDriversAmount.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Drivers);
            LB_AvailableDriversAmount.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Drivers);
            LB_AvailableDrivers.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Drivers);
            LB_AvailableDrivers.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Drivers);
            PB_Drivers.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Drivers);
            PB_Drivers.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Drivers);
            TLP_Drivers.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Drivers);
            TLP_Drivers.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Drivers);

            //Trips GroupBox
            GB_TripsThisMonth.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_TripsThisMonth);
            GB_TripsThisMonth.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_TripsThisMonth);
            LB_TitleTrips.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_TripsThisMonth);
            LB_TitleTrips.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_TripsThisMonth);
            LB_MonthAmount.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_TripsThisMonth);
            LB_MonthAmount.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_TripsThisMonth);
            LB_Month.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_TripsThisMonth);
            LB_Month.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_TripsThisMonth);
            PB_Trips.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_TripsThisMonth);
            PB_Trips.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_TripsThisMonth);
            TLP_TripsMonth.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_TripsThisMonth);
            TLP_TripsMonth.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_TripsThisMonth);

            //Vehicles Due For Service GroupBox
            GB_VehiclesDueForService.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_VehiclesDueForService);
            GB_VehiclesDueForService.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_VehiclesDueForService);
            LB_TitleServiceDue.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_VehiclesDueForService); 
            LB_TitleServiceDue.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_VehiclesDueForService);
            LB_VehicleServiceAmount.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_VehiclesDueForService);
            LB_VehicleServiceAmount.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_VehiclesDueForService);
            PB_ServiceDue.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_VehiclesDueForService);
            PB_ServiceDue.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_VehiclesDueForService);
            TLP_ServiceDue.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_VehiclesDueForService);
            TLP_ServiceDue.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_VehiclesDueForService);

            //Fuel Consumption GroupBox
            GB_FuelCostThisMonth.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_FuelCostThisMonth);
            GB_FuelCostThisMonth.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_FuelCostThisMonth);
            LB_TitleFuelCostMonth.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_FuelCostThisMonth);
            LB_TitleFuelCostMonth.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_FuelCostThisMonth);
            LB_Cost.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_FuelCostThisMonth);
            LB_Cost.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_FuelCostThisMonth);
            LB_JMD.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_FuelCostThisMonth);
            LB_JMD.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_FuelCostThisMonth);
            PB_FuelCost.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_FuelCostThisMonth);
            PB_FuelCost.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_FuelCostThisMonth);
            TLP_FuelCostMonth.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_FuelCostThisMonth);
            TLP_FuelCostMonth.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_FuelCostThisMonth);

        }

        private void HomeScreen1_Load(object sender, EventArgs e)
        {
            var vehicles = OneFiDiRoad.Vehicles;
            var drivers = OneFiDiRoad.Drivers;
            var trips = OneFiDiRoad.Trips;
            ApplyThemeTableLayoutPanel();
            

            // Update the labels with the counts of total and available vehicles
            LB_TotalVehicleAmount.Text = vehicles.Count().ToString();
            LB_AvailableVehicleAmount.Text = vehicles.Count(v => v.Status == "Active").ToString();

            // Update the labels with the counts of total and available drivers
            LB_TotalDriversAmount.Text = drivers.Count().ToString();
            LB_AvailableDriversAmount.Text = drivers.Count(d => d.Status == "Active").ToString();

            // Update the labels with the counts of total trips and the current month
            LB_MonthAmount.Text = trips.Count().ToString();
            LB_Month.Text = DateTime.Now.ToString("MMMM yyyy");


        }

        // This method registers a click event for a group box and its child controls, allowing navigation to the specified screen when clicked
        private void RegisterCardClick(Control control, Action action)
        {
            control.Click += (s, e) => action();

            foreach (Control child in control.Controls)
            {
                RegisterCardClick(child, action);
            }
        }

        public void ApplyThemeTableLayoutPanel()
        {
            TLP_Drivers.BackColor = ColorTheme.SecondaryBackground2;
            TLP_Vehicles.BackColor = ColorTheme.SecondaryBackground2;
            TLP_TripsMonth.BackColor = ColorTheme.SecondaryBackground2;
            TLP_FuelCostMonth.BackColor = ColorTheme.SecondaryBackground2;
            TLP_ServiceDue.BackColor = ColorTheme.SecondaryBackground2;

        }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    // Guard against minimized window states (0 width or height throws an OutOfMemoryException)
        //    if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0)
        //        return;

        //    // Define colors and angle (e.g., 45f for diagonal, 90f for vertical, 0f for horizontal)
        //    Color startColor = Color.FromArgb(41, 128, 185); // Blue
        //    Color endColor = Color.FromArgb(142, 68, 173);   // Purple
        //    float angle = 45f;

        //    using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, startColor, endColor, angle))
        //    {
        //        e.Graphics.FillRectangle(brush, this.ClientRectangle);
        //    }
        //}

    }
}
