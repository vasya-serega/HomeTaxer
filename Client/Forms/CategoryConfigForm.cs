using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HomeTaxer.Client.Model;
using HomeTaxer.Client.Model.Enums;
using HomeTaxer.Client.Services;
using HomeTaxer.Common.Model;

//using HomeTaxer.Common.Model;

//using SubCategory = HomeTaxer.Common.Model.SubCategory;

namespace HomeTaxer.Client.Forms
{
    public partial class CategoryConfigForm : Form
    {
        //private readonly HtService _service;
        private bool _isLoading, _isRefreshing;
        private List<TempCategory> _tempCategories;
        private readonly BindingSource _categoryBs = new BindingSource();
        private readonly BindingSource _subCategoryBs = new BindingSource();

        public CategoryConfigForm(HtService service)
        {
            //_service = service;
            _tempCategories = service.Categories.Select(c => new TempCategory(c)).ToList();
            _categoryBs.DataSource = _tempCategories.Where(t => !t.IsDeleted).ToList();
            _categoryBs.ListChanged += CategoryBsOnListChanged;

            InitializeComponent();
        }

        private void CategoryBsOnListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                _tempCategories.Add((TempCategory) categoriesLB.Items[e.NewIndex]);
                _categoryBs.ResetBindings(false);
            }

            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                var srcItem = ((List<TempCategory>)_categoryBs.DataSource).ElementAt(e.NewIndex);
                _tempCategories.ElementAt(e.NewIndex).IsModified = true;
                _tempCategories.ElementAt(e.NewIndex).Name = srcItem.Name;

