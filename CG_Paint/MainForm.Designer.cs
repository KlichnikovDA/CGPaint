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
            this.построениеОтрезковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemMedian = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemAltitude = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemBisection = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDegroup = new System.Windows.Forms.ToolStripMenuItem();
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
            this.btApplyOne = new System.Windows.Forms.Button();
            this.btApplyTwo = new System.Windows.Forms.Button();
            this.lbGroups = new System.Windows.Forms.ListBox();
            this.lblGroups = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDraw)).BeginInit();
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
            this.построениеОтрезковToolStripMenuItem,
            this.MenuItemGroup,
            this.MenuItemDegroup});
            this.mi_MenuImage.Name = "mi_MenuImage";
            this.mi_MenuImage.Size = new System.Drawing.Size(95, 20);
            this.mi_MenuImage.Text = "Изображение";
            // 
            // MenuItemCreate
            // 
            this.MenuItemCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLine});
            this.MenuItemCreate.Name = "MenuItemCreate";
            this.MenuItemCreate.Size = new System.Drawing.Size(202, 22);
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
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.MenuItemDelete.Size = new System.Drawing.Size(202, 22);
            this.MenuItemDelete.Text = "Удалить";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // построениеОтрезковToolStripMenuItem
            // 
            this.построениеОтрезковToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemMedian,
            this.MenuItemAltitude,
            this.MenuItemBisection});
            this.построениеОтрезковToolStripMenuItem.Name = "построениеОтрезковToolStripMenuItem";
            this.построениеОтрезковToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.построениеОтрезковToolStripMenuItem.Text = "Построение отрезков";
            // 
            // MenuItemMedian
            // 
            this.MenuItemMedian.Name = "MenuItemMedian";
            this.MenuItemMedian.Size = new System.Drawing.Size(180, 22);
            this.MenuItemMedian.Text = "Медиана";
            // 
            // MenuItemAltitude
            // 
            this.MenuItemAltitude.Name = "MenuItemAltitude";
            this.MenuItemAltitude.Size = new System.Drawing.Size(180, 22);
            this.MenuItemAltitude.Text = "Высота";
            // 
            // MenuItemBisection
            // 
            this.MenuItemBisection.Name = "MenuItemBisection";
            this.MenuItemBisection.Size = new System.Drawing.Size(180, 22);
            this.MenuItemBisection.Text = "Биссектриса";
            // 
            // MenuItemGroup
            // 
            this.MenuItemGroup.Name = "MenuItemGroup";
            this.MenuItemGroup.Size = new System.Drawing.Size(202, 22);
            this.MenuItemGroup.Text = "Сгруппировать";
            this.MenuItemGroup.Click += new System.EventHandler(this.MenuItemGroup_Click);
            // 
            // MenuItemDegroup
            // 
            this.MenuItemDegroup.Name = "MenuItemDegroup";
            this.MenuItemDegroup.Size = new System.Drawing.Size(202, 22);
            this.MenuItemDegroup.Text = "Отменить группировку";
            this.MenuItemDegroup.Click += new System.EventHandler(this.MenuItemDegroup_Click);
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
            this.labelx.Location = new System.Drawing.Point(917, 37);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(146, 13);
            this.labelx.TabIndex = 4;
            this.labelx.Text = "Координаты первого конца";
            // 
            // tbXCoord
            // 
            this.tbXCoord.Enabled = false;
            this.tbXCoord.Location = new System.Drawing.Point(1069, 34);
            this.tbXCoord.Name = "tbXCoord";
            this.tbXCoord.Size = new System.Drawing.Size(100, 20);
            this.tbXCoord.TabIndex = 5;
            // 
            // tbYCoord
            // 
            this.tbYCoord.Enabled = false;
            this.tbYCoord.Location = new System.Drawing.Point(1069, 60);
            this.tbYCoord.Name = "tbYCoord";
            this.tbYCoord.Size = new System.Drawing.Size(100, 20);
            this.tbYCoord.TabIndex = 7;
            // 
            // labely
            // 
            this.labely.AutoSize = true;
            this.labely.Location = new System.Drawing.Point(918, 57);
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
            // btApplyOne
            // 
            this.btApplyOne.Location = new System.Drawing.Point(1177, 34);
            this.btApplyOne.Name = "btApplyOne";
            this.btApplyOne.Size = new System.Drawing.Size(75, 22);
            this.btApplyOne.TabIndex = 13;
            this.btApplyOne.Text = "Задать";
            this.btApplyOne.UseVisualStyleBackColor = true;
            this.btApplyOne.Click += new System.EventHandler(this.btApplyOne_Click);
            // 
            // btApplyTwo
            // 
            this.btApplyTwo.Location = new System.Drawing.Point(1177, 58);
            this.btApplyTwo.Name = "btApplyTwo";
            this.btApplyTwo.Size = new System.Drawing.Size(75, 22);
            this.btApplyTwo.TabIndex = 14;
            this.btApplyTwo.Text = "Задать";
            this.btApplyTwo.UseVisualStyleBackColor = true;
            this.btApplyTwo.Click += new System.EventHandler(this.btApplyTwo_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.lbGroups);
            this.Controls.Add(this.lblGroups);
            this.Controls.Add(this.btApplyTwo);
            this.Controls.Add(this.btApplyOne);
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
        private System.Windows.Forms.Button btApplyOne;
        private System.Windows.Forms.Button btApplyTwo;
        private System.Windows.Forms.ListBox lbGroups;
        private System.Windows.Forms.Label lblGroups;
        private System.Windows.Forms.ToolStripMenuItem построениеОтрезковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuItemMedian;
        private System.Windows.Forms.ToolStripMenuItem MenuItemAltitude;
        private System.Windows.Forms.ToolStripMenuItem MenuItemBisection;
        private System.Windows.Forms.ToolStripMenuItem MenuItemGroup;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDegroup;
    }
}

