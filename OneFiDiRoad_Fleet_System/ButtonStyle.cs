
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace OneFiDiRoad_Fleet_System
{
    public class ButtonStyle : Button 
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();

            int radius = 8;

            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
            path.AddArc(0, Height - radius, radius, radius, 90, 90);

            path.CloseFigure();

            Region = new Region(path);

            BackColor = Theme.ColorTheme.ButtonNormal;
            ForeColor = Color.White;
            FlatStyle = FlatStyle.Flat;

            base.OnPaint(pevent);
        }
    }
}
