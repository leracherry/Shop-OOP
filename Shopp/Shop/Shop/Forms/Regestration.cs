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
    public partial class Regestration : Form
    {
        private const string FULLNAME_PLACEHOLDER = "Введіть ПІБ";
        private const string LOGIN_PLACEHOLDER = "Введіть логін";
        private const string PASSWORD_PLACEHOLDER = "Введіть пароль";
        private const string PASSWORD_REPEAT_PLACEHOLDER = "Введіть пароль ще раз";


        public Regestration()
        {
            InitializeComponent();
            textBox1.Text = FULLNAME_PLACEHOLDER;
            textBox2.Text = LOGIN_PLACEHOLDER;
            textBox3.Text = PASSWORD_PLACEHOLDER;
            textBox4.Text = PASSWORD_REPEAT_PLACEHOLDER;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                (textBox1.Text == "" || textBox1.Text == FULLNAME_PLACEHOLDER)
                ||
                (textBox2.Text == "" || textBox2.Text == LOGIN_PLACEHOLDER)
                ||
                (textBox3.Text == "" || textBox3.Text == PASSWORD_PLACEHOLDER))
            {
                MessageBox.Show(
                    "Введіть усі поля", 
                    "Ви не ввели данні", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
            }
            else if (!Program.IsUniqueLogin(textBox2.Text))
            {
                MessageBox.Show(
                    "Будь-ласка оберіть інший логін",
                    "Логін не є унікальними",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (textBox3.Text != textBox4.Text)
            {
                MessageBox.Show("Паролі не співпадають",
                    "Паролі не співпадають",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                Program.CustomerAccounts.Add(new AccountCustomer(
                    textBox2.Text,
                    textBox3.Text,
                    (uint)Program.CustomerAccounts.Count,
                    textBox1.Text));
                Close();
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            HidePlaceholder(sender, FULLNAME_PLACEHOLDER);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            HidePlaceholder(sender, LOGIN_PLACEHOLDER);
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            textBox3.PasswordChar = '*';
            HidePlaceholder(sender, PASSWORD_PLACEHOLDER);
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            textBox4.PasswordChar = '*';
            HidePlaceholder(sender, PASSWORD_REPEAT_PLACEHOLDER);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ShowPlaceholder(sender, FULLNAME_PLACEHOLDER);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            ShowPlaceholder(sender, LOGIN_PLACEHOLDER);

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.PasswordChar = '\0';
            }
            ShowPlaceholder(sender, PASSWORD_PLACEHOLDER);
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.PasswordChar = '\0';
            }
            ShowPlaceholder(sender, PASSWORD_REPEAT_PLACEHOLDER);
        }
    }
}
