using Business.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Abstract;
using Business.Concrete.DependancyResolver.Ninject;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace WebFormUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            _productService = InstanceFactory.GetInstance<IProductService>();
            _categoryService = InstanceFactory.GetInstance<ICategoryService>();

            InitializeComponent();
        }

        private IProductService _productService;
        private ICategoryService _categoryService;

        private void Form1_Load(object sender, EventArgs e)
        {
            
            LoadProducts();
            LoadCategories();
           
        }
        
        private void LoadProducts()
        {
            dgwProducts.DataSource = _productService.GetAll();
        }

        private void LoadCategories()
        {
            cbxSearchCategory.DataSource = _categoryService.GetAll();
            cbxSearchCategory.DisplayMember = "CategoryName";
            cbxSearchCategory.ValueMember = "CategoryId";
            
            cbxAddCategory.DataSource = _categoryService.GetAll();
            cbxAddCategory.DisplayMember = "CategoryName";
            cbxAddCategory.ValueMember = "CategoryId"; 
            
            cbxUpdateCategory.DataSource = _categoryService.GetAll();
            cbxUpdateCategory.DisplayMember = "CategoryName";
            cbxUpdateCategory.ValueMember = "CategoryId";
        }


        private void cbxSearchCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dgwProducts.DataSource = _productService.GetProductsByCategoryId(Convert.ToInt32(cbxSearchCategory.SelectedValue));

            }
            catch 
            {
               
            }
        }

        private void tbxSearchPName_TextChanged(object sender, EventArgs e)
        {
            dgwProducts.DataSource = _productService.GetProductsByProductName(tbxSearchPName.Text);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _productService.Add(new Product
                {
                    CategoryId = Convert.ToInt32(cbxAddCategory.SelectedValue),
                    ProductName = tbxAddPName.Text,
                    QuantityPerUnit = tbxAddQUnit.Text.ToString(),
                    UnitPrice = Convert.ToDecimal(tbxAddUnitPrice.Text),
                    UnitsInStock = Convert.ToInt16(tbxAddUStock.Text)
                });
                LoadProducts();
                MessageBox.Show("ürün eklendi!");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productService.Update(new Product
            {
                ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                CategoryId = Convert.ToInt32(cbxUpdateCategory.SelectedValue),
                ProductName = tbxUpdatePName.Text.ToString(),
                QuantityPerUnit = tbxUpdateQUnit.Text,
                UnitPrice = Convert.ToDecimal(tbxUpdateUPrice.Text),
                UnitsInStock = Convert.ToInt16(tbxUpdateUStock.Text),

            });
            LoadProducts();
            MessageBox.Show("ürün güncellendi!");
        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbxUpdateCategory.SelectedValue = Convert.ToInt32(dgwProducts.CurrentRow.Cells[1].Value);
            tbxUpdatePName.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxUpdateQUnit.Text = dgwProducts.CurrentRow.Cells[5].Value.ToString();
            tbxUpdateUPrice.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
            tbxUpdateUStock.Text = dgwProducts.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            _productService.Delete(new Product
            {
                ProductId = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value)
            });
            LoadProducts();
            MessageBox.Show("ürün silindi!");
        }
    }
}
