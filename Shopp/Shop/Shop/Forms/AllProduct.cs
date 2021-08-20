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
    public partial class AllProduct : Form
    {
        private List<Product> Products = new List<Product>();
        private const string SEARCH_PLACEHOLDER = "Пошук";

        public AllProduct()
        {
            InitializeComponent();
            textBox1.Text = SEARCH_PLACEHOLDER;
            Fill();
        }

        private TextBox ShowPlaceholder(object sender, string text)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == "")
            {
                textBox.Text = text;
            }
            return textBox;
        }


        private TextBox HidePlaceholder(object sender, string text)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text == text)
            {
                textBox.Text = "";
            }
            return textBox;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Fill(textBox1.Text);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            HidePlaceholder(sender, SEARCH_PLACEHOLDER);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ShowPlaceholder(sender, SEARCH_PLACEHOLDER);
        }

        private void Fill()
        {
            dataGridView1.Rows.Clear();
            Products.Clear();

            foreach (Product product in Program.AllProduct)
            {
                dataGridView1.Rows.Add(
                        product.Name,
                        product.CompanyName,
                        product.Cost,
                        product.Count,
                        "Подивитися");
                Products.Add(product);
            }
        }

        private void Fill(string searchText)
        {
            if(!textBox1.Focused 
                &&
                textBox1.Text == SEARCH_PLACEHOLDER)
            {
                Fill();
                return;
            }
            dataGridView1.Rows.Clear();
            Products.Clear();

            foreach(Product product in Program.AllProduct)
            {
                if (product.Name.IndexOf(searchText) != -1)
                {
                    dataGridView1.Rows.Add(
                        product.Name,
                        product.CompanyName,
                        product.Cost,
                        product.Count,
                        "Подивитися");
                    Products.Add(product);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 4)
            {
                Product product = Products[e.RowIndex];
                new ShowProduct(product).ShowDialog();
                Fill(textBox1.Text);
            }
        }

        private void AllProduct_Load(object sender, EventArgs e)
        {

        }
    }
}
