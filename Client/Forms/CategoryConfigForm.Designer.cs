namespace HomeTaxer.Client.Forms
{
    partial class CategoryConfigForm
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
            this.editBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.accountListView = new System.Windows.Forms.ListView();
            this.AccountName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infoLbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // editBtn
            // 
            this.editBtn.Enabled = false;
            this.editBtn.Image = global::HomeTaxer.Client.Properties.Resources.Edit_16x16;
            this.editBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editBtn.Location = new System.Drawing.Point(282, 87);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(115, 30);
            this.editBtn.TabIndex = 2;
            this.editBtn.Text = "Редагувати";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.EditAccount);
            // 
            // addBtn
            // 
            this.addBtn.Image = global::HomeTaxer.Client.Properties.Resources.Add_16x16;
            this.addBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addBtn.Location = new System.Drawing.Point(282, 40);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(115, 30);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Додати";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.AddAccount);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Enabled = false;
            this.deleteBtn.Image = global::HomeTaxer.Client.Properties.Resources.Del_16x16;
            this.deleteBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteBtn.Location = new System.Drawing.Point(282, 135);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(115, 30);
            this.deleteBtn.TabIndex = 5;
            this.deleteBtn.Text = " Видалити";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteAccount);
            // 
            // accountListView
            // 
            this.accountListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AccountName,
            this.Id});
            this.accountListView.GridLines = true;
            this.accountListView.HideSelection = false;
            this.accountListView.Location = new System.Drawing.Point(6, 30);
            this.accountListView.MultiSelect = false;
            this.accountListView.Name = "accountListView";
            this.accountListView.Size = new System.Drawing.Size(230, 269);
            this.accountListView.TabIndex = 6;
            this.accountListView.UseCompatibleStateImageBehavior = false;
            this.accountListView.View = System.Windows.Forms.View.Details;
            this.accountListView.SelectedIndexChanged += new System.EventHandler(this.accountListView_SelectedIndexChanged);
            this.accountListView.Click += new System.EventHandler(this.accountListView_Click);
            // 
            // AccountName
            // 
            this.AccountName.Text = "Назва рахунку";
            this.AccountName.Width = 226;
            // 
            // Id
            // 
            this.Id.Width = 0;
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Location = new System.Drawing.Point(418, 20);
            this.infoLbl.Name = "infoLbl";
            this.infoLbl.Size = new System.Drawing.Size(141, 15);
            this.infoLbl.TabIndex = 7;
            this.infoLbl.Text = "Синхронізація даних. . .";
            this.infoLbl.Visible = false;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Items.AddRange(new object[] {
            "123",
            "156",
            "157"});
            this.listBox1.Location = new System.Drawing.Point(19, 30);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(271, 94);
            this.listBox1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.accountListView);
            this.groupBox1.Controls.Add(this.addBtn);
            this.groupBox1.Controls.Add(this.editBtn);
            this.groupBox1.Controls.Add(this.deleteBtn);
            this.groupBox1.Location = new System.Drawing.Point(25, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 316);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Категорії";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Location = new System.Drawing.Point(537, 51);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 316);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Підкатегорії";
            // 
            // button1
            // 
            this.button1.Image = global::HomeTaxer.Client.Properties.Resources.Add_16x16;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(352, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Image = global::HomeTaxer.Client.Properties.Resources.Edit_16x16;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(352, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 30);
            this.button2.TabIndex = 7;
            this.button2.Text = "Редагувати";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Image = global::HomeTaxer.Client.Properties.Resources.Del_16x16;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(352, 135);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(115, 30);
            this.button3.TabIndex = 9;
            this.button3.Text = " Видалити";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // CategoryConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 447);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.infoLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryConfigForm";
            this.Text = "Редагування категорій";
            this.Load += new System.EventHandler(this.AccountConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListView accountListView;
        private System.Windows.Forms.ColumnHeader AccountName;
        private System.Windows.Forms.ColumnHeader Id;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}