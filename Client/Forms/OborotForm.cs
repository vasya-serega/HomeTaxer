using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows.Forms;
using HomeTaxer.Client.Configuration;
using HomeTaxer.Client.HomeTaxesReference;
using HomeTaxer.Client.Services;

namespace HomeTaxer.Client.Forms
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public partial class OborotForm : Form
    {
        private readonly HtService _service;
        private readonly int _defaultCurrencyId;
        private readonly List<Oborot> _insertedOborots = new List<Oborot>();

        public OborotForm(HtService htService, Oborot existingOborot = null)
        {
            InitializeComponent();
            _service = htService;

            _defaultCurrencyId = Config.Instance.CurrencyId;
            currencyLbl.Text = _defaultCurrencyId == 1 ? "грн." : "<ім'я валюти>";

            if (existingOborot != null)
            {
                UpdatedOborot = existingOborot;
                addMoreBtn.Enabled = false;
            }
        }

        public List<Oborot> InsertedOborots => new List<Oborot>(_insertedOborots);

        public Oborot UpdatedOborot { get; private set; }

        #region Event Handlers
        private void OborotForm_Load(object sender, EventArgs e)
        {
            if (!_service.IsDictOptionsLoaded)
            {
                MessageBox.Show("Dictionaries are not loaded yet.", "Please try add a record again",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            FillCategories();
            InitByExistingOborot();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void categoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selCat = (Category)categoryComboBox.SelectedItem;
            if (selCat == null)
            {
                subcategoryComboBox.Enabled = false;
                return;
            }

            if (!selCat.SubCategories.ContainsKey(0))
            {
                selCat.SubCategories.Add(0, string.Empty);
            }
            subcategoryComboBox.DataSource = new BindingSource(selCat.SubCategories, null);
            subcategoryComboBox.DisplayMember = "Value";
            subcategoryComboBox.ValueMember = "Key";
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (UpdatedOborot == null)
            {
                AddCopmletedOborot();
            }
            else
            {
                UpdateExistingOborot();
            }
        }

        private void addMoreBtn_Click(object sender, EventArgs e)
        {
            AddCopmletedOborot();
            SetDefaultControlValues();
        }

        private void countTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var countVal = countTextBox.Text.Replace(".", ",");
            if (!double.TryParse(countVal, out _))
            {
                countErrorProvider.SetError(countTextBox, "Невірний формат. Десь помилилися?");
            }
            else
            {
                countErrorProvider.Clear();
            }
            SetSaveBtnSate();
        }

        private void amountTextBox_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var amountVal = amountTextBox.Text.Replace(".", ",");
            if (!decimal.TryParse(amountVal, out _))
            {
                amountErrorProvider.SetError(amountTextBox, "Невірний формат. Десь помилилися?");
            }
            else
            {
                amountErrorProvider.Clear();
            }
            SetSaveBtnSate();
        }

        private void countTextBox_TextChanged(object sender, EventArgs e)
        {
            SetSaveBtnSate();
        }

        private void amountTextBox_TextChanged(object sender, EventArgs e)
        {
            SetSaveBtnSate();
        }
        #endregion

        private void FillCategories()
        {
            categoryComboBox.DataSource = new BindingSource(_service.Categories, null);
            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.ValueMember = "Id";

            if (categoryComboBox.SelectedItem != null)
            {
                subcategoryComboBox.Enabled = true;
            }
        }

        private bool IsSaveEnabled()
        {
            var isCountFilled = countTextBox.Text.Length > 0;
            var isAmountFilled = amountTextBox.Text.Length > 0;
            var noErrors = string.IsNullOrEmpty(countErrorProvider.GetError(countTextBox)) &&
                           string.IsNullOrEmpty(amountErrorProvider.GetError(amountTextBox));

            return isCountFilled && isAmountFilled && noErrors;
        }

        private void SetSaveBtnSate()
        {
            if (IsSaveEnabled())
            {
                okBtn.Enabled = true;
                okBtn.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                okBtn.Enabled = false;
                okBtn.BackColor = System.Drawing.Color.LightGray;
            }
        }

        private void AddCopmletedOborot()
        {
            var newOborot = new Oborot();
            newOborot.AccountNameId = _service.AccountNameId;
            newOborot.Date = DateTime.Now;
            newOborot.CategoryId = ((Category)categoryComboBox.SelectedItem).Id;
            var subCategoryItem = (KeyValuePair<int, string>)subcategoryComboBox.SelectedItem;
            if (!string.IsNullOrEmpty(subCategoryItem.Value))
            {
                newOborot.SubCategoryId = subCategoryItem.Key;
            }
            newOborot.Count = Convert.ToDouble(countTextBox.Text.Replace(".", ","));
            newOborot.Summa = Convert.ToDecimal(amountTextBox.Text.Replace(".", ","));
            newOborot.CurrencyId = _defaultCurrencyId;
            newOborot.Note = descTextBox.Text;

            _insertedOborots.Add(newOborot);
        }

        private void UpdateExistingOborot()
        {
            UpdatedOborot.Date = dateTP.Value;
            UpdatedOborot.CategoryId = ((Category)categoryComboBox.SelectedItem).Id;
            var subCategoryItem = (KeyValuePair<int, string>)subcategoryComboBox.SelectedItem;
            if (!string.IsNullOrEmpty(subCategoryItem.Value))
            {
                UpdatedOborot.SubCategoryId = subCategoryItem.Key;
            }
            UpdatedOborot.Count = Convert.ToDouble(countTextBox.Text.Replace(".", ","));
            UpdatedOborot.Summa = Convert.ToDecimal(amountTextBox.Text.Replace(".", ","));
            UpdatedOborot.CurrencyId = _defaultCurrencyId;
            UpdatedOborot.Note = descTextBox.Text;
        }

        private void SetDefaultControlValues()
        {
            countTextBox.Text = "1";
            amountTextBox.Text = "0";
            descTextBox.Text = null;
        }

        private void InitByExistingOborot()
        {
            if (UpdatedOborot == null)
            {
                return;
            }

            dateTP.Value = UpdatedOborot.Date;

            var selCategory = _service.Categories.First(c => c.Id == UpdatedOborot.CategoryId);
            categoryComboBox.SelectedItem = selCategory;

            if (UpdatedOborot.SubCategoryId.HasValue)
            {
                var selSubCategory = selCategory.SubCategories.FirstOrDefault(s => s.Key == UpdatedOborot.SubCategoryId);
                subcategoryComboBox.SelectedItem = selSubCategory;
            }

            countTextBox.Text = UpdatedOborot.Count.ToString();
            amountTextBox.Text = UpdatedOborot.Summa.ToString();
            currencyLbl.Text = UpdatedOborot.Currency;
            descTextBox.Text = UpdatedOborot.Note;
        }
    }
}
