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
        // Прорисовка осей координат
        public static void DrawAxis(Graphics g)
        {
            g.DrawString("X", new Font("Arial", 14), new SolidBrush(Color.Black), 370, -30);
            g.DrawLine(new Pen(Color.Black, 3), -400, 0,400, 0);
            g.DrawString("Y", new Font("Arial", 14), new SolidBrush(Color.Black), 5, -290);
            g.DrawLine(new Pen(Color.Black, 3), 0, -300, 0, 300);
        }
    }
}
