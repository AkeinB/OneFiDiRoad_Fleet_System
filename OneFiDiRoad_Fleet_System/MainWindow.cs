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
        
        public MainWindow()
        {
            InitializeComponent();
            OneFiDiRoad = new ONE_FI_DI_ROAD_DBEntities();
            ShowScreen(new HomeScreen());
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
