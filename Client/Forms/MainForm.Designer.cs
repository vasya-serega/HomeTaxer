namespace HomeTaxer.Client.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.addBtn = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.опціїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountConfigMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.довідкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.проПрограмуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.dataTab = new System.Windows.Forms.TabPage();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.mainDataGW = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubcategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subCategoryCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrencyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reportsTab = new System.Windows.Forms.TabPage();
            this.customProgrBar = new CustomProgressBar.CustomProgressBar();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.progErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorLabel = new System.Windows.Forms.Label();
            this.accountLbl = new System.Windows.Forms.Label();
            this.curAccountNameCB = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.dataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.progErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // addBtn
            // 
            this.addBtn.BackColor = System.Drawing.Color.Transparent;
            this.addBtn.Enabled = false;
            this.addBtn.Image = global::HomeTaxer.Client.Properties.Resources.Add_24x24;
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addBtn.Location = new System.Drawing.Point(64, 574);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(115, 32);
            this.addBtn.TabIndex = 0;
            this.addBtn.Text = "Додати";
            this.addBtn.UseVisualStyleBackColor = false;
            this.addBtn.EnabledChanged += new System.EventHandler(this.addItemBtn_EnabledChanged);
            this.addBtn.Click += new System.EventHandler(this.AddOborot);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.optionsMenuItem,
            this.довідкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1294, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "&Файл";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(102, 22);
            this.exitMenuItem.Text = "&Вихід";
            this.exitMenuItem.Click += new System.EventHandler(this.exitMenuItem_Click);
            // 
            // optionsMenuItem
            // 
            this.optionsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.опціїToolStripMenuItem,
            this.accountConfigMenuItem});
            this.optionsMenuItem.Name = "optionsMenuItem";
            this.optionsMenuItem.Size = new System.Drawing.Size(101, 20);
            this.optionsMenuItem.Text = "&Налаштування";
            // 
            // опціїToolStripMenuItem
            // 
            this.опціїToolStripMenuItem.Name = "опціїToolStripMenuItem";
            this.опціїToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
            this.опціїToolStripMenuItem.Text = "&Опції";
            this.опціїToolStripMenuItem.Click += new System.EventHandler(this.optionsMenuItem_Click);
            // 
            // accountConfigMenuItem
            // 
            this.accountConfigMenuItem.Name = "accountConfigMenuItem";
            this.accountConfigMenuItem.Size = new System.Drawing.Size(118, 22);
            this.accountConfigMenuItem.Text = "&Рахунки";
            this.accountConfigMenuItem.Click += new System.EventHandler(this.EditAccounts);
            // 
            // довідкаToolStripMenuItem
            // 
            this.довідкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.проПрограмуToolStripMenuItem});
            this.довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            this.довідкаToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.довідкаToolStripMenuItem.Text = "&Довідка";
            // 
            // проПрограмуToolStripMenuItem
            // 
            this.проПрограмуToolStripMenuItem.Name = "проПрограмуToolStripMenuItem";
            this.проПрограмуToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.проПрограмуToolStripMenuItem.Text = "Про програму";
            this.проПрограмуToolStripMenuItem.Click += new System.EventHandler(this.ShowAboutBox);
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.dataTab);
            this.mainTabControl.Controls.Add(this.reportsTab);
            this.mainTabControl.Location = new System.Drawing.Point(0, 89);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1294, 666);
            this.mainTabControl.TabIndex = 2;
            // 
            // dataTab
            // 
            this.dataTab.Controls.Add(this.deleteBtn);
            this.dataTab.Controls.Add(this.editBtn);
            this.dataTab.Controls.Add(this.mainDataGW);
            this.dataTab.Controls.Add(this.addBtn);
            this.dataTab.Location = new System.Drawing.Point(4, 24);
            this.dataTab.Name = "dataTab";
            this.dataTab.Padding = new System.Windows.Forms.Padding(3);
            this.dataTab.Size = new System.Drawing.Size(1286, 638);
            this.dataTab.TabIndex = 0;
            this.dataTab.Text = " Дані (перегляд\\правка) ";
            this.dataTab.UseVisualStyleBackColor = true;
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Location = new System.Drawing.Point(491, 574);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(115, 32);
            this.deleteBtn.TabIndex = 3;
            this.deleteBtn.Text = "Видалити";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.EnabledChanged += new System.EventHandler(this.deleteBtn_EnabledChanged);
            this.deleteBtn.Click += new System.EventHandler(this.DeleteOborot);
            // 
            // editBtn
            // 
            this.editBtn.Enabled = false;
            this.editBtn.Image = global::HomeTaxer.Client.Properties.Resources.EditColor_16x16;
            this.editBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editBtn.Location = new System.Drawing.Point(276, 574);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(115, 32);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Редагувати ";
            this.editBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.EnabledChanged += new System.EventHandler(this.editBtn_EnabledChanged);
            this.editBtn.Click += new System.EventHandler(this.EditOborot);
            // 
            // mainDataGW
            // 
            this.mainDataGW.AllowUserToAddRows = false;
            this.mainDataGW.AllowUserToDeleteRows = false;
            this.mainDataGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dateCol,
            this.CategoryId,
            this.categoryCol,
            this.SubcategoryId,
            this.subCategoryCol,
            this.CountCol,
            this.amountCol,
            this.CurrencyId,
            this.CurrencyCol,
            this.descCol});
            this.mainDataGW.Location = new System.Drawing.Point(3, 17);
            this.mainDataGW.MultiSelect = false;
            this.mainDataGW.Name = "mainDataGW";
            this.mainDataGW.RowHeadersWidth = 50;
            this.mainDataGW.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.mainDataGW.Size = new System.Drawing.Size(1277, 523);
            this.mainDataGW.TabIndex = 1;
            this.mainDataGW.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.mainDataGW_CellMouseDown);
            this.mainDataGW.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.mainDataGW_RowStateChanged);
            // 
            // Id
            // 
            this.Id.HeaderText = "OborotId";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // dateCol
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.dateCol.DefaultCellStyle = dataGridViewCellStyle1;
            this.dateCol.HeaderText = "Дата";
            this.dateCol.Name = "dateCol";
            this.dateCol.ReadOnly = true;
            // 
            // CategoryId
            // 
            this.CategoryId.HeaderText = "CategoryId";
            this.CategoryId.Name = "CategoryId";
            this.CategoryId.Visible = false;
            // 
            // categoryCol
            // 
            this.categoryCol.HeaderText = "Категорія";
            this.categoryCol.Name = "categoryCol";
            this.categoryCol.ReadOnly = true;
            // 
            // SubcategoryId
            // 
            this.SubcategoryId.HeaderText = "SubcategoryId";
            this.SubcategoryId.Name = "SubcategoryId";
            this.SubcategoryId.Visible = false;
            // 
            // subCategoryCol
            // 
            this.subCategoryCol.HeaderText = "Підкатегорія";
            this.subCategoryCol.Name = "subCategoryCol";
            this.subCategoryCol.ReadOnly = true;
            // 
            // CountCol
            // 
            this.CountCol.HeaderText = "Кількість";
            this.CountCol.Name = "CountCol";
            // 
            // amountCol
            // 
            this.amountCol.HeaderText = "Сума";
            this.amountCol.Name = "amountCol";
            this.amountCol.ReadOnly = true;
            // 
            // CurrencyId
            // 
            this.CurrencyId.HeaderText = "CurrencyId";
            this.CurrencyId.Name = "CurrencyId";
            this.CurrencyId.Visible = false;
            // 
            // CurrencyCol
            // 
            this.CurrencyCol.HeaderText = "Валюта";
            this.CurrencyCol.Name = "CurrencyCol";
            // 
            // descCol
            // 
            this.descCol.HeaderText = "Додаткова інформація";
            this.descCol.Name = "descCol";
            this.descCol.ReadOnly = true;
            this.descCol.Width = 250;
            // 
            // reportsTab
            // 
            this.reportsTab.Location = new System.Drawing.Point(4, 24);
            this.reportsTab.Name = "reportsTab";
            this.reportsTab.Padding = new System.Windows.Forms.Padding(3);
            this.reportsTab.Size = new System.Drawing.Size(1286, 638);
            this.reportsTab.TabIndex = 1;
            this.reportsTab.Text = " Звіти ";
            this.reportsTab.UseVisualStyleBackColor = true;
            // 
            // customProgrBar
            // 
            this.customProgrBar.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.customProgrBar.Location = new System.Drawing.Point(966, 49);
            this.customProgrBar.Marquee = true;
            this.customProgrBar.Maximum = 200;
            this.customProgrBar.Name = "customProgrBar";
            this.customProgrBar.Size = new System.Drawing.Size(130, 16);
            this.customProgrBar.TabIndex = 28;
            this.customProgrBar.Text = "customProgressBar1";
            this.customProgrBar.Visible = false;
            // 
            // progressTimer
            // 
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // progErrorProvider
            // 
            this.progErrorProvider.ContainerControl = this;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.errorLabel.Location = new System.Drawing.Point(1102, 49);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(144, 15);
            this.errorLabel.TabIndex = 29;
            this.errorLabel.Text = "Дані не синхронізовано";
            this.errorLabel.Visible = false;
            // 
            // accountLbl
            // 
            this.accountLbl.AutoSize = true;
            this.accountLbl.Location = new System.Drawing.Point(40, 45);
            this.accountLbl.Name = "accountLbl";
            this.accountLbl.Size = new System.Drawing.Size(112, 15);
            this.accountLbl.TabIndex = 30;
            this.accountLbl.Text = "Поточний рахунок";
            // 
            // curAccountNameCB
            // 
            this.curAccountNameCB.Enabled = false;
            this.curAccountNameCB.FormattingEnabled = true;
            this.curAccountNameCB.Location = new System.Drawing.Point(168, 42);
            this.curAccountNameCB.Name = "curAccountNameCB";
            this.curAccountNameCB.Size = new System.Drawing.Size(152, 23);
            this.curAccountNameCB.TabIndex = 31;
            this.curAccountNameCB.SelectedIndexChanged += new System.EventHandler(this.ChangeAccountName);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 752);
            this.Controls.Add(this.curAccountNameCB);
            this.Controls.Add(this.accountLbl);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.customProgrBar);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Домашня бухгалтерія";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.mainTabControl.ResumeLayout(false);
            this.dataTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.progErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem довідкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem проПрограмуToolStripMenuItem;
        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage dataTab;
        private System.Windows.Forms.TabPage reportsTab;
        private System.Windows.Forms.DataGridView mainDataGW;
        private System.Windows.Forms.ToolStripMenuItem optionsMenuItem;
        private CustomProgressBar.CustomProgressBar customProgrBar;
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.ErrorProvider progErrorProvider;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubcategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn subCategoryCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrencyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn descCol;
        private System.Windows.Forms.ComboBox curAccountNameCB;
        private System.Windows.Forms.Label accountLbl;
        private System.Windows.Forms.ToolStripMenuItem опціїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem accountConfigMenuItem;
    }
}

