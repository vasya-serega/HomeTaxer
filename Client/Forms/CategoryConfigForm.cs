using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeTaxer.Client.Model;
using HomeTaxer.Client.Services;
using HomeTaxer.Common.Model;

//using HomeTaxer.Common.Model;

//using SubCategory = HomeTaxer.Common.Model.SubCategory;

namespace HomeTaxer.Client.Forms
{
    public partial class CategoryConfigForm : Form
    {
        //private readonly HtService _service;
        private bool _isLoading;
        private List<TempCategory> _tempCategories;
        private readonly BindingSource _bs = new BindingSource();

        public CategoryConfigForm(HtService service)
        {
            //_service = service;
            _tempCategories = service.Categories.Select(c => new TempCategory(c)).ToList();
            _bs.DataSource = _tempCategories.Where(t => !t.IsDeleted);

            InitializeComponent();
        }

        private void CategoryConfigForm_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            categoriesLB.DataSource = _bs;
            categoriesLB.DisplayMember = "Name";
            categoriesLB.ValueMember = "Id";

            _isLoading = false;
            categoriesLB_SelectedIndexChanged(null, null);
        }

        private void categoriesLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading)
            {
                return;
            }

            var isSelected = categoriesLB.SelectedIndex > -1;
            editCategBtn.Enabled = isSelected;
            deleteCategBtn.Enabled = isSelected;

            var selCateg = (TempCategory)categoriesLB.SelectedItem;
            var subCategories = selCateg.SubCategories.Select(d => new SubCategory(d.Key, d.Value)).ToList();

            subCategoriesLB.DataSource = subCategories;
            subCategoriesLB.DisplayMember = "Name";
            subCategoriesLB.ValueMember = "Id";
        }

        private void EditCategory(object sender, EventArgs e)
        {
            var newLineBox = new LineEditBox("Редагування існуючої категорії", ((TempCategory)categoriesLB.SelectedItem).Name);
            if (newLineBox.ShowDialog() == DialogResult.OK)
            {
                var updCategory = (TempCategory) categoriesLB.SelectedItem;
                updCategory.Name = newLineBox.UpdatedText;
                updCategory.IsModified = true;

                _bs.ResetBindings(false);
            }
        }

        private void AddCategory(object sender, EventArgs e)
        {
            var newLineBox = new LineEditBox("Створення нової категорії");
            if (newLineBox.ShowDialog() == DialogResult.OK)
            {
                var id = GetNextNewIndex;
                _tempCategories.Add(new TempCategory(id, newLineBox.UpdatedText));

                _bs.ResetBindings(false);
            }
        }

        private void DeleteCategory(object sender, EventArgs e)
        {
            var delCateg = (TempCategory) categoriesLB.SelectedItem;
            var confirmText = $"Ви дійсно бажаєте видалити категорію '{delCateg.Name}' з усіма підкатегоріями?" +
                              $"{Environment.NewLine}" +
                "Увага: видалення відбудеться тільки при відсутності оборотів із даною категорією або її підкатегоріями";
            var diagRes = MessageBox.Show(confirmText, "Підтвердження дії", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diagRes == DialogResult.Yes)
            {
                delCateg.IsDeleted = true;

                _bs.DataSource = _tempCategories.Where(t => !t.IsDeleted);
                _bs.ResetBindings(false);
            }
        }

        private int GetNextNewIndex
        {
            get
            {
                var min = _tempCategories.Select(t => t.Id).Min();
                return min < 0 ? min - 1 : -1;
            }
        }
    }
}
