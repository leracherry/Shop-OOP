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

namespace Shop
{
    public partial class Basket : Form
    {
        public Basket()
        {
            InitializeComponent();
            Fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(BasketProduct product in Program.CurrentCustomer.Basket)
            {
                Program.BuyingProducts.Add(new BuyingProduct(product));
            }
            Program.CurrentCustomer.Basket.Clear();
            Fill();
            Close();
        }

        private void Fill()
        {
            dataGridView1.Rows.Clear();
            foreach(BasketProduct product in Program.CurrentCustomer.Basket)
            {
                dataGridView1.Rows.Add(
                    product.Name,
                    product.CompanyName,
                    product.Cost,
                    product.Count,
                    product.Cost * product.Count,
                    "Видалити");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                BasketProduct product = Program.CurrentCustomer.Basket[e.RowIndex];
                foreach(Product product1 in Program.AllProduct)
                {
                    if(product.Name == product1.Name
                        &&
                        product.CompanyName == product1.CompanyName)
                    {
                        product1.Count += product.Count;
                    }
                }
                Program.CurrentCustomer.Basket.RemoveAt(e.RowIndex);
                Fill();
            }
        }
    }
}
