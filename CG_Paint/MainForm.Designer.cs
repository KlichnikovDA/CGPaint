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
            this.pbDraw = new System.Windows.Forms.PictureBox();
            this.labelPrimitives = new System.Windows.Forms.Label();
            this.labelx = new System.Windows.Forms.Label();
            this.tbXCoord = new System.Windows.Forms.TextBox();
            this.tbYCoord = new System.Windows.Forms.TextBox();
            this.labely = new System.Windows.Forms.Label();
            this.lbPrimitives = new System.Windows.Forms.ListBox();
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
            this.MenuItemNew.Size = new System.Drawing.Size(180, 22);
            this.MenuItemNew.Text = "Новый";
            this.MenuItemNew.Click += new System.EventHandler(this.MenuItemNew_Click);
            // 
            // MenuItemOpen
            // 
            this.MenuItemOpen.Name = "MenuItemOpen";
            this.MenuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.MenuItemOpen.Size = new System.Drawing.Size(180, 22);
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
            this.MenuItemExport.Size = new System.Drawing.Size(180, 22);
            this.MenuItemExport.Text = "Экспорт в JPG";
            this.MenuItemExport.Click += new System.EventHandler(this.MenuItemExport_Click);
            // 
            // mi_MenuImage
            // 
            this.mi_MenuImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemCreate,
            this.MenuItemDelete});
            this.mi_MenuImage.Name = "mi_MenuImage";
            this.mi_MenuImage.Size = new System.Drawing.Size(95, 20);
            this.mi_MenuImage.Text = "Изображение";
            // 
            // MenuItemCreate
            // 
            this.MenuItemCreate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemLine});
            this.MenuItemCreate.Name = "MenuItemCreate";
            this.MenuItemCreate.Size = new System.Drawing.Size(180, 22);
            this.MenuItemCreate.Text = "Создать";
            // 
            // MenuItemLine
            // 
            this.MenuItemLine.Name = "MenuItemLine";
            this.MenuItemLine.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.L)));
            this.MenuItemLine.Size = new System.Drawing.Size(180, 22);
            this.MenuItemLine.Text = "Прямая";
            this.MenuItemLine.Click += new System.EventHandler(this.MenuItemLine_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.MenuItemDelete.Size = new System.Drawing.Size(180, 22);
            this.MenuItemDelete.Text = "Удалить";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // pbDraw
            // 
            this.pbDraw.BackColor = System.Drawing.Color.White;
            this.pbDraw.Location = new System.Drawing.Point(12, 27);
            this.pbDraw.Name = "pbDraw";
            this.pbDraw.Size = new System.Drawing.Size(1000, 600);
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
            this.labelPrimitives.Location = new System.Drawing.Point(1018, 207);
            this.labelPrimitives.Name = "labelPrimitives";
            this.labelPrimitives.Size = new System.Drawing.Size(108, 13);
            this.labelPrimitives.TabIndex = 3;
            this.labelPrimitives.Text = "Список примитивов";
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(1018, 34);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(77, 13);
            this.labelx.TabIndex = 4;
            this.labelx.Text = "Координата X";
            // 
            // tbXCoord
            // 
            this.tbXCoord.Enabled = false;
            this.tbXCoord.Location = new System.Drawing.Point(1101, 31);
            this.tbXCoord.Name = "tbXCoord";
            this.tbXCoord.Size = new System.Drawing.Size(100, 20);
            this.tbXCoord.TabIndex = 5;
            // 
            // tbYCoord
            // 
            this.tbYCoord.Enabled = false;
            this.tbYCoord.Location = new System.Drawing.Point(1101, 57);
            this.tbYCoord.Name = "tbYCoord";
            this.tbYCoord.Size = new System.Drawing.Size(100, 20);
            this.tbYCoord.TabIndex = 7;
            // 
            // labely
            // 
            this.labely.AutoSize = true;
            this.labely.Location = new System.Drawing.Point(1018, 60);
            this.labely.Name = "labely";
            this.labely.Size = new System.Drawing.Size(77, 13);
            this.labely.TabIndex = 6;
            this.labely.Text = "Координата Y";
            // 
            // lbPrimitives
            // 
            this.lbPrimitives.FormattingEnabled = true;
            this.lbPrimitives.Location = new System.Drawing.Point(1018, 223);
            this.lbPrimitives.Name = "lbPrimitives";
            this.lbPrimitives.Size = new System.Drawing.Size(234, 407);
            this.lbPrimitives.TabIndex = 8;
            this.lbPrimitives.SelectedIndexChanged += new System.EventHandler(this.lbPrimitives_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
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
    }
}

