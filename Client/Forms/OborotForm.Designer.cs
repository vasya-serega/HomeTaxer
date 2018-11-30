namespace HomeTaxer.Client.Forms
{
    partial class OborotForm
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
            this.dateLabel = new System.Windows.Forms.Label();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.subcategoryLabel = new System.Windows.Forms.Label();
            this.countLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.descLabel = new System.Windows.Forms.Label();
            this.dateTP = new System.Windows.Forms.DateTimePicker();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.subcategoryComboBox = new System.Windows.Forms.ComboBox();
            this.countTextBox = new System.Windows.Forms.TextBox();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.addMoreBtn = new System.Windows.Forms.Button();
            this.countErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.amountErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.currencyLbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.countErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // dateLabel
            // 
            this.dateLabel.AutoSize = true;
            this.dateLabel.Location = new System.Drawing.Point(83, 27);
            this.dateLabel.Name = "dateLabel";
            this.dateLabel.Size = new System.Drawing.Size(37, 15);
            this.dateLabel.TabIndex = 0;
            this.dateLabel.Text = "Дата";
            // 
            // categoryLabel
            // 
            this.categoryLabel.AutoSize = true;
            this.categoryLabel.Location = new System.Drawing.Point(54, 59);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(65, 15);
            this.categoryLabel.TabIndex = 1;
            this.categoryLabel.Text = "Категорія";
            // 
            // subcategoryLabel
            // 
            this.subcategoryLabel.AutoSize = true;
            this.subcategoryLabel.Location = new System.Drawing.Point(37, 97);
            this.subcategoryLabel.Name = "subcategoryLabel";
            this.subcategoryLabel.Size = new System.Drawing.Size(82, 15);
            this.subcategoryLabel.TabIndex = 2;
            this.subcategoryLabel.Text = "Підкатегорія";
            // 
            // countLabel
            // 
            this.countLabel.AutoSize = true;
            this.countLabel.Location = new System.Drawing.Point(58, 136);
            this.countLabel.Name = "countLabel";
            this.countLabel.Size = new System.Drawing.Size(61, 15);
            this.countLabel.TabIndex = 3;
            this.countLabel.Text = "Кількість";
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(83, 168);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(36, 15);
            this.amountLabel.TabIndex = 4;
            this.amountLabel.Text = "Сума";
            // 
            // descLabel
            // 
            this.descLabel.AutoSize = true;
            this.descLabel.Location = new System.Drawing.Point(57, 203);
            this.descLabel.Name = "descLabel";
            this.descLabel.Size = new System.Drawing.Size(62, 15);
            this.descLabel.TabIndex = 5;
            this.descLabel.Text = "Примітка";
            // 
            // dateTP
            // 
            this.dateTP.Location = new System.Drawing.Point(137, 22);
            this.dateTP.Name = "dateTP";
            this.dateTP.Size = new System.Drawing.Size(206, 21);
            this.dateTP.TabIndex = 8;
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(137, 56);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(206, 23);
            this.categoryComboBox.Sorted = true;
            this.categoryComboBox.TabIndex = 9;
            this.categoryComboBox.SelectedIndexChanged += new System.EventHandler(this.categoryComboBox_SelectedIndexChanged);
            // 
            // subcategoryComboBox
            // 
            this.subcategoryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subcategoryComboBox.Enabled = false;
            this.subcategoryComboBox.Location = new System.Drawing.Point(137, 94);
            this.subcategoryComboBox.Name = "subcategoryComboBox";
            this.subcategoryComboBox.Size = new System.Drawing.Size(206, 23);
            this.subcategoryComboBox.Sorted = true;
            this.subcategoryComboBox.TabIndex = 10;
            // 
            // countTextBox
            // 
            this.countTextBox.Location = new System.Drawing.Point(137, 133);
            this.countTextBox.Name = "countTextBox";
            this.countTextBox.Size = new System.Drawing.Size(100, 21);
            this.countTextBox.TabIndex = 11;
            this.countTextBox.Text = "1";
            this.countTextBox.TextChanged += new System.EventHandler(this.countTextBox_TextChanged);
            this.countTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.countTextBox_Validating);
            // 
            // amountTextBox
            // 
            this.amountTextBox.Location = new System.Drawing.Point(137, 168);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(100, 21);
            this.amountTextBox.TabIndex = 12;
            this.amountTextBox.Text = "0";
            this.amountTextBox.TextChanged += new System.EventHandler(this.amountTextBox_TextChanged);
            this.amountTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.amountTextBox_Validating);
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(137, 203);
            this.descTextBox.Multiline = true;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(284, 71);
            this.descTextBox.TabIndex = 13;
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.LightGreen;
            this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okBtn.Location = new System.Drawing.Point(181, 300);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(110, 30);
            this.okBtn.TabIndex = 14;
            this.okBtn.Text = "Зберегти";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.BackColor = System.Drawing.Color.Thistle;
            this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelBtn.Location = new System.Drawing.Point(325, 300);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(110, 30);
            this.cancelBtn.TabIndex = 15;
            this.cancelBtn.Text = "Відміна";
            this.cancelBtn.UseVisualStyleBackColor = false;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addMoreBtn
            // 
            this.addMoreBtn.BackColor = System.Drawing.Color.LightGreen;
            this.addMoreBtn.Location = new System.Drawing.Point(40, 300);
            this.addMoreBtn.Name = "addMoreBtn";
            this.addMoreBtn.Size = new System.Drawing.Size(110, 30);
            this.addMoreBtn.TabIndex = 16;
            this.addMoreBtn.Text = "Ще";
            this.addMoreBtn.UseVisualStyleBackColor = false;
            this.addMoreBtn.Click += new System.EventHandler(this.addMoreBtn_Click);
            // 
            // countErrorProvider
            // 
            this.countErrorProvider.ContainerControl = this;
            // 
            // amountErrorProvider
            // 
            this.amountErrorProvider.ContainerControl = this;
            // 
            // currencyLbl
            // 
            this.currencyLbl.AutoSize = true;
            this.currencyLbl.Location = new System.Drawing.Point(243, 171);
            this.currencyLbl.Name = "currencyLbl";
            this.currencyLbl.Size = new System.Drawing.Size(0, 15);
            this.currencyLbl.TabIndex = 17;
            // 
            // OborotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelBtn;
            this.ClientSize = new System.Drawing.Size(471, 347);
            this.Controls.Add(this.currencyLbl);
            this.Controls.Add(this.addMoreBtn);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.amountTextBox);
            this.Controls.Add(this.countTextBox);
            this.Controls.Add(this.subcategoryComboBox);
            this.Controls.Add(this.categoryComboBox);
            this.Controls.Add(this.dateTP);
            this.Controls.Add(this.descLabel);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.countLabel);
            this.Controls.Add(this.subcategoryLabel);
            this.Controls.Add(this.categoryLabel);
            this.Controls.Add(this.dateLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "OborotForm";
            this.Text = "AddOborotForm";
            this.Load += new System.EventHandler(this.OborotForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.countErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amountErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLabel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Label subcategoryLabel;
        private System.Windows.Forms.Label countLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.Label descLabel;
        private System.Windows.Forms.DateTimePicker dateTP;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.ComboBox subcategoryComboBox;
        private System.Windows.Forms.TextBox countTextBox;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button addMoreBtn;
        private System.Windows.Forms.ErrorProvider countErrorProvider;
        private System.Windows.Forms.ErrorProvider amountErrorProvider;
        private System.Windows.Forms.Label currencyLbl;
    }
}