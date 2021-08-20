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
using Shop.Models;

namespace Shop
{
    public partial class Auth : Form
    {
        private const string LOGIN_PLACEHOLDER = "Введіть логін";
        private const string PASSWORD_PLACEHOLDER = "Введіть пароль";

        public Auth()
        {
            InitializeComponent();
            textBox1.Text = LOGIN_PLACEHOLDER;
            textBox2.Text = PASSWORD_PLACEHOLDER;
            comboBox1.Text = "Тип аккаунту";
            comboBox1.Items.Add("Покупець");
            comboBox1.Items.Add("Продавець");
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

        private void textBox1_Enter(object sender, EventArgs e)
        {
            HidePlaceholder(sender, LOGIN_PLACEHOLDER);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            ShowPlaceholder(sender, LOGIN_PLACEHOLDER);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            HidePlaceholder(sender, PASSWORD_PLACEHOLDER);
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if(textBox2.Text == "")
            {
                textBox2.PasswordChar = '\0';
            }
            ShowPlaceholder(sender, PASSWORD_PLACEHOLDER);
        }

        private void Auth_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (
                comboBox1.SelectedIndex == -1
                ||
                (textBox1.Text == "" || textBox1.Text == LOGIN_PLACEHOLDER)
                ||
                (textBox2.Text == "" || textBox2.Text == PASSWORD_PLACEHOLDER))
            {
                MessageBox.Show("Введіть усі поля", "Ви не ввели данні", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    foreach (AccountCustomer account in Program.CustomerAccounts)
                    {
                        if (
                        textBox1.Text == account.Login
                        &&
                        textBox2.Text == account.Password)
                        {
                            Program.CurrentCustomer = account;
                            Hide();
                            new CustomerMenu().ShowDialog();
                            return;
                        }
                    }
                    MessageBox.Show(
                                "Перевірте введені данні",
                                "Данні не співпадають",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    if (
                        textBox1.Text == Program.AccountSeller.Login
                        &&
                        textBox2.Text == Program.AccountSeller.Password)
                    {
                        Hide();
                        new SellerMenu().ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Перевірте введені данні",
                            "Данні не співпадають",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new Regestration().ShowDialog();
        }
    }
}
