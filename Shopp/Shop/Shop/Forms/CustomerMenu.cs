using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop.Forms;

namespace Shop.Forms
{
    public partial class CustomerMenu : Form
    {
        public CustomerMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AccountForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AllProduct().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Basket().ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CustomerMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.SaveProducts();
            Program.SaveCustomers();
            Program.SaveBuyingProducts();
            Application.Exit();
        }

        
    }
}
