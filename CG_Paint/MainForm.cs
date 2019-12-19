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
        Group MorfA = new Group(new List<Primitive>(), "");
        Group MorfB = new Group(new List<Primitive>(), "");
        Group Morfing = new Group(new List<Primitive>(), "Морфинговая группа");

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
            UsedPrimitives.Add(new MyLine(pbDraw.Width, pbDraw.Height, "Объект "+ (UsedPrimitives.Count+1)));
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
                    tbEquation.Text = (CurrentPrimitives[0] as MyLine).WriteEquation();
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
                    lbGroups.SelectedIndices.Clear();
                    foreach(Group Gp in Groups)
                    {
                        Gp.Focused = false;
                    }
                }
                else
                {
                    lbGroups.SelectedIndices.Clear();
                    lbPrimitives.SelectedIndices.Clear();
                    foreach (Group Gp in Groups)
                    {
                        Gp.Focused = false;
                    }
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
                if (!CurrentPrimitives.Contains(UsedPrimitives[j]))
                    CurrentPrimitives.Add(UsedPrimitives[j]);
            }
            pbDraw.Invalidate();
            if (CurrentPrimitives.Count == 1 && CurrentPrimitives[0].GetType() == typeof(MyLine))
            {
                tbXCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(0);
                tbXCoord.Enabled = true;
                tbYCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(1);
                tbYCoord.Enabled = true;
                tbEquation.Text = (CurrentPrimitives[0] as MyLine).WriteEquation();
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

        // Выбор группы из списка
        private void lbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Group gp in Groups)
            {
                gp.Focused = false;
                foreach (Primitive Prim in gp.Primitives)
                {
                    int k = UsedPrimitives.IndexOf(Prim);
                    UsedPrimitives[k].Focused = false;
                    CurrentPrimitives.Remove(Prim);
                    lbPrimitives.SelectedIndices.Remove(lbPrimitives.Items.IndexOf(Prim.Name));
                }
            }
            for (int i = 0; i < lbGroups.SelectedIndices.Count; i++)
            {
                int j = lbGroups.SelectedIndices[i];
                Groups[j].Focused = true;
                foreach (Primitive Prim in Groups[j].Primitives)
                {
                    int k = UsedPrimitives.IndexOf(Prim);
                    UsedPrimitives[k].Focused = true;
                    if (!CurrentPrimitives.Contains(Prim))
                        CurrentPrimitives.Add(Prim);
                    lbPrimitives.SelectedIndices.Add(lbPrimitives.Items.IndexOf(Prim.Name));
                }
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
                if (MorfA.Primitives.Count == 0 || MorfB.Primitives.Count == 0)
                {
                    trb_Morfing.Enabled = false;
                    tb_Morfing.Text = "0";
                    tb_Morfing.Enabled = false;
                }
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

        // Прорисовка координатных осей
        private void cbShowAxis_CheckedChanged(object sender, EventArgs e)
        {
            pbDraw.Invalidate();
        }

        // Задание координат первого конца отрезка
        private void bt_AppEndOne_Click(object sender, EventArgs e)
        {
            try
            {
                (CurrentPrimitives[0] as MyLine).ChangeEnd(0, tbXCoord.Text);
                tbEquation.Text = (CurrentPrimitives[0] as MyLine).WriteEquation();
                pbDraw.Invalidate();
            }
            catch
            {
                tbXCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(0);
            }
        }

        // Задание координат второго конца отрезка
        private void bt_AppEndTwo_Click(object sender, EventArgs e)
        {
            try
            {
                (CurrentPrimitives[0] as MyLine).ChangeEnd(1, tbYCoord.Text);
                tbEquation.Text = (CurrentPrimitives[0] as MyLine).WriteEquation();
                pbDraw.Invalidate();
            }
            catch
            {
                tbYCoord.Text = (CurrentPrimitives[0] as MyLine).GetEnd(1);
            }
        }

        #region Сложные операции
        // Переход в режим построения медианы
        private void MenuItemMedian_Click(object sender, EventArgs e)
        {
            // Переподписываем делегат на наш новый обработчик
            this.pbDraw.MouseUp -= this.pbDraw_MouseUp;
            this.pbDraw.MouseUp += new MouseEventHandler(pbDraw_MouseUpMedian);
        }

        // Установка точки из которой будут строиться медианы
        // Построение медиан из точки ко всем выделенным объектам
        private void pbDraw_MouseUpMedian(object sender, MouseEventArgs e)
        {
            foreach (Primitive Prim in CurrentPrimitives)
            {
                int[] vector = (Prim as MyLine).GetMiddle();

                UsedPrimitives.Add(new MyLine(new Point(e.X, e.Y), new Point(vector[0], vector[1]), 
                    vector[2], "Объект " + (UsedPrimitives.Count + 1)));
                lbPrimitives.Items.Add(UsedPrimitives[UsedPrimitives.Count - 1].Name);
                pbDraw.Invalidate();
            }

            // Возврат к стандартному обработчику клика мышью
            this.pbDraw.MouseUp -= this.pbDraw_MouseUpMedian;
            this.pbDraw.MouseUp += pbDraw_MouseUp;
        }
        
        // Переход в режим построения высоты
        private void MenuItemAltitude_Click(object sender, EventArgs e)
        {
            // Переподписываем делегат на наш новый обработчик
            this.pbDraw.MouseUp -= this.pbDraw_MouseUp;
            this.pbDraw.MouseUp += new MouseEventHandler(pbDraw_MouseUpAltitude);
        }

        // Установка точки из которой будут строиться высоты
        // Построение высот из точки ко всем выделенным объектам
        private void pbDraw_MouseUpAltitude(object sender, MouseEventArgs e)
        {
            foreach (Primitive Prim in CurrentPrimitives)
            {
                // Вычисление точки пересечения прямой и высоты
                int A, B, C;
                A = Prim.Matrix[1, 0] - Prim.Matrix[0, 0];
                B = Prim.Matrix[1, 1] - Prim.Matrix[0, 1];
                C = Prim.Matrix[1, 2] - Prim.Matrix[0, 2];
                double L = (-A * (Prim.Matrix[0, 0] - e.X) - B * (Prim.Matrix[0, 1] - e.Y) - C * Prim.Matrix[0, 2]) /
                    (1.0 * (A * A + B * B + C * C));
                int x3, y3, z3;
                x3 = (int)(Prim.Matrix[0, 0] + A * L);
                y3 = (int)(Prim.Matrix[0, 1] + B * L);
                z3 = (int)(Prim.Matrix[0, 2] + C * L);

                UsedPrimitives.Add(new MyLine(new Point(e.X, e.Y), new Point(x3, y3), z3, 
                    "Объект " + (UsedPrimitives.Count + 1)));
                lbPrimitives.Items.Add(UsedPrimitives[UsedPrimitives.Count - 1].Name);
                pbDraw.Invalidate();
            }

            // Возврат к стандартному обработчику клика мышью
            this.pbDraw.MouseUp -= this.pbDraw_MouseUpAltitude;
            this.pbDraw.MouseUp += pbDraw_MouseUp;
        }

        // Установка точки из которой будет строиться биссектриса
        // Построение высот из точки ко всем выделенным объектам
        private void MenuItemBisection_Click(object sender, EventArgs e)
        {
            if (CurrentPrimitives.Count == 2 && CurrentPrimitives[0].GetType() == typeof(MyLine) &&
                CurrentPrimitives[1].GetType() == typeof(MyLine))
            {
                // Берем координаты концов линий
                MyPoint P1 = new MyPoint(CurrentPrimitives[0].Matrix[0, 0],
                    CurrentPrimitives[0].Matrix[0, 1], CurrentPrimitives[0].Matrix[0, 2]);
                MyPoint P2 = new MyPoint(CurrentPrimitives[0].Matrix[1, 0],
                    CurrentPrimitives[0].Matrix[1, 1], CurrentPrimitives[0].Matrix[1, 2]);
                MyPoint P3 = new MyPoint(CurrentPrimitives[1].Matrix[0, 0],
                    CurrentPrimitives[1].Matrix[0, 1], CurrentPrimitives[1].Matrix[0, 2]);
                MyPoint P4 = new MyPoint(CurrentPrimitives[1].Matrix[1, 0],
                    CurrentPrimitives[1].Matrix[1, 1], CurrentPrimitives[1].Matrix[1, 2]);

                // Если линии образуют угол
                if (P1 == P3 || P1 == P4 || P2 == P3 || P2 == P4)
                {
                    int x1 = 0, x2 = 0, x3 = 0, x4;
                    int y1 = 0, y2 = 0, y3 = 0, y4;
                    int z1 = 0, z2 = 0, z3 = 0, z4;
                    if (P1 == P3)
                    {
                        x1 = P2.X;
                        y1 = P2.Y;
                        z1 = P2.Z;
                        x2 = P4.X;
                        y2 = P4.Y;
                        z2 = P4.Z;
                        x3 = P1.X;
                        y3 = P1.Y;
                        z3 = P1.Z;
                    }
                    if (P1 == P4)
                    {
                        x1 = P2.X;
                        y1 = P2.Y;
                        z1 = P2.Z;
                        x2 = P3.X;
                        y2 = P3.Y;
                        z2 = P3.Z;
                        x3 = P1.X;
                        y3 = P1.Y;
                        z3 = P1.Z;
                    }
                    if (P2 == P3)
                    {
                        x1 = P1.X;
                        y1 = P1.Y;
                        z1 = P1.Z;
                        x2 = P4.X;
                        y2 = P4.Y;
                        z2 = P4.Z;
                        x3 = P2.X;
                        y3 = P2.Y;
                        z3 = P2.Z;
                    }
                    if (P2 == P4)
                    {
                        x1 = P1.X;
                        y1 = P1.Y;
                        z1 = P1.Z;
                        x2 = P3.X;
                        y2 = P3.Y;
                        z2 = P3.Z;
                        x3 = P2.X;
                        y3 = P2.Y;
                        z3 = P2.Z;
                    }
                    double L = Math.Sqrt((x3 - x1) * (x3 - x1) + (y3 - y1) * (y3 - y1) + (z3 - z1) * (z3 - z1)) /
                        Math.Sqrt((x3 - x2) * (x3 - x2) + (y3 - y2) * (y3 - y2) + (z3 - z2) * (z3 - z2));
                    x4 = (int)((x1 + x2 * L) / (1 + L));
                    y4 = (int)((y1 + y2 * L) / (1 + L));
                    z4 = (int)((z1 + z2 * L) / (1 + L));

                    UsedPrimitives.Add(new MyLine(new Point(x3, y3), z3, new Point(x4, y4), z4, 
                        "Объект " + (UsedPrimitives.Count + 1)));
                    lbPrimitives.Items.Add(UsedPrimitives[UsedPrimitives.Count - 1].Name);
                    pbDraw.Invalidate();
                }
                else
                {
                    MessageBox.Show("Выбранные отрезки не образуют угол");
                }
            }
            else
            {
                MessageBox.Show("Выбрано неподходящее количество прямых (нужно 2)");
            }
        }

        // Задать начальную позицию для морфинга
        private void bt_FirPos_Click(object sender, EventArgs e)
        {
            if (lbGroups.SelectedIndices.Count == 1)
            {
                MorfA = Groups[lbGroups.SelectedIndices[0]];
                if (MorfB.Primitives.Count != 0)
                {
                    trb_Morfing.Enabled = true;
                    tb_Morfing.Enabled = true;
                    trb_Morfing_Scroll(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Выбрано неподходящее количество групп (нужно 1)");
            }
        }

        // Задать конечную позицию для морфинга
        private void bt_SecPos_Click(object sender, EventArgs e)
        {
            if (lbGroups.SelectedIndices.Count == 1)
            {
                MorfB = Groups[lbGroups.SelectedIndices[0]];
                if (MorfA.Primitives.Count != 0)
                {
                    trb_Morfing.Enabled = true;
                    tb_Morfing.Enabled = true;
                    trb_Morfing_Scroll(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Выбрано неподходящее количество групп (нужно 1)");
            }
        }

        // Задать значение параметра морфинга
        private void tb_Morfing_Leave(object sender, EventArgs e)
        {
            try
            {
                trb_Morfing.Value = (int)(Double.Parse(tb_Morfing.Text) * 100);
                trb_Morfing_Scroll(sender, e);
            }
            catch
            {
                tb_Morfing.Text = (trb_Morfing.Value / trb_Morfing.Maximum * 1.0).ToString();
            }
        }

        // Морфинг
        private void trb_Morfing_Scroll(object sender, EventArgs e)
        {
            int MaxElements = Math.Max(MorfA.Primitives.Count, MorfB.Primitives.Count),
                AElements = MorfA.Primitives.Count, BElements = MorfB.Primitives.Count;
            // Создать группу для морфинга, если нет
            if (Morfing.Primitives.Count == 0)
            {
                // Заполняем группу.
                // Если в одной из групп будем меньше, чем в другой, линии пойдут на второй круг
                for (int i = 0; i < MaxElements; i++)
                {
                    // Создание новой линии
                    MyLine MorfLine = new MyLine(
                        new Point(MorfA.Primitives[i % AElements].Matrix[0, 0],
                        MorfA.Primitives[i % AElements].Matrix[0, 1]),
                        MorfA.Primitives[i % AElements].Matrix[0, 2],
                        new Point(MorfA.Primitives[i % AElements].Matrix[1, 0],
                        MorfA.Primitives[i % AElements].Matrix[1, 1]),
                        MorfA.Primitives[i % AElements].Matrix[1, 2],
                        "Линия морфинга" + (Morfing.Primitives.Count + 1));

                    Morfing.Primitives.Add(MorfLine);
                    UsedPrimitives.Add(MorfLine);
                    lbPrimitives.Items.Add(UsedPrimitives[UsedPrimitives.Count - 1].Name);
                }
                Groups.Add(Morfing);
                lbGroups.Items.Add(Morfing.Name);
            }
            // Осуществление морфинга
            double t = 1.0 * trb_Morfing.Value / trb_Morfing.Maximum;
            for(int i = 0; i < MaxElements;i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Morfing.Primitives[i].Matrix[j, 0] = (int)(MorfA.Primitives[i % AElements].Matrix[j, 0] * (1 - t) +
                        MorfB.Primitives[i % BElements].Matrix[j, 0] * t);
                    Morfing.Primitives[i].Matrix[j, 1] = (int)(MorfA.Primitives[i % AElements].Matrix[j, 1] * (1 - t) +
                        MorfB.Primitives[i % BElements].Matrix[j, 1] * t);
                    Morfing.Primitives[i].Matrix[j, 2] = (int)(MorfA.Primitives[i % AElements].Matrix[j, 2] * (1 - t) +
                        MorfB.Primitives[i % BElements].Matrix[j, 2] * t);
                }
            }
            tb_Morfing.Text = t.ToString();
            pbDraw.Invalidate();
        }

        #endregion Сложные операции
    }
}
