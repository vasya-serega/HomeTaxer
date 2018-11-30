using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Windows.Forms;
using HomeTaxer.Client.Configuration;
using HomeTaxer.Client.HomeTaxesReference;
using HomeTaxer.Client.Services;

namespace HomeTaxer.Client.Forms
{
    [SuppressMessage("ReSharper", "IdentifierTypo")]
    public partial class MainForm : Form
    {
        private readonly HtService _service;
        private delegate void ShowCustProgrDelegate(bool show);
        private bool _isOborotLoading;
        private bool _isDictsLoading;

        public MainForm(HtService service)
        {
            InitializeComponent();
            _service = service;
        }

        #region Event Handlers

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowCustProgr(true);

            ShowAllOborotAsync();
            LoadDictOptionsAsync();

            ShowCustProgr(false);
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            var diagRes = MessageBox.Show(" Залишити программу? ", "Підтвердження виходу", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (diagRes == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void optionsMenuItem_Click(object sender, EventArgs e)
        {
            var form = new OptionsForm();
            form.ShowDialog();
        }

        private void AddOborot(object sender, EventArgs e)
        {
            var form = new OborotForm(_service);
            var result = form.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Retry)
            {   
                InsertOborotsToDbAsync(form.InsertedOborots);
            }
        }

        private void EditOborot(object sender, EventArgs e)
        {
            var editRow = mainDataGW.SelectedRows[0];
            var updOborot = new Oborot()
            {
                AccountNameId = _service.AccountNameId,
                OborotId = (int)editRow.Cells[0].Value,
                Date = (DateTime)editRow.Cells[1].Value,
                CategoryId = (int)editRow.Cells[2].Value,
                Category = (string)editRow.Cells[3].Value,
                SubCategoryId = (int?) editRow.Cells[4].Value,
                SubCategory = (string)editRow.Cells[5].Value,
                Count = (double)editRow.Cells[6].Value,
                Summa = (decimal)editRow.Cells[7].Value,
                CurrencyId = (int)editRow.Cells[8].Value,
                Currency = (string)editRow.Cells[9].Value,
                Note = (string)editRow.Cells[10].Value
            };

            var form = new OborotForm(_service, updOborot);
            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                UpdateOborotInTable(form.UpdatedOborot);
                UpdateOborotToDbAsync(form.UpdatedOborot);
            }
        }

        private void DeleteOborot(object sender, EventArgs e)
        {
            var deleteRow = mainDataGW.SelectedRows[0];
            var oborotId = (int)deleteRow.Cells[0].Value;

            var confirmRes = MessageBox.Show("Справді видалити запис ?", "", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);
            if (confirmRes == DialogResult.OK)
            {
                DeleteOborotInTable();
                DeleteOborotInDbAsync(oborotId);
            }
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            customProgrBar.StepIt();
        }

        private void mainDataGW_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            EnableModifyButton();
            EnableDeleteButton();
        }

        private void addItemBtn_EnabledChanged(object sender, EventArgs e)
        {
            if (addBtn.Enabled)
            {
                addBtn.BackColor = Color.LightGreen;
            }
            else
            {
                addBtn.BackColor = Color.Transparent;
            }
        }

        private void editBtn_EnabledChanged(object sender, EventArgs e)
        {
            if (editBtn.Enabled)
            {
                editBtn.BackColor = Color.Khaki;
            }
            else
            {
                editBtn.BackColor = Color.Transparent;
            }
        }

        private void deleteBtn_EnabledChanged(object sender, EventArgs e)
        {
            if (deleteBtn.Enabled)
            {
                deleteBtn.BackColor = Color.LightPink;
            }
            else
            {
                deleteBtn.BackColor = Color.Transparent;
            }
        }

