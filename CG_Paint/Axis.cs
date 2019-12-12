using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_Paint
{
    public static class Axis
    {
        public static void DrawAxis(Graphics g)
        {
            g.DrawString("X", new Font("Arial", 14), new SolidBrush(Color.Black), 770, 570);
            g.DrawLine(new Pen(Color.Black, 5), 0, 600, 800, 600);
            g.DrawString("Y", new Font("Arial", 14), new SolidBrush(Color.Black), 15, 15);
            g.DrawLine(new Pen(Color.Black, 3), 0, 0, 0, 600);
        }
    }
}
