using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop.Models;

namespace Shop.Forms
{
    public partial class ShowProduct : Form
    {
        public Product Product { get; private set; }

        public ShowProduct(Product product)
        {
            InitializeComponent();
            Product = product;
            pictureBox1.ImageLocation = product.ImagePath;
            textBox1.Text = product.Name;
            textBox2.Text = product.CompanyName;
            textBox3.Text = product.Cost + "₴";
            textBox4.Text = product.Description;
            if(product.Count == 0)
            {
                button1.Enabled = false;
                
            }
            numericUpDown1.Maximum = Product.Count;
        }

        private void ShowProduct_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasketProduct basketProduct = null;
            foreach(BasketProduct product in Program.CurrentCustomer.Basket)
            {
                if (
                    product.Name == Product.Name 
                    && 
                    product.CompanyName == Product.CompanyName
                    &&
                    product.Cost == Product.Cost
                    &&
                    product.Description == Product.Description)
                {
                    basketProduct = product;
                    break;
                }
            }
            if(basketProduct == null)
            {
                basketProduct = new BasketProduct(Product, (uint)numericUpDown1.Value);
            }
            else
            {
                basketProduct.Count += (uint)numericUpDown1.Value;
            }
            Product.Count -= (uint)numericUpDown1.Value; 
            Close();
        }
    }
}
