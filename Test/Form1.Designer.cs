namespace Test
{
    partial class Form1
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.subCategoriesLB = new System.Windows.Forms.ListBox();
            this.editSubCategBtn = new System.Windows.Forms.Button();
            this.delSubCategBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.categoryLW = new System.Windows.Forms.ListView();
            this.Items = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addCategBtn = new System.Windows.Forms.Button();
            this.editCategBtn = new System.Windows.Forms.Button();
            this.deleteCategBtn = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.subCategoriesLB);
            this.groupBox2.Controls.Add(this.editSubCategBtn);
            this.groupBox2.Controls.Add(this.delSubCategBtn);
            this.groupBox2.Location = new System.Drawing.Point(635, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(516, 372);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Підкатегорії";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(352, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Додати";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // subCategoriesLB
            // 
            this.subCategoriesLB.FormattingEnabled = true;
            this.subCategoriesLB.Location = new System.Drawing.Point(19, 30);
            this.subCategoriesLB.Name = "subCategoriesLB";
            this.subCategoriesLB.Size = new System.Drawing.Size(271, 329);
            this.subCategoriesLB.TabIndex = 8;
            // 
            // editSubCategBtn
            // 
            this.editSubCategBtn.Enabled = false;
            this.editSubCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editSubCategBtn.Location = new System.Drawing.Point(352, 87);
            this.editSubCategBtn.Name = "editSubCategBtn";
            this.editSubCategBtn.Size = new System.Drawing.Size(115, 30);
            this.editSubCategBtn.TabIndex = 7;
            this.editSubCategBtn.Text = "Редагувати";
            this.editSubCategBtn.UseVisualStyleBackColor = true;
            // 
            // delSubCategBtn
            // 
            this.delSubCategBtn.Enabled = false;
            this.delSubCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.delSubCategBtn.Location = new System.Drawing.Point(352, 135);
            this.delSubCategBtn.Name = "delSubCategBtn";
            this.delSubCategBtn.Size = new System.Drawing.Size(115, 30);
            this.delSubCategBtn.TabIndex = 9;
            this.delSubCategBtn.Text = " Видалити";
            this.delSubCategBtn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.categoryLW);
            this.groupBox1.Controls.Add(this.addCategBtn);
            this.groupBox1.Controls.Add(this.editCategBtn);
            this.groupBox1.Controls.Add(this.deleteCategBtn);
            this.groupBox1.Location = new System.Drawing.Point(123, 124);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(449, 372);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Категорії";
            // 
            // categoryLW
            // 
            this.categoryLW.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Items});
            this.categoryLW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.categoryLW.Location = new System.Drawing.Point(22, 30);
            this.categoryLW.Name = "categoryLW";
            this.categoryLW.Size = new System.Drawing.Size(240, 306);
            this.categoryLW.TabIndex = 6;
            this.categoryLW.UseCompatibleStateImageBehavior = false;
            this.categoryLW.View = System.Windows.Forms.View.Details;
            // 
            // Items
            // 
            this.Items.Width = 200;
            // 
            // addCategBtn
            // 
            this.addCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addCategBtn.Location = new System.Drawing.Point(282, 40);
            this.addCategBtn.Name = "addCategBtn";
            this.addCategBtn.Size = new System.Drawing.Size(115, 30);
            this.addCategBtn.TabIndex = 4;
            this.addCategBtn.Text = "Додати";
            this.addCategBtn.UseVisualStyleBackColor = true;
            // 
            // editCategBtn
            // 
            this.editCategBtn.Enabled = false;
            this.editCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editCategBtn.Location = new System.Drawing.Point(282, 87);
            this.editCategBtn.Name = "editCategBtn";
            this.editCategBtn.Size = new System.Drawing.Size(115, 30);
            this.editCategBtn.TabIndex = 2;
            this.editCategBtn.Text = "Редагувати";
            this.editCategBtn.UseVisualStyleBackColor = true;
            // 
            // deleteCategBtn
            // 
            this.deleteCategBtn.Enabled = false;
            this.deleteCategBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteCategBtn.Location = new System.Drawing.Point(282, 135);
            this.deleteCategBtn.Name = "deleteCategBtn";
            this.deleteCategBtn.Size = new System.Drawing.Size(115, 30);
            this.deleteCategBtn.TabIndex = 5;
            this.deleteCategBtn.Text = " Видалити";
            this.deleteCategBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 621);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox subCategoriesLB;
        private System.Windows.Forms.Button editSubCategBtn;
        private System.Windows.Forms.Button delSubCategBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView categoryLW;
        private System.Windows.Forms.ColumnHeader Items;
        private System.Windows.Forms.Button addCategBtn;
        private System.Windows.Forms.Button editCategBtn;
        private System.Windows.Forms.Button deleteCategBtn;
    }
}

