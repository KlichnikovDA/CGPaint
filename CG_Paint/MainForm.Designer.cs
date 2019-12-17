namespace CG_Paint
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mi_MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemNew = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemExport = new System.Windows.Forms.ToolStripMenuItem();
            this.mi_MenuImage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemLine = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDegroup = new System.Windows.Forms.ToolStripMenuItem();
            this.построениеОтрезковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemMedian = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAltitude = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBisection = new System.Windows.Forms.ToolStripMenuItem();
            this.pbDraw = new System.Windows.Forms.PictureBox();
            this.labelPrimitives = new System.Windows.Forms.Label();
            this.labelx = new System.Windows.Forms.Label();
            this.tbXCoord = new System.Windows.Forms.TextBox();
            this.tbYCoord = new System.Windows.Forms.TextBox();
            this.labely = new System.Windows.Forms.Label();
            this.lbPrimitives = new System.Windows.Forms.ListBox();
            this.tbEquation = new System.Windows.Forms.TextBox();
            this.lblEquation = new System.Windows.Forms.Label();
            this.lblMouse = new System.Windows.Forms.Label();
            this.cbShowAxis = new System.Windows.Forms.CheckBox();
            this.lbGroups = new System.Windows.Forms.ListBox();
            this.lblGroups = new System.Windows.Forms.Label();
            this.bt_SecPos = new System.Windows.Forms.Button();
            this.bt_FirPos = new System.Windows.Forms.Button();
            this.trb_Morfing = new System.Windows.Forms.TrackBar();
            this.tb_Morfing = new System.Windows.Forms.TextBox();
            this.lblMorfing = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Morfing)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mi_MenuFile,
            this.mi_MenuImage});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1264, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "ms_MainMenu";
            // 
            // mi_MenuFile
            // 
            this.mi_MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemNew,
            this.MenuItemOpen,
            this.MenuItemSave,
            this.MenuItemSaveAs,
            this.MenuItemExport});
            this.mi_MenuFile.Name = "mi_MenuFile";
            this.mi_MenuFile.Size = new System.Drawing.Size(48, 20);
            this.mi_MenuFile.Text = "Файл";
            // 
            // MenuItemNew
            // 
            this.MenuItemNew.Name = "MenuItemNew";
            this.MenuItemNew.ShortcutKeyDisplayString = "Ctrl+N";
            this.MenuItemNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.MenuItemNew.Size = new System.Drawing.Size(225, 22);
            this.MenuItemNew.Text = "Новый";
            this.MenuItemNew.Click += new System.EventHandler(this.MenuItemNew_Click);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemOpen.Size = new System.Drawing.Size(225, 22);
            this.MenuItemOpen.Text = "Открыть";
            this.MenuItemOpen.Click += new System.EventHandler(this.MenuItemOpen_Click);
            // 
            // MenuItemSave
            // 
            this.MenuItemSave.Name = "MenuItemSave";
            this.MenuItemSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuItemSave.Size = new System.Drawing.Size(225, 22);
            this.MenuItemSave.Text = "Сохранить";
            this.MenuItemSave.Click += new System.EventHandler(this.MenuItemSave_Click);
            // 
            // MenuItemSaveAs
            // 
            this.MenuItemSaveAs.Name = "MenuItemSaveAs";
            this.MenuItemSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.MenuItemSaveAs.Size = new System.Drawing.Size(225, 22);
            this.MenuItemSaveAs.Text = "Сохранить как";
            this.MenuItemSaveAs.Click += new System.EventHandler(this.MenuItemSaveAs_Click);
            // 
            // MenuItemExport
            // 
            this.MenuItemExport.Name = "MenuItemExport";
            this.MenuItemExport.Size = new System.Drawing.Size(225, 22);
            this.MenuItemExport.Text = "Экспорт в JPG";
            this.MenuItemExport.Click += new System.EventHandler(this.MenuItemExport_Click);
            // 
            // mi_MenuImage
            // 
            this.mi_MenuImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCreate,
            this.MenuItemDelete,
            this.MenuItemGroup,
            this.MenuItemDegroup,
            this.построениеОтрезковToolStripMenuItem});
            this.mi_MenuImage.Name = "mi_MenuImage";
            this.mi_MenuImage.Size = new System.Drawing.Size(95, 20);
            this.mi_MenuImage.Text = "Изображение";
            // 
            // MenuItemCreate
            // 
            this.MenuItemCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLine});
            this.MenuItemCreate.Name = "MenuItemCreate";
            this.MenuItemCreate.Size = new System.Drawing.Size(244, 22);
            this.MenuItemCreate.Text = "Создать";
            // 
            // MenuItemLine
            // 
            this.MenuItemLine.Name = "MenuItemLine";
            this.MenuItemLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.MenuItemLine.Size = new System.Drawing.Size(153, 22);
            this.MenuItemLine.Text = "Прямая";
            this.MenuItemLine.Click += new System.EventHandler(this.MenuItemLine_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.Delete)));
            this.MenuItemDelete.Size = new System.Drawing.Size(244, 22);
            this.MenuItemDelete.Text = "Удалить";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // MenuItemGroup
            // 
            this.MenuItemGroup.Name = "MenuItemGroup";
            this.MenuItemGroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.G)));
            this.MenuItemGroup.Size = new System.Drawing.Size(244, 22);
            this.MenuItemGroup.Text = "Сгруппировать";
            this.MenuItemGroup.Click += new System.EventHandler(this.MenuItemGroup_Click);
            // 
            // MenuItemDegroup
            // 
            this.MenuItemDegroup.Name = "MenuItemDegroup";
            this.MenuItemDegroup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.MenuItemDegroup.Size = new System.Drawing.Size(244, 22);
            this.MenuItemDegroup.Text = "Отменить группировку";
            this.MenuItemDegroup.Click += new System.EventHandler(this.MenuItemDegroup_Click);
            // 
            // построениеОтрезковToolStripMenuItem
            // 
            this.построениеОтрезковToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemMedian,
            this.MenuItemAltitude,
            this.MenuItemBisection});
            this.построениеОтрезковToolStripMenuItem.Name = "построениеОтрезковToolStripMenuItem";
            this.построениеОтрезковToolStripMenuItem.Size = new System.Drawing.Size(244, 22);
            this.построениеОтрезковToolStripMenuItem.Text = "Построение отрезков";
            // 
            // MenuItemMedian
            // 
            this.MenuItemMedian.Name = "MenuItemMedian";
            this.MenuItemMedian.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
            this.MenuItemMedian.Size = new System.Drawing.Size(180, 22);
            this.MenuItemMedian.Text = "Медиана";
            this.MenuItemMedian.Click += new System.EventHandler(this.MenuItemMedian_Click);
            // 
            // MenuItemAltitude
            // 
            this.MenuItemAltitude.Name = "MenuItemAltitude";
            this.MenuItemAltitude.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.A)));
            this.MenuItemAltitude.Size = new System.Drawing.Size(180, 22);
            this.MenuItemAltitude.Text = "Высота";
            this.MenuItemAltitude.Click += new System.EventHandler(this.MenuItemAltitude_Click);
            // 
            // MenuItemBisection
            // 
            this.MenuItemBisection.Name = "MenuItemBisection";
            this.MenuItemBisection.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.MenuItemBisection.Size = new System.Drawing.Size(180, 22);
            this.MenuItemBisection.Text = "Биссектриса";
            this.MenuItemBisection.Click += new System.EventHandler(this.MenuItemBisection_Click);
            // 
            // pbDraw
            // 
            this.pbDraw.BackColor = System.Drawing.Color.White;
            this.pbDraw.Location = new System.Drawing.Point(12, 27);
            this.pbDraw.Name = "pbDraw";
            this.pbDraw.Size = new System.Drawing.Size(800, 600);
            this.pbDraw.TabIndex = 1;
            this.pbDraw.TabStop = false;
            this.pbDraw.Paint += new System.Windows.Forms.PaintEventHandler(this.pbDraw_Paint);
            this.pbDraw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbDraw_MouseDown);
            this.pbDraw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbDraw_MouseMove);
            this.pbDraw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbDraw_MouseUp);
            // 
            // labelPrimitives
            // 
            this.labelPrimitives.AutoSize = true;
            this.labelPrimitives.Location = new System.Drawing.Point(1099, 313);
            this.labelPrimitives.Name = "labelPrimitives";
            this.labelPrimitives.Size = new System.Drawing.Size(108, 13);
            this.labelPrimitives.TabIndex = 3;
            this.labelPrimitives.Text = "Список примитивов";
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(999, 35);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(146, 13);
            this.labelx.TabIndex = 4;
            this.labelx.Text = "Координаты первого конца";
            // 
            // tbXCoord
            // 
            this.tbXCoord.Enabled = false;
            this.tbXCoord.Location = new System.Drawing.Point(1151, 32);
            this.tbXCoord.Name = "tbXCoord";
            this.tbXCoord.Size = new System.Drawing.Size(100, 20);
            this.tbXCoord.TabIndex = 5;
            this.tbXCoord.Leave += new System.EventHandler(this.tbXCoord_Leave);
            // 
            // tbYCoord
            // 
            this.tbYCoord.Enabled = false;
            this.tbYCoord.Location = new System.Drawing.Point(1151, 58);
            this.tbYCoord.Name = "tbYCoord";
            this.tbYCoord.Size = new System.Drawing.Size(100, 20);
            this.tbYCoord.TabIndex = 7;
            this.tbYCoord.Leave += new System.EventHandler(this.tbYCoord_Leave);
            // 
            // labely
            // 
            this.labely.AutoSize = true;
            this.labely.Location = new System.Drawing.Point(1000, 55);
            this.labely.Name = "labely";
            this.labely.Size = new System.Drawing.Size(145, 13);
            this.labely.TabIndex = 6;
            this.labely.Text = "Координаты второго конца";
            // 
            // lbPrimitives
            // 
            this.lbPrimitives.FormattingEnabled = true;
            this.lbPrimitives.Location = new System.Drawing.Point(1102, 329);
            this.lbPrimitives.Name = "lbPrimitives";
            this.lbPrimitives.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbPrimitives.Size = new System.Drawing.Size(150, 342);
            this.lbPrimitives.TabIndex = 8;
            this.lbPrimitives.SelectedIndexChanged += new System.EventHandler(this.lbPrimitives_SelectedIndexChanged);
            // 
            // tbEquation
            // 
            this.tbEquation.Enabled = false;
            this.tbEquation.Location = new System.Drawing.Point(1069, 83);
            this.tbEquation.Multiline = true;
            this.tbEquation.Name = "tbEquation";
            this.tbEquation.Size = new System.Drawing.Size(183, 76);
            this.tbEquation.TabIndex = 10;
            // 
            // lblEquation
            // 
            this.lblEquation.AutoSize = true;
            this.lblEquation.Location = new System.Drawing.Point(1000, 83);
            this.lblEquation.Name = "lblEquation";
            this.lblEquation.Size = new System.Drawing.Size(63, 13);
            this.lblEquation.TabIndex = 9;
            this.lblEquation.Text = "Уравнения";
            // 
            // lblMouse
            // 
            this.lblMouse.AutoSize = true;
            this.lblMouse.Location = new System.Drawing.Point(9, 660);
            this.lblMouse.Name = "lblMouse";
            this.lblMouse.Size = new System.Drawing.Size(35, 13);
            this.lblMouse.TabIndex = 11;
            this.lblMouse.Text = "label1";
            // 
            // cbShowAxis
            // 
            this.cbShowAxis.AutoSize = true;
            this.cbShowAxis.Checked = true;
            this.cbShowAxis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbShowAxis.Location = new System.Drawing.Point(68, 659);
            this.cbShowAxis.Name = "cbShowAxis";
            this.cbShowAxis.Size = new System.Drawing.Size(185, 17);
            this.cbShowAxis.TabIndex = 12;
            this.cbShowAxis.Text = "Отображать координатные оси";
            this.cbShowAxis.UseVisualStyleBackColor = true;
            this.cbShowAxis.CheckedChanged += new System.EventHandler(this.cbShowAxis_CheckedChanged);
            // 
            // lbGroups
            // 
            this.lbGroups.FormattingEnabled = true;
            this.lbGroups.Location = new System.Drawing.Point(1102, 178);
            this.lbGroups.Name = "lbGroups";
            this.lbGroups.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbGroups.Size = new System.Drawing.Size(150, 134);
            this.lbGroups.TabIndex = 16;
            this.lbGroups.SelectedIndexChanged += new System.EventHandler(this.lbGroups_SelectedIndexChanged);
            // 
            // lblGroups
            // 
            this.lblGroups.AutoSize = true;
            this.lblGroups.Location = new System.Drawing.Point(1099, 162);
            this.lblGroups.Name = "lblGroups";
            this.lblGroups.Size = new System.Drawing.Size(44, 13);
            this.lblGroups.TabIndex = 15;
            this.lblGroups.Text = "Группы";
            // 
            // bt_SecPos
            // 
            this.bt_SecPos.Location = new System.Drawing.Point(369, 639);
            this.bt_SecPos.Name = "bt_SecPos";
            this.bt_SecPos.Size = new System.Drawing.Size(75, 37);
            this.bt_SecPos.TabIndex = 17;
            this.bt_SecPos.Text = "Конечная позиция";
            this.bt_SecPos.UseVisualStyleBackColor = true;
            this.bt_SecPos.Click += new System.EventHandler(this.bt_SecPos_Click);
            // 
            // bt_FirPos
            // 
            this.bt_FirPos.Location = new System.Drawing.Point(288, 639);
            this.bt_FirPos.Name = "bt_FirPos";
            this.bt_FirPos.Size = new System.Drawing.Size(75, 37);
            this.bt_FirPos.TabIndex = 18;
            this.bt_FirPos.Text = "Начальная позиция";
            this.bt_FirPos.UseVisualStyleBackColor = true;
            this.bt_FirPos.Click += new System.EventHandler(this.bt_FirPos_Click);
            // 
            // trb_Morfing
            // 
            this.trb_Morfing.Enabled = false;
            this.trb_Morfing.LargeChange = 10;
            this.trb_Morfing.Location = new System.Drawing.Point(562, 639);
            this.trb_Morfing.Maximum = 100;
            this.trb_Morfing.Name = "trb_Morfing";
            this.trb_Morfing.Size = new System.Drawing.Size(250, 45);
            this.trb_Morfing.TabIndex = 19;
            this.trb_Morfing.Scroll += new System.EventHandler(this.trb_Morfing_Scroll);
            // 
            // tb_Morfing
            // 
            this.tb_Morfing.Location = new System.Drawing.Point(456, 653);
            this.tb_Morfing.Name = "tb_Morfing";
            this.tb_Morfing.Size = new System.Drawing.Size(100, 20);
            this.tb_Morfing.TabIndex = 20;
            this.tb_Morfing.Text = "0";
            this.tb_Morfing.Leave += new System.EventHandler(this.tb_Morfing_Leave);
            // 
            // lblMorfing
            // 
            this.lblMorfing.AutoSize = true;
            this.lblMorfing.Location = new System.Drawing.Point(453, 637);
            this.lblMorfing.Name = "lblMorfing";
            this.lblMorfing.Size = new System.Drawing.Size(53, 13);
            this.lblMorfing.TabIndex = 21;
            this.lblMorfing.Text = "Морфинг";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.lblMorfing);
            this.Controls.Add(this.tb_Morfing);
            this.Controls.Add(this.trb_Morfing);
            this.Controls.Add(this.bt_FirPos);
            this.Controls.Add(this.bt_SecPos);
            this.Controls.Add(this.lbGroups);
            this.Controls.Add(this.lblGroups);
            this.Controls.Add(this.cbShowAxis);
            this.Controls.Add(this.lblMouse);
            this.Controls.Add(this.tbEquation);
            this.Controls.Add(this.lblEquation);
            this.Controls.Add(this.lbPrimitives);
            this.Controls.Add(this.tbYCoord);
            this.Controls.Add(this.labely);
            this.Controls.Add(this.tbXCoord);
            this.Controls.Add(this.labelx);
            this.Controls.Add(this.labelPrimitives);
            this.Controls.Add(this.pbDraw);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Графический редактор";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trb_Morfing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mi_MenuFile;
        private System.Windows.Forms.ToolStripMenuItem mi_MenuImage;
        private System.Windows.Forms.PictureBox pbDraw;
        private System.Windows.Forms.Label labelPrimitives;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.TextBox tbXCoord;
        private System.Windows.Forms.ToolStripMenuItem MenuItemNew;
        private System.Windows.Forms.ToolStripMenuItem MenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem MenuItemSaveAs;
        private System.Windows.Forms.ToolStripMenuItem MenuItemExport;
        private System.Windows.Forms.ToolStripMenuItem MenuItemCreate;
        private System.Windows.Forms.ToolStripMenuItem MenuItemLine;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.TextBox tbYCoord;
        private System.Windows.Forms.Label labely;
        private System.Windows.Forms.ListBox lbPrimitives;
        private System.Windows.Forms.TextBox tbEquation;
        private System.Windows.Forms.Label lblEquation;
        private System.Windows.Forms.Label lblMouse;
        private System.Windows.Forms.CheckBox cbShowAxis;
        private System.Windows.Forms.ListBox lbGroups;
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.ToolStripMenuItem построениеОтрезковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMedian;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAltitude;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBisection;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGroup;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDegroup;
        private System.Windows.Forms.Button bt_SecPos;
        private System.Windows.Forms.Button bt_FirPos;
        private System.Windows.Forms.TrackBar trb_Morfing;
        private System.Windows.Forms.TextBox tb_Morfing;
        private System.Windows.Forms.Label lblMorfing;
    }
}

