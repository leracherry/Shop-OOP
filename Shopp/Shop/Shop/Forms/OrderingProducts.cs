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
    public partial class OrderingProducts : Form
    {
        private bool ChooseAll = true;

        public OrderingProducts()
        {
            InitializeComponent();
            Fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < Program.BuyingProducts.Count; i++)
            {
                bool cb = (bool)dataGridView1.Rows[i].Cells[6].Value;
                if (cb)
                {
                    Program.BuyingProducts.RemoveAt(i);
                    i--;
                }
            }
            Fill();
        }

        private void Fill()
        {
            dataGridView1.Rows.Clear();
            foreach (BuyingProduct product in Program.BuyingProducts)
            {
                dataGridView1.Rows.Add(
                    product.Name,
                    product.CompanyName,
                    product.Cost,
                    product.Count,
                    product.Customer.FullName,
                    product.BuyingDate,
                    null);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[6].Value = ChooseAll;
            }
            ChooseAll = !ChooseAll;
        }
    }
}