        private void mainDataGW_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if ((Control.ModifierKeys & Keys.Control) == 0)
            {
                mainDataGW.ClearSelection();
            }
        }

        private void ShowAboutBox(object sender, EventArgs e)
        {
            var about = new AboutBox();
            about.ShowDialog();
        }

        private void ChangeAccountName(object sender, EventArgs e)
        {
            if (_isDictsLoading || _isOborotLoading)
            {
                return;
            }

            ShowCustProgr(true);
            DisableControls();

            var selAccount = (KeyValuePair<int, string>) curAccountNameCB.SelectedItem;
            _service.AccountNameId = selAccount.Key;
            Config.Instance.AccountId = selAccount.Key;
            Config.Save();

            ShowAllOborotAsync(true);

            EnableControls();
            ShowCustProgr(false);
        }

        private void EditAccounts(object sender, EventArgs e)
        {
            var accountEditForm = new AccountConfigForm(_service, _service.Accounts);
            accountEditForm.ShowDialog();

            if (accountEditForm.WasAccountsUpdated)
            {
                var selAccount = (KeyValuePair<int, string>)curAccountNameCB.SelectedItem;
                var skipSetDefault = _service.Accounts.ContainsKey(selAccount.Key);

                _isDictsLoading = skipSetDefault;
                FillAccountNameSelector();

                if (skipSetDefault)
                {
                    SetAccountSelectedById(selAccount.Key);
                }

                _isDictsLoading = false;
            }
        }
        #endregion Event Handlers

        #region Private methods
        private async void LoadDictOptionsAsync()
        {
            _isDictsLoading = true;
            await _service.LoadOptions();

            FillAccountNameSelector();
            addBtn.Enabled = true;
            curAccountNameCB.Enabled = true;
            _isDictsLoading = false;
        }

        private async void ShowAllOborotAsync(bool clearTable = false)
        {
            _isOborotLoading = true;
            Config.NewConfig(Config.GetClone());
            _service.AccountNameId = Config.Instance.AccountId;

            var oborots = await _service.GetAllOborots(OborotDirection.Costs);
            if (clearTable)
            {
                mainDataGW.Rows.Clear();
            }

            foreach (var oborot in oborots)
            {
                AddOborotToTable(oborot);
            }
            _isOborotLoading = false;
        }

        private async void InsertOborotsToDbAsync(IEnumerable<Oborot> newOborots)
        {
            ShowCustProgr(true);

            var oborotsToAddIntoTable = new List<Oborot>();
            foreach (var newOborot in newOborots)
            {
                var result = await _service.InsertOborot(newOborot);
                if (result.IsSuccess)
                {
                    newOborot.OborotId = result.InsertedId;
                    newOborot.AccountNameId = _service.AccountNameId;
                    oborotsToAddIntoTable.Add(newOborot);
                }
                else
                {
                    ShowProgressError(result.Message, result.Exception);
                }
            }

            foreach (var savedOborot in oborotsToAddIntoTable)
            {
                AddOborotToTable(savedOborot);
            }
            ShowCustProgr(false);
        }

        private async void UpdateOborotToDbAsync(Oborot updOborot)
        {
            ShowCustProgr(true);

            var result = await _service.UpdateOborot(updOborot);
            if (!result.IsSuccess)
            {
                ShowProgressError(result.Message, result.Exception);
            }

            ShowCustProgr(false);
        }

        private async void DeleteOborotInDbAsync(int oborotId)
        {
            ShowCustProgr(true);

            var result = await _service.DeleteOborot(oborotId);
            if (!result.IsSuccess)
            {
                ShowProgressError(result.Message, result.Exception);
            }

            ShowCustProgr(false);
        }

        private void EnableControls()
        {
            EnableModifyButton();
            EnableDeleteButton();

            var controls = new Control[]
            {
                addBtn, curAccountNameCB
            };
            foreach (var control in controls)
            {
                control.Enabled = true;
            }
        }

        private void DisableControls()
        {
            var controls = new Control[]
            {
                addBtn, editBtn, deleteBtn,
                curAccountNameCB
            };
            foreach (var control in controls)
            {
                control.Enabled = false;
            }
        }

        private void ShowCustProgr(bool show)
        {
            if (!customProgrBar.InvokeRequired)
            {
                if (show)
                {
                    customProgrBar.Visible = true;
                    progressTimer.Start();
                }
                else
                {
                    customProgrBar.Visible = false;
                    progressTimer.Stop();
                }
            }
            else
            {
                MessageBox.Show("Another thread to show Progress Bar was created. ");
                var showProgDel = new ShowCustProgrDelegate(ShowCustProgr);
                BeginInvoke(showProgDel, new object[] { show });
            }
        }

        private void EnableModifyButton()
        {
            editBtn.Enabled = mainDataGW.SelectedRows.Count == 1;
        }

        private void EnableDeleteButton()
        {
            deleteBtn.Enabled = mainDataGW.SelectedRows.Count == 1;
        }

        private void AddOborotToTable(Oborot record)
        {
            var category = record.Category ?? _service.GetCategoryNameById(record.CategoryId);
            var subcategory = record.SubCategory ?? _service.GetSubcategoryNameById(record.CategoryId, record.SubCategoryId);
            var currency = record.Currency ?? _service.Currencies[record.CurrencyId];

            mainDataGW.Rows.Add(record.OborotId,
                   record.Date,
                   record.CategoryId,
                   category,
                   record.SubCategoryId,
                   subcategory,
                   record.Count,
                   record.Summa,
                   record.CurrencyId,
                   currency,
                   record.Note);
        }

        private void UpdateOborotInTable(Oborot record)
        {
            var category = record.Category ?? _service.GetCategoryNameById(record.CategoryId);
            var subcategory = record.SubCategory ?? _service.GetSubcategoryNameById(record.CategoryId, record.SubCategoryId);
            var currency = record.Currency ?? _service.Currencies[record.CurrencyId];

            var row = mainDataGW.SelectedRows[0];
            row.Cells["Id"].Value = record.OborotId;

            row.Cells["dateCol"].Value = record.Date;
            row.Cells["CategoryId"].Value = record.CategoryId;
            row.Cells["categoryCol"].Value = category;
            row.Cells["SubcategoryId"].Value = record.SubCategoryId;
            row.Cells["subCategoryCol"].Value = subcategory;
            row.Cells["CountCol"].Value = record.Count;
            row.Cells["amountCol"].Value = record.Summa;
            row.Cells["CurrencyId"].Value = record.CurrencyId;
            row.Cells["CurrencyCol"].Value = currency;
            row.Cells["descCol"].Value = record.Note;
        }

        private void DeleteOborotInTable()
        {
            var row = mainDataGW.SelectedRows[0];
            mainDataGW.Rows.Remove(row);
        }

        private void FillAccountNameSelector()
        {
            curAccountNameCB.DataSource = new BindingSource(_service.Accounts, null);
            curAccountNameCB.DisplayMember = "Value";
            curAccountNameCB.ValueMember = "Key";

            SetAccountSelectedById(Config.Instance.AccountId);
        }

        private void ShowProgressError(string message, Exception ex)
        {
            errorLabel.Visible = true;
            var mes = $"{message} {ex.Message}";
            progErrorProvider.SetError(errorLabel, mes);
        }

        private void SetAccountSelectedById(int accountId)
        {
            foreach (var item in curAccountNameCB.Items)
            {
                if (((KeyValuePair<int, string>) item).Key == accountId)
                {
                    curAccountNameCB.SelectedItem = item;
                    break;
                }
            }
            
        }
        #endregion Private methods
    }
}
