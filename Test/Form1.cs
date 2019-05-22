using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.Properties;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //categoryLW.SmallImageList.Images.Add(new Icon())
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ImageList imageList = new ImageList();
            imageList.Images.Add(Resources.AddRow);
            imageList.Images.Add(Resources.EditRow);
            imageList.Images.Add(Resources.DelRow);
            categoryLW.SmallImageList = imageList;

            var disabledRow = new ListViewItem()
            {
                ForeColor = Color.DarkGray,
                Text = "Disabled item",
                ImageIndex = 2
            };
            var enabledRow = new ListViewItem()
            {
                Text = "Unmodified row"
            };
            var addedRow = new ListViewItem()
            {
                Text = "Added row",
                ImageIndex = 0
            };
            var editiedRow = new ListViewItem()
            {
                Text = "Modified row",
                ImageIndex = 1
            };
            categoryLW.Items.Add(disabledRow);
            categoryLW.Items.Add(enabledRow);
            categoryLW.Items.Add(addedRow);
            categoryLW.Items.Add(editiedRow);
        }
    }
}
