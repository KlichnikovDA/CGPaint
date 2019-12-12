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
        // Список использованных примитивов
        List<Group> Groups = new List<Group>();
        // Список примитивов, над которым в данный момент производятся операции
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
            Groups.Clear();
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

            UsedPrimitives.Add(new MyLine(new Point(x1, y1), new Point(x2, y2), "Объект "+ (UsedPrimitives.Count+1)));
            lbPrimitives.Items.Add(UsedPrimitives[UsedPrimitives.Count-1].Name);
            pbDraw.Invalidate();
        }

        // Сгруппировать примитивы
        // Группировка - по сути "сохранение" некоего набора выделенных инструментов.
        private void MenuItemGroup_Click(object sender, EventArgs e)
        {
            List<Primitive> CP = new List<Primitive>(CurrentPrimitives.Count);
            for(int i = 0; i < CurrentPrimitives.Count; i++)
            {
                CP.Add(CurrentPrimitives[i]);
            }
            Groups.Add(new Group(CP, "Группа " + (Groups.Count + 1)));
            lbGroups.Items.Add(Groups[Groups.Count -1].Name);
            lbGroups.SelectedIndices.Add(lbGroups.Items.Count - 1);
            Groups[Groups.Count - 1].Focused = true;
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
                    tbYCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(1);
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
                    lbGroups.SelectedIndices.Clear();
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
                btApplyOne.Enabled = true;
                tbYCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(1);
                tbYCoord.Enabled = true;
                btApplyTwo.Enabled = true;
                tbEquation.Text = (CurrentPrimitives[0] as MyLine).Equation();
            }
            else
            {
                tbXCoord.Text = "";
                tbXCoord.Enabled = false;
                btApplyOne.Enabled = false;
                tbYCoord.Text = "";
                tbYCoord.Enabled = false;
                btApplyTwo.Enabled = false;
                tbEquation.Text = "";
            }
        }

        // Выбор группы из списка
        private void lbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Primitive Prim in UsedPrimitives)
                Prim.Focused = false;
            CurrentPrimitives.Clear();
            for (int i = 0; i < Groups.Count; i++ )
            {
                foreach(Primitive Prim in Groups[i].Primitives)
                {
                    int j = UsedPrimitives.IndexOf(Prim);
                    UsedPrimitives[j].Focused = true;
                    if (!CurrentPrimitives.Contains(Prim))
                        CurrentPrimitives.Add(Prim);
                }
            }
            for (int i = 0; i < lbPrimitives.SelectedIndices.Count; i++)
            {
                int j = lbPrimitives.SelectedIndices[i];
                UsedPrimitives[j].Focused = true;
                if (!CurrentPrimitives.Contains(UsedPrimitives[j]))
                    CurrentPrimitives.Add(UsedPrimitives[j]);
            }
            pbDraw.Invalidate();
            if (CurrentPrimitives.Count == 1 && CurrentPrimitives[0].GetType() == typeof(MyLine))
            {
                tbXCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(0);
                tbXCoord.Enabled = true;
                btApplyOne.Enabled = true;
                tbYCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(1);
                tbYCoord.Enabled = true;
                btApplyTwo.Enabled = true;
                tbEquation.Text = (CurrentPrimitives[0] as MyLine).Equation();
            }
            else
            {
                tbXCoord.Text = "";
                tbXCoord.Enabled = false;
                btApplyOne.Enabled = false;
                tbYCoord.Text = "";
                tbYCoord.Enabled = false;
                btApplyTwo.Enabled = false;
                tbEquation.Text = "";
            }
        }

        // Удаление выделенного элемента
        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            // Если есть, что удалять
            if (CurrentPrimitives.Count > 0)
            {
                // Удаляем нужные элементы из общего списка использованных элементов
                while (CurrentPrimitives.Count > 0)
                {
                    UsedPrimitives.Remove(CurrentPrimitives[0]);
                    // Удаляем его из всех групп
                    for(int i = 0; i < Groups.Count; i++)
                    {
                        Groups[i].Primitives.Remove(CurrentPrimitives[0]);
                        // Если это был последний элемент в группе - удаляем группу
                        if (Groups[i].Primitives.Count == 0)
                        {
                            Groups.RemoveAt(i);
                            lbGroups.Items.RemoveAt(i--);
                        }
                    }
                    lbPrimitives.Items.Remove(CurrentPrimitives[0].Name);
                }
                CurrentPrimitives.Clear();
                lbPrimitives.SelectedIndices.Clear();
                pbDraw.Invalidate();
            }
        }

        // Отмена группировки
        private void MenuItemDegroup_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                if (Groups[i].Focused)
                {
                    lbGroups.Items.RemoveAt(i);
                    Groups.RemoveAt(i--);
                }
            }
        }
        #endregion Операции с примитивами

        private void cbShowAxis_CheckedChanged(object sender, EventArgs e)
        {
            pbDraw.Invalidate();
        }

        private void btApplyOne_Click(object sender, EventArgs e)
        {
            try
            {
                (CurrentPrimitives[0] as MyLine).ChangeEnd(0, tbXCoord.Text);
                tbEquation.Text = (CurrentPrimitives[0] as MyLine).Equation();
                pbDraw.Invalidate();
            }
            catch
            {
                tbXCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(0);
            }
        }

        private void btApplyTwo_Click(object sender, EventArgs e)
        {
            try
            {
                (CurrentPrimitives[0] as MyLine).ChangeEnd(1, tbYCoord.Text);
                tbEquation.Text = (CurrentPrimitives[0] as MyLine).Equation();
                pbDraw.Invalidate();
            }
            catch
            {
                tbYCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(1);
            }
        }
    }
}
