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
            public MyLine(Point p1, Point p2, int z2, string n)
            {
                Matrix = new int[,] { { p1.X, p1.Y, 0, 1 }, { p2.X, p2.Y, z2, 1 } };
                Name = n;
                Focused = false;
            }

            public MyLine(int x, int y, string n)
            {
                Random rng = new Random();
                int x1, x2, y1, y2;
                // Задание координат
                x1 = rng.Next(0, x);
                x2 = rng.Next(0, x);
                y1 = rng.Next(0, y);
                y2 = rng.Next(0, y);

                Matrix = new int[,] { { x1, y1, 0, 1 }, { x2, y2, 0, 1 } };
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
                return (temp >= (p.Y - 5) && temp <= (p.Y + 5)) || (Focused && ContainsResizer(p) != -1);
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

            public string GetEnd(int row)
            {
                return Matrix[row, 0].ToString() + ";" + (600 - Matrix[row, 1]).ToString() + ";" + Matrix[row, 2].ToString();
            }
                
            // Вычислить координаты середины отрезка
            public int[] GetMiddle()
            {
                int[] res = new int[3];
                for (int i = 0; i < 3; i++)
                {
                    res[i] = (Matrix[0, i] + Matrix[1, i])/2;
                }

                return res;
            }

            public void ChangeEnd(int row, string CoordString)
            {
                string[] NewCoord = CoordString.Split(';');
                int NewX, NewY, NewZ;
                NewX = Int32.Parse(NewCoord[0]);
                NewY = 600 - Int32.Parse(NewCoord[1]);
                NewZ = Int32.Parse(NewCoord[2]);

                Matrix[row, 0] = NewX;
                Matrix[row, 1] = NewY;
                Matrix[row, 2] = NewZ;
            }

            public string WriteEquation()
            {
                int A, B, C;
                A = Matrix[1, 0] - Matrix[0, 0];
                B = Matrix[1, 1] - Matrix[0, 1];
                C = Matrix[1, 2] - Matrix[0, 2];
                return "x = " + Matrix[0, 0] + " + " + A + " * t" + Environment.NewLine + 
                    "y = " + Matrix[0, 1] + " + " + B + " * t" + Environment.NewLine + 
                    "z = " + Matrix[0, 2] + " + " + C + " * t";
                    
            }
        }
    }
}
