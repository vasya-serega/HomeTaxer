using System.Windows.Forms;

namespace HomeTaxer.Client.Forms
{
    public partial class LineEditBox : Form
    {
        public LineEditBox(string title, string existingValue = null)
        {
            InitializeComponent();
            Text = title;
            textBox.Text = existingValue;
        }

        public string UpdatedText => textBox.Text;

        private void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                okBtn_Click(this, null);
            }
        }

        private void okBtn_Click(object sender, System.EventArgs e)
        {
            var confirmRes = MessageBox.Show($"Зберегти зміни? Им'я рахунку '{UpdatedText}'",
                "Підтвердження операції.",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (confirmRes == DialogResult.Yes)
            {
                DialogResult = DialogResult.OK;
                //Close();
                return;
            }

            DialogResult = DialogResult.Cancel;
        }
    }
}
