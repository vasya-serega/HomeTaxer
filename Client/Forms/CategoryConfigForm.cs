using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeTaxer.Client.Model;
using HomeTaxer.Client.Services;

namespace HomeTaxer.Client.Forms
{
    public partial class CategoryConfigForm : Form
    {
        private readonly HtService _service;

        public CategoryConfigForm(HtService service)
        {
            _service = service;

            InitializeComponent();
        }

        public bool WasAccountsUpdated { get; private set; } = false;

        private void AddAccount(object sender, EventArgs e)
        {
            var newLineBox = new LineEditBox("Створення нового рахунку");
            if (newLineBox.ShowDialog() == DialogResult.OK)
            {
                InsertAccountToDbAsync(newLineBox.UpdatedText);
            }
        }

        private void EditAccount(object sender, EventArgs e)
        {
            var selItem = accountListView.SelectedItems[0];
            var accountId = Convert.ToInt32(selItem.SubItems[1].Text);

            var newLineBox = new LineEditBox("Редагування існуючого рахунку", selItem.Text);
            if (newLineBox.ShowDialog() == DialogResult.OK)
            {
                UpdateAccountInDbAsync(accountId, newLineBox.UpdatedText);
            }
        }

        private void DeleteAccount(object sender, EventArgs e)
        {
            var selItem = accountListView.SelectedItems[0];
            var accountId = Convert.ToInt32(selItem.SubItems[1].Text);

            var confirmRes = MessageBox.Show($"Дійсно видалити рахунок '{selItem.Text}'? Рахунок буде видалиний лише при відсутності оборотів по ньому.", 
                "Підтвердження дії", 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (confirmRes == DialogResult.Yes)
            {
                DeleteAccountInDbAsync(accountId);
            }
            
        }

        private void AccountConfigForm_Load(object sender, EventArgs e)
        {
           
        }

        private void accountListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            var isEnabled = accountListView.SelectedItems.Count == 1;
            SetEditDelEnabled(isEnabled);
        }

        private void SetEditDelEnabled(bool isEnabled)
        {
            editBtn.Enabled = isEnabled;
            deleteBtn.Enabled = isEnabled;
        }

        private void SetEnableWhileAsync(bool isEnabled)
        {
            addBtn.Enabled = isEnabled;
            SetEditDelEnabled(isEnabled);

            infoLbl.Visible = !isEnabled;
        }

        private async void InsertAccountToDbAsync(string accountName)
        {
            SetEnableWhileAsync(false);

            var result = await _service.InsertAccount(accountName);
            if (result.IsSuccess)
            {
                AddInsertedAccount(result.InsertedId, accountName);
            }
            HandleErrorResult(result);
            SetEnableWhileAsync(true);
        }

        private async void UpdateAccountInDbAsync(int accountId, string accountName)
        {
            SetEnableWhileAsync(false);

            var result = await _service.UpdateAccount(accountId, accountName);
            if (result.IsSuccess)
            {
                RefreshUpdatedAccount(accountId, accountName);
            }

            SetEnableWhileAsync(true);
            HandleErrorResult(result);
        }

        private async void DeleteAccountInDbAsync(int accountId)
        {
            SetEnableWhileAsync(false);

            var result = await _service.DeleteAccount(accountId);
            if (result.IsSuccess)
            {
                RemoveDeletedAccount(accountId);
            }

            SetEnableWhileAsync(true);
            HandleErrorResult(result);
        }


        private void AddInsertedAccount(int accountId, string accountName)
        {
            var newItem = new ListViewItem(accountName);
            newItem.SubItems.Add(accountId.ToString());
            accountListView.Items.Add(newItem);

            _service.Accounts.Add(accountId, accountName);

            WasAccountsUpdated = true;
        }

        private void RefreshUpdatedAccount(int accountId, string accountName)
        {
            var selItem = accountListView.SelectedItems[0];
            selItem.Text = accountName;

            _service.Accounts[accountId] = accountName;

            WasAccountsUpdated = true;
        }

        private void RemoveDeletedAccount(int accountId)
        {
            var selItem = accountListView.SelectedItems[0];
            accountListView.Items.Remove(selItem);

            _service.Accounts.Remove(accountId);

            WasAccountsUpdated = true;
        }

        private void HandleErrorResult(OperationResult result)
        {
            if (result.IsSuccess)
            {
                return;
            }

            infoLbl.Text = result.Message;
            infoLbl.Visible = true;

            var mes = $"{result.Exception.Message}";
            errorProvider.SetError(infoLbl, mes);
        }

        private void accountListView_Click(object sender, EventArgs e)
        {

        }
    }
}
