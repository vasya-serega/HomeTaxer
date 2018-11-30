using System;
using System.Windows.Forms;
using HomeTaxer.Client.Configuration;

namespace HomeTaxer.Client.Forms
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �������� �������� �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OptionsForm_Load(object sender, EventArgs e)
        {
            SettingPG.SelectedObject = Config.GetClone();
        }

        /// <summary>
        /// ��������� ��������� � ��������� ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkBtn_Click(object sender, EventArgs e)
        {
            Config.NewConfig((Config)SettingPG.SelectedObject);
            Config.Save();
            Close();
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}