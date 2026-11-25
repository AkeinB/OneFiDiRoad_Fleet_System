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
    public partial class UC_ManageUsers : UserControl
    {
        public UC_ManageUsers()
        {
            InitializeComponent();

            Theme.ApplyTheme(this);
            this.BackColor = Theme.ColorTheme.SecondaryBackground2;
        }

        private void UC_ManageUsers_Load(object sender, EventArgs e)
        {
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.BackgroundColor = Theme.ColorTheme.SecondaryBackground2;


            
        }

       
    }
}
