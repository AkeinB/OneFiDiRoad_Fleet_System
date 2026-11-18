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
        public HomeScreen1()
        {
            InitializeComponent();
            OneFiDiRoad = new ONE_FI_DI_ROAD_DBEntities();

            GB_Vehicles.MouseEnter += (s, e) => Utils.AnimateGroupBoxStart(GB_Vehicles);
            GB_Vehicles.MouseLeave += (s, e) => Utils.AnimateGroupBoxStop(GB_Vehicles);

            Utils.hoverTimerGBs.Interval = 15;
            Utils.hoverTimerGBs.Tick += Utils.HoverTimer_TickGroupBox;
            Theme.ApplyTheme(this);
            this.BackColor = ColorTheme.SecondaryBackground2;

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


    }
}
