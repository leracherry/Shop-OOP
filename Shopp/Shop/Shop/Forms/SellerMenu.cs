using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shop.Forms
{
    public partial class SellerMenu : Form
    {
        public SellerMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new OrderingProducts().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AllProductsForm().ShowDialog();
        }

        private void SellerMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SaveProducts();
            Program.SaveCustomers();
            Program.SaveBuyingProducts();
            Application.Exit();
        }
    }
}
