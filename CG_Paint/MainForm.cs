using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CG_Paint.Primitive;
using static CG_Paint.AffineTransformation;

namespace CG_Paint
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        // Путь к изображению
        string FilePath;
        // Список использованных примитивов
        List<Primitive> UsedPrimitives = new List<Primitive>();
        // Ссылка на примитив, над которым в данный момент производятся операции
        List<Primitive> CurrentPrimitives = new List<Primitive>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            MenuItemNew_Click(sender, e);
        }

        #region Операции с файлами
        // Создание нового файла
        private void MenuItemNew_Click(object sender, EventArgs e)
        {
            FilePath = null;
            lbPrimitives.Items.Clear();
            UsedPrimitives.Clear();
            CurrentPrimitives.Clear();
            pbDraw.Invalidate();
        }

        // Открытие файла
        private void MenuItemOpen_Click(object sender, EventArgs e)
        {
            MenuItemNew_Click(sender, e);

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Графические файлы(*.dat)|*.dat";
            ofd.Title = "Открытие изображения";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FilePath = ofd.FileName;
                UsedPrimitives = Files.ReadFile(FilePath);
                foreach (var prim in UsedPrimitives)
                    lbPrimitives.Items.Add(prim.Name);
                pbDraw.Invalidate();
            }
        }

        // Сохранение
        private void MenuItemSave_Click(object sender, EventArgs e)
        {
            if (FilePath == null)
                MenuItemSaveAs_Click(sender, e);
            else
            {
                Files.WriteFile(FilePath, UsedPrimitives);
            }
        }

        // Сохранить как
        private void MenuItemSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Графические файлы(*.dat)|*.dat";
            sfd.Title = "Сохранение изображения";
            if (sfd.ShowDialog() == DialogResult.OK)
            FilePath = sfd.FileName;
            Files.WriteFile(FilePath, UsedPrimitives);
        }

        // Экспорт изображения в формат jpg
        private void MenuItemExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "JPEG(*.jpg)";
            sfd.Title = "Экспорт изображения";
            if (sfd.ShowDialog() == DialogResult.OK)
                FilePath = sfd.FileName;
            pbDraw.Image.Save(FilePath);
        }
        #endregion Операции с файлами

        #region Операции с примитивами
        // Создание новой линии
        private void MenuItemLine_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            int x1, x2, y1, y2;
            // Задание координат
            x1 = rng.Next(0, pbDraw.Width);
            x2 = rng.Next(0, pbDraw.Width);
            y1 = rng.Next(0, pbDraw.Height);
            y2 = rng.Next(0, pbDraw.Height);

            UsedPrimitives.Add(new MyLine(new Point(x1, y1), new Point(x2, y2), "Объект "+ UsedPrimitives.Count+1));
            lbPrimitives.Items.Add("Объект " + UsedPrimitives.Count);
            pbDraw.Invalidate();
        }


        bool dragging;
        Point StartPoint;
        // Обработка "зажатия" клавиши мыши
        private void pbDraw_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && CurrentPrimitives.Count > 0 
                && CurrentPrimitives.Any(x => x.Contains(e.Location)))
            {
                dragging = true;
                StartPoint = new Point(e.Location.X, e.Location.Y);
            }
        }

        // Обработка движения мыши
        private void pbDraw_MouseMove(object sender, MouseEventArgs e)
        {
            lblMouse.Text = e.X.ToString() + ";" + (600 - e.Y).ToString();
            if (dragging && StartPoint != null)
            {
                int n, m, k;
                m = e.X - StartPoint.X;
                n = e.Y - StartPoint.Y;
                k = 0;
                // Если мы кликаем возле одного из узлов фигуры, то двигаем этот узел
                int p = -1;
                int i = 0;
                do
                {
                    p = CurrentPrimitives[i].ContainsResizer(StartPoint);
                }
                while (p == -1 && ++i < CurrentPrimitives.Count);
                if (p != -1)
                    CurrentPrimitives[i].Matrix = Transfer(CurrentPrimitives[i].Matrix, m, n, k, p);
                // Иначе двигаем всю фигуру целиком
                else
                    for (i = 0; i < CurrentPrimitives.Count; i++)
                        CurrentPrimitives[i].Matrix = Transfer(CurrentPrimitives[i].Matrix, m, n, k);
                pbDraw.Invalidate();
                StartPoint.X = e.X;
                StartPoint.Y = e.Y;
                if (CurrentPrimitives.Count == 1 && CurrentPrimitives[0].GetType() == typeof(MyLine))
                {
                    tbXCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(0);
                    tbXCoord.Enabled = true;
                    tbYCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(1);
                    tbYCoord.Enabled = true;
                    tbEquation.Text = (CurrentPrimitives[0] as MyLine).Equation();
                }
            }
        }

        // Обработка "отжатия клавиши мыши"
        private void pbDraw_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int i = 0;
                while (i < UsedPrimitives.Count && !UsedPrimitives[i].Contains(e.Location))
                {
                    i++;
                }
                if (i < UsedPrimitives.Count)
                {                    
                    lbPrimitives.SelectedIndices.Add(i);
                }
                else
                {
                    lbPrimitives.SelectedIndices.Clear();
                }
            }
            dragging = false;
            pbDraw.Invalidate();
        }

        // Отрисовка примитивов
        private void pbDraw_Paint(object sender, PaintEventArgs e)
        {
            if (cbShowAxis.Checked)
                Axis.DrawAxis(e.Graphics);
            if (UsedPrimitives.Count > 0)
            {
                foreach (var Prim in UsedPrimitives)
                {
                    Prim.Draw(e.Graphics);
                }
            }
        }

        // Выбор примитивов из списка
        private void lbPrimitives_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Primitive Prim in CurrentPrimitives)
                Prim.Focused = false;
            CurrentPrimitives.Clear();
            for (int i = 0; i < lbPrimitives.SelectedIndices.Count; i++)
            {
                int j = lbPrimitives.SelectedIndices[i];
                UsedPrimitives[j].Focused = true;
                CurrentPrimitives.Add(UsedPrimitives[j]);
            }
            pbDraw.Invalidate();
            if (CurrentPrimitives.Count == 1 && CurrentPrimitives[0].GetType() == typeof(MyLine))
            {
                tbXCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(0);
                tbXCoord.Enabled = true;
                tbYCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(1);
                tbYCoord.Enabled = true;
                tbEquation.Text = (CurrentPrimitives[0] as MyLine).Equation();
            }
            else
            {
                tbXCoord.Text = "";
                tbXCoord.Enabled = false;
                tbYCoord.Text = "";
                tbYCoord.Enabled = false;
                tbEquation.Text = "";
            }
        }

        // Удаление выделенного элемента
        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            if (CurrentPrimitives.Count > 0)
            {
                CurrentPrimitives.Clear();
                UsedPrimitives.RemoveAt(lbPrimitives.SelectedIndex);
                lbPrimitives.Items.RemoveAt(lbPrimitives.SelectedIndex);
                pbDraw.Invalidate();
            }
        }
        #endregion Операции с примитивами

        private void cbShowAxis_CheckedChanged(object sender, EventArgs e)
        {
            pbDraw.Invalidate();
        }
    }
}
