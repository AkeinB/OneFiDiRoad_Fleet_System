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

            RegisterCardClick(
                GB_Vehicles,
                () => _mainWindow.ShowScreen(new UC_Vehicles(), _mainWindow.VehiclesLabel));

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
        
        // helper 
        private void RegisterCardClick(Control control, Action action)
        {
            control.Click += (s, e) => action();

            foreach (Control child in control.Controls)
            {
                RegisterCardClick(child, action);
            }
        }



    }
}
