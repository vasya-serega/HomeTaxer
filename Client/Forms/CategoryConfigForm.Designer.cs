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
            this.editCategBtn = new System.Windows.Forms.Button();
            this.addCategBtn = new System.Windows.Forms.Button();
            this.deleteCategBtn = new System.Windows.Forms.Button();
            this.infoLbl = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.subCategoriesLB = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.categoriesLB = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.editSubCategBtn = new System.Windows.Forms.Button();
            this.delSubCategBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // editCategBtn
            // 
            this.editCategBtn.Enabled = false;
            this.editCategBtn.Image = global::HomeTaxer.Client.Properties.Resources.Edit_16x16;
            this.editCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editCategBtn.Location = new System.Drawing.Point(282, 87);
            this.editCategBtn.Name = "editCategBtn";
            this.editCategBtn.Size = new System.Drawing.Size(115, 30);
            this.editCategBtn.TabIndex = 2;
            this.editCategBtn.Text = "Редагувати";
            this.editCategBtn.UseVisualStyleBackColor = true;
            this.editCategBtn.Click += new System.EventHandler(this.EditCategory);
            // 
            // addCategBtn
            // 
            this.addCategBtn.Image = global::HomeTaxer.Client.Properties.Resources.Add_16x16;
            this.addCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addCategBtn.Location = new System.Drawing.Point(282, 40);
            this.addCategBtn.Name = "addCategBtn";
            this.addCategBtn.Size = new System.Drawing.Size(115, 30);
            this.addCategBtn.TabIndex = 4;
            this.addCategBtn.Text = "Додати";
            this.addCategBtn.UseVisualStyleBackColor = true;
            this.addCategBtn.Click += new System.EventHandler(this.AddCategory);
            // 
            // deleteCategBtn
            // 
            this.deleteCategBtn.Enabled = false;
            this.deleteCategBtn.Image = global::HomeTaxer.Client.Properties.Resources.Del_16x16;
            this.deleteCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteCategBtn.Location = new System.Drawing.Point(282, 135);
            this.deleteCategBtn.Name = "deleteCategBtn";
            this.deleteCategBtn.Size = new System.Drawing.Size(115, 30);
            this.deleteCategBtn.TabIndex = 5;
            this.deleteCategBtn.Text = " Видалити";
            this.deleteCategBtn.UseVisualStyleBackColor = true;
            this.deleteCategBtn.Click += new System.EventHandler(this.DeleteCategory);
            // 
            // infoLbl
            // 
            this.infoLbl.AutoSize = true;
            this.infoLbl.Location = new System.Drawing.Point(741, 35);
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
            // subCategoriesLB
            // 
            this.subCategoriesLB.FormattingEnabled = true;
            this.subCategoriesLB.ItemHeight = 15;
            this.subCategoriesLB.Location = new System.Drawing.Point(19, 30);
            this.subCategoriesLB.Name = "subCategoriesLB";
            this.subCategoriesLB.Size = new System.Drawing.Size(271, 334);
            this.subCategoriesLB.TabIndex = 8;
            this.subCategoriesLB.SelectedIndexChanged += new System.EventHandler(this.subCategoriesLB_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.categoriesLB);
            this.groupBox1.Controls.Add(this.addCategBtn);
            this.groupBox1.Controls.Add(this.editCategBtn);
            this.groupBox1.Controls.Add(this.deleteCategBtn);
            this.groupBox1.Location = new System.Drawing.Point(25, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 372);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Категорії";
            // 
            // categoriesLB
            // 
            this.categoriesLB.FormattingEnabled = true;
            this.categoriesLB.ItemHeight = 15;
            this.categoriesLB.Location = new System.Drawing.Point(6, 30);
            this.categoriesLB.Name = "categoriesLB";
            this.categoriesLB.Size = new System.Drawing.Size(260, 334);
            this.categoriesLB.TabIndex = 6;
            this.categoriesLB.SelectedIndexChanged += new System.EventHandler(this.categoriesLB_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.subCategoriesLB);
            this.groupBox2.Controls.Add(this.editSubCategBtn);
            this.groupBox2.Controls.Add(this.delSubCategBtn);
            this.groupBox2.Location = new System.Drawing.Point(537, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 372);
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
            this.button1.Click += new System.EventHandler(this.AddSubCategory);
            // 
            // editSubCategBtn
            // 
            this.editSubCategBtn.Enabled = false;
            this.editSubCategBtn.Image = global::HomeTaxer.Client.Properties.Resources.Edit_16x16;
            this.editSubCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editSubCategBtn.Location = new System.Drawing.Point(352, 87);
            this.editSubCategBtn.Name = "editSubCategBtn";
            this.editSubCategBtn.Size = new System.Drawing.Size(115, 30);
            this.editSubCategBtn.TabIndex = 7;
            this.editSubCategBtn.Text = "Редагувати";
            this.editSubCategBtn.UseVisualStyleBackColor = true;
            this.editSubCategBtn.Click += new System.EventHandler(this.EditSubCategory);
            // 
            // delSubCategBtn
            // 
            this.delSubCategBtn.Enabled = false;
            this.delSubCategBtn.Image = global::HomeTaxer.Client.Properties.Resources.Del_16x16;
            this.delSubCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delSubCategBtn.Location = new System.Drawing.Point(352, 135);
            this.delSubCategBtn.Name = "delSubCategBtn";
            this.delSubCategBtn.Size = new System.Drawing.Size(115, 30);
            this.delSubCategBtn.TabIndex = 9;
            this.delSubCategBtn.Text = " Видалити";
            this.delSubCategBtn.UseVisualStyleBackColor = true;
            this.delSubCategBtn.Click += new System.EventHandler(this.DelSubCategory);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(312, 27);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(120, 30);
            this.saveBtn.TabIndex = 11;
            this.saveBtn.Text = "Зберегти зміни";
            this.saveBtn.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(583, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(120, 30);
            this.button4.TabIndex = 12;
            this.button4.Text = "Відхилити зміни";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // CategoryConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 474);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.infoLbl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryConfigForm";
            this.Text = "Редагування категорій";
            this.Load += new System.EventHandler(this.CategoryConfigForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button editCategBtn;
        private System.Windows.Forms.Button addCategBtn;
        private System.Windows.Forms.Button deleteCategBtn;
        private System.Windows.Forms.Label infoLbl;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox subCategoriesLB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button editSubCategBtn;
        private System.Windows.Forms.Button delSubCategBtn;
        private System.Windows.Forms.ListBox categoriesLB;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button saveBtn;
    }
}