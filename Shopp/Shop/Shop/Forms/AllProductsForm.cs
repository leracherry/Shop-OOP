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
    public partial class AllProductsForm : Form
    {
        private Product Product;
        private bool Edit;

        public AllProductsForm()
        {
            InitializeComponent();
            Fill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product.Name = textBox1.Text;
            Product.CompanyName = textBox2.Text;
            Product.Cost = (double)numericUpDown1.Value;
            Product.Description = textBox4.Text;
            Product.ImagePath = pictureBox1.ImageLocation;
            if (!Edit)
            {
                Program.AllProduct.Add(Product);
            }
            Height = 494;
            Fill();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                if (e.RowIndex == Program.AllProduct.Count)
                {
                    pictureBox1.ImageLocation = null;
                    Product = new Product();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    numericUpDown1.Value = 0.01M;
                    textBox4.Text = "";
                    button1.Text = "Додати";
                    Edit = false;
                }
                else
                {
                    Product = Program.AllProduct[e.RowIndex];
                    pictureBox1.ImageLocation = Product.ImagePath;
                    textBox1.Text = Product.Name;
                    textBox2.Text = Product.CompanyName;
                    numericUpDown1.Value = (decimal)Product.Cost;
                    textBox4.Text = Product.Description;
                    button1.Text = "Змінити";
                    Edit = true;
                }
                Height = 1032;
            }
            else if (e.ColumnIndex == 5)
            {
                if (e.RowIndex != Program.AllProduct.Count)
                {
                    new IncrementCount(Program.AllProduct[e.RowIndex]).ShowDialog();
                    Fill();
                }
            }
            else if (e.ColumnIndex == 6)
            {
                if (e.RowIndex != Program.AllProduct.Count)
                {
                    Program.AllProduct.RemoveAt(e.RowIndex);
                    Fill();
                }
            }
        }

        private void Fill()
        {
            dataGridView1.Rows.Clear();

            foreach (Product product in Program.AllProduct)
            {
                dataGridView1.Rows.Add(
                        product.Name,
                        product.CompanyName,
                        product.Cost,
                        product.Count,
                        "Змінити",
                        "Збільшити",
                        "Видалити");
            }
        }

        private void AllProductsForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Height = 494;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            openFileDialog1.FileName = "";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }
    }
}
