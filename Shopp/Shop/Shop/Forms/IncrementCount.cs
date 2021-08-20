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
    public partial class IncrementCount : Form
    {
        private Product Product;
        
        public IncrementCount(Product product)
        {
            InitializeComponent();
            Product = product;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Product.Count += (uint)numericUpDown1.Value;
            Close();
        }
    }
}
