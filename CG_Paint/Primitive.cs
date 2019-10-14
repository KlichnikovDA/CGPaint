using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CG_Paint
{
    [Serializable]
    abstract public class Primitive
    {
        // Матрица, кодирующая точки примитива
        public int[,] Matrix;

        public bool Focused { get; set; }
        public string Name { get; set; }

        // Метод определения, попадает ли курсор на данный объект
        abstract public bool Contains(Point p);
        // Метод определения, попадает ли курсор на точку "растягивания"
        abstract public int ContainsResizer(Point p);

        // Метод отрисовки данного примитива
        abstract public void Draw(Graphics g);
        abstract public void DrawFocused(Graphics g);

        // Прямая линия
        [Serializable]
        public class MyLine: Primitive
        {
            public MyLine(Point p1, Point p2, string n)
            {
                Matrix = new int[,] { { p1.X, p1.Y, 1 }, { p2.X, p2.Y, 1 } };
                Name = n;
                Focused = false;
            }

            float Slope()
            {
                try
                {
                    return (float)(Matrix[1, 1] - Matrix[0, 1]) / (Matrix[1, 0] - Matrix[0, 0]);
                }
                catch (DivideByZeroException e)
                {
                    return Matrix[1, 1] - Matrix[0, 1];
                }
            }

            override public bool Contains(Point p)
            {
                float temp = Slope() * p.X + (Matrix[0, 1] - Slope() * Matrix[0, 0]);
                return (temp >= (p.Y - 3) && temp <= (p.Y + 3)) || (Focused && ContainsResizer(p) != -1);
            }

            override public int ContainsResizer(Point p)
            {
                // Возвращаем номер строки матрицы, содержащей нужный узел или -1
                for (int i = 0; i < Matrix.GetLength(0); i++)
                    if (Matrix[i, 0] >= p.X - 10 && Matrix[i, 0] <= p.X + 10 && 
                        Matrix[i, 1] >= p.Y - 10 && Matrix[i, 1] <= p.Y + 10)
                        return i;
                return -1;
            }

            override public void Draw(Graphics g)
            {
                if (Focused)
                    DrawFocused(g);
                else
                    g.DrawLine(new Pen(Color.Red, 3), Matrix[0, 0], Matrix[0, 1], Matrix[1, 0], Matrix[1, 1]);
            }

            override public void DrawFocused(Graphics g)
            {
                g.DrawLine(new Pen(Color.Blue, 3), Matrix[0, 0], Matrix[0, 1], Matrix[1, 0], Matrix[1, 1]);
                g.DrawEllipse(new Pen(Color.Blue, 3), Matrix[0, 0] - 5, Matrix[0, 1] - 5, 10, 10);
                g.DrawEllipse(new Pen(Color.Blue, 3), Matrix[1, 0] - 5, Matrix[1, 1] - 5, 10, 10);
            }
        }
    }
}