                _isRefreshing = false;
                categoriesLB.SelectedIndex = e.NewIndex;
                _categoryBs.ResetBindings(false);
            }
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                _tempCategories.ElementAt(e.NewIndex).IsDeleted = true;
                if (categoriesLB.Items.Count > e.NewIndex)
                {
                    categoriesLB_SelectedIndexChanged(null, null);
                }
                _categoryBs.ResetBindings(false);
            }
        }

        private void SubCategoryBsOnListChanged(object sender, ListChangedEventArgs e)
        {
            var categoryId = ((TempCategory)categoriesLB.SelectedItem).Id;
            var subCategories = _tempCategories.First(c => c.Id == categoryId).SubCategories;

            if (e.ListChangedType == ListChangedType.ItemAdded)
            {
                //subCategories.Add((TempSubCategory)subCategoriesLB.Items[e.NewIndex]);
                _subCategoryBs.ResetBindings(false);
            }
            if (e.ListChangedType == ListChangedType.ItemChanged)
            {
                var srcItem = subCategories.ElementAt(e.NewIndex);
                srcItem.IsModified = true;

                _isRefreshing = false;
                subCategoriesLB.SelectedIndex = e.NewIndex;
                _subCategoryBs.ResetBindings(false);
            }
            if (e.ListChangedType == ListChangedType.ItemDeleted)
            {
                var srcItem = subCategories.ElementAt(e.NewIndex);
                srcItem.IsDeleted = true;

                if (subCategoriesLB.Items.Count > e.NewIndex)
                {
                    subCategoriesLB_SelectedIndexChanged(null, null);
                }
                _subCategoryBs.ResetBindings(false);
            }
        }

        private void CategoryConfigForm_Load(object sender, EventArgs e)
        {
            _isLoading = true;

            categoriesLB.DataSource = _categoryBs;
            categoriesLB.DisplayMember = "Name";
            categoriesLB.ValueMember = "Id";

            _isLoading = false;
            categoriesLB_SelectedIndexChanged(null, null);
        }

        private void categoriesLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading || _isRefreshing)
            {
                return;
            }

            var isSelected = categoriesLB.SelectedIndex > -1;
            editCategBtn.Enabled = isSelected;
            deleteCategBtn.Enabled = isSelected && categoriesLB.Items.Count > 1;

            if (!isSelected)
            {
                MessageBox.Show("Category is not selected", "Crippled development", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            var categoryId = ((TempCategory)categoriesLB.SelectedItem).Id;
            var subCategories = _tempCategories.First(c => c.Id == categoryId).SubCategories;
            _subCategoryBs.DataSource = subCategories.Where(s => !s.IsDeleted);
            _subCategoryBs.ListChanged += SubCategoryBsOnListChanged;

            subCategoriesLB.DataSource = _subCategoryBs;
            subCategoriesLB.DisplayMember = "Name";
            subCategoriesLB.ValueMember = "Id";
        }

        private void subCategoriesLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isLoading || _isRefreshing)
            {
                return;
            }

            var isSelected = subCategoriesLB.SelectedIndex > -1;
            editSubCategBtn.Enabled = isSelected;
            delSubCategBtn.Enabled = isSelected && subCategoriesLB.Items.Count > 1;
        }

        private void AddCategory(object sender, EventArgs e)
        {
            var newLineBox = new LineEditBox("Створення нової категорії", LineEditBoxEntity.Category);
            if (newLineBox.ShowDialog() == DialogResult.OK)
            {
                var id = GetNextNewIndex;
                _categoryBs.Add(new TempCategory(id, newLineBox.UpdatedText));
            }
        }

        private void EditCategory(object sender, EventArgs e)
        {
            var newLineBox = new LineEditBox("Редагування існуючої категорії", 
                LineEditBoxEntity.Category, ((TempCategory)categoriesLB.SelectedItem).Name);
            if (newLineBox.ShowDialog() == DialogResult.OK)
            {
                var updCategory = (TempCategory)categoriesLB.SelectedItem;
                var srcItem = ((List<TempCategory>) _categoryBs.DataSource).First(c => c.Id == updCategory.Id);
                srcItem.Name = newLineBox.UpdatedText;

                _isRefreshing = true;
                _categoryBs.ResetCurrentItem();
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
                _categoryBs.RemoveCurrent();
            }
        }

        private void AddSubCategory(object sender, EventArgs e)
        {
            var newLineBox = new LineEditBox("Створення нової підкатегорії", LineEditBoxEntity.SubCategory);
            if (newLineBox.ShowDialog() == DialogResult.OK)
            {
                var categoryId = ((TempCategory)categoriesLB.SelectedItem).Id;
                var id = GetNextNewSubCategoryIndex(categoryId);
                _subCategoryBs.Add(new TempSubCategory(id, newLineBox.UpdatedText));
            }
        }

        private void EditSubCategory(object sender, EventArgs e)
        {
            var newLineBox = new LineEditBox("Редагування існуючої підкатегорії",
                LineEditBoxEntity.SubCategory, ((TempSubCategory)subCategoriesLB.SelectedItem).Name);
            if (newLineBox.ShowDialog() == DialogResult.OK)
            {
                var subCategory = (TempSubCategory)subCategoriesLB.SelectedItem;
                var srcItem = ((List<TempSubCategory>)_subCategoryBs.DataSource).First(c => c.Id == subCategory.Id);
                srcItem.Name = newLineBox.UpdatedText;

                _isRefreshing = true;
                _subCategoryBs.ResetCurrentItem();
            }
        }

        private void DelSubCategory(object sender, EventArgs e)
        {
            var delSubCateg = (TempSubCategory)subCategoriesLB.SelectedItem;
            var confirmText = $"Ви дійсно бажаєте видалити підкатегорію '{delSubCateg.Name}' з усіма підкатегоріями?" +
                              $"{Environment.NewLine}" +
                              "Увага: видалення відбудеться тільки при відсутності оборотів із даною підкатегорією";
            var diagRes = MessageBox.Show(confirmText, "Підтвердження дії", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (diagRes == DialogResult.Yes)
            {
                //_subCategoryBs.RemoveCurrent();
                // incorrect!!!
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

        

        private int GetNextNewSubCategoryIndex(int categoryId)
        {
            var subCategories = _tempCategories.First(t => t.Id == categoryId).SubCategories;
            var min = subCategories.Count > 0 ? subCategories.Min(sc => sc.Id) : -1;
            return min < 0 ? min - 1 : -1;
        }
    }
}
