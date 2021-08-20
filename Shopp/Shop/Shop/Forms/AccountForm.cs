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
    public partial class AccountForm : Form
    {
        const string TEXT_EDIT = "Змінити";
        const string TEXT_SAVE = "Зберегти";
        public AccountForm()
        {
            InitializeComponent();
            textBox1.Text = Program.CurrentCustomer.FullName;
            textBox2.Text = Program.CurrentCustomer.Login;
            textBox3.Text = Program.CurrentCustomer.Password;
            button1.Text = TEXT_EDIT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == TEXT_EDIT)
            {
                textBox1.ReadOnly = false;
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                button1.Text = TEXT_SAVE;
            }
            else
            {
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                Program.CurrentCustomer.FullName = textBox1.Text;
                if (Program.IsUniqueLogin(textBox2.Text))
                {
                    Program.CurrentCustomer.Login = textBox2.Text;
                }
                else
                {
                    MessageBox.Show(
                        "Неможливо змінити логін бо він не є унікальним",
                        "Данний логін вже існує", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    textBox2.Text = Program.CurrentCustomer.Login;
                }
                Program.CurrentCustomer.Password = textBox3.Text;
                button1.Text = TEXT_EDIT;
            }
        }
    }
}
