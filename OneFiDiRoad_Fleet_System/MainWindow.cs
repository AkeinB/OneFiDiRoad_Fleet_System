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
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ShowScreen();

        }

        //helper method to show a new screen in the main content panel
        public void ShowScreen(UserControl newScreen)
        {
            // 1. Clear whatever screen is currently showing
            //mainContentPanel.Controls.Clear();

            // 2. Make the new screen stretch to fill the panel completely
            newScreen.Dock = DockStyle.Fill;

            // 3. Inject the new screen into the panel
            //mainContentPanel.Controls.Add(newScreen);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //ShowScreen();
        }
    }
   }
