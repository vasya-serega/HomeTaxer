using System;
using System.Windows.Forms;
using HomeTaxer.Client.Configuration;
using HomeTaxer.Client.Services;

namespace HomeTaxer.Client.Forms
{
    public partial class LogOnForm : Form
    {
        public LogOnForm()
        {
            InitializeComponent();
            ReadConfiguration();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void nameTB_TextChanged(object sender, EventArgs e)
        {
            var text = nameTB.Text;
            okBtn.Enabled = text.Length > 2;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var service = new HtService(nameTB.Text, passTB.Text);
                if (service.EnableToConnect)
                {
                    Hide();
                    Cursor = Cursors.Default;
                    var mainForm = new MainForm(service);
                    mainForm.Show();

                    SaveConfiguration();
                }
                else
                {
                    MessageBox.Show("Ви не має прав для входу в програму. Можливо, невірний пароль чи логін.",
                        "Помилка входу", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                var mes = $"Unable to perform login. {ex.Message}";
                MessageBox.Show(mes, "LogIn error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LogOnForm_Load(object sender, EventArgs e)
        {

        }

        private void nameTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Return)
            {
                okBtn_Click(sender, EventArgs.Empty);
            }
        }

        private void ReadConfiguration()
        {
            Config.NewConfig(Config.GetClone());
            allowStoreDataCB.Checked = Config.Instance.AllowSaveCredentials;
            if (allowStoreDataCB.Checked)
            {
                nameTB.Text = Config.Instance.UserName;
            }
        }

        private void SaveConfiguration()
        {
            Config.Instance.AllowSaveCredentials = allowStoreDataCB.Checked;
            if (allowStoreDataCB.Checked)
            {
                if (Config.Instance.UserName.Equals(nameTB.Text.Trim()))
                {
                    return;
                }

                Config.Instance.UserName = nameTB.Text.Trim();
            }
            Config.Save();
        }
    }
}
