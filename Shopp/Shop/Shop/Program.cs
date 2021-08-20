using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shop.Models;
using System.IO;

namespace Shop
{
    static class Program
    {
        public static AccountSeller AccountSeller;
        public static AccountCustomer CurrentCustomer;
        public static List<AccountCustomer> CustomerAccounts = new List<AccountCustomer>();
        public static List<Product> AllProduct = new List<Product>();
        public static List<BuyingProduct> BuyingProducts = new List<BuyingProduct>();
        private static string PathToSeller = Environment.CurrentDirectory + @"\Seller.txt";
        private static string PathToCustomers = Environment.CurrentDirectory + @"\Customers.txt";
        private static string PathToBuyingProducts = Environment.CurrentDirectory + @"\BuyingProducts.txt";
        private static string PathToProducts = Environment.CurrentDirectory + @"\Products.txt";

        [STAThread]
        static void Main(string[] args)
        {
            LoadSeller();
            if (args.Length == 0)
            {
                LoadProducts();
                LoadCustomers();
                LoadBuyingProducts();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Auth());
            }
            else if(args.Length == 3)
            {
                if(args[0] == "editLogin")
                {
                    if (args[1] == AccountSeller.Password)
                    {
                        AccountSeller.Login = args[2];
                        SaveSeller();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Ви ввели не вірний пароль",
                            "Невірний пароль",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }

                }
                else if(args[0] == "editPassword")
                {
                    if (args[1] == AccountSeller.Password)
                    {
                        AccountSeller.Password = args[2];
                        SaveSeller();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Ви ввели не вірний пароль",
                            "Невірний пароль",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Існує лише: editLogin чи editPassword",
                        "Немає такої команди",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ви ввели не вірні параметри.\n" +
                    "Ввести треба в такому форматі: [editLogin|editPassword] currentPassword" +
                    " [newLogin|newPassword]",
                    "Недостающее количество данных",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static bool IsUniqueLogin(string login)
        {
            foreach(AccountCustomer account in CustomerAccounts)
            {
                if(CurrentCustomer != null)
                {
                    if (CurrentCustomer.Login == login)
                    {
                        return true;
                    }
                }

                if(account.Login == login)
                {
                    return false;
                }
            }
            return true;
        }

        public static void SaveProducts()
        {
            using (StreamWriter sw = new StreamWriter(PathToProducts))
            {
                foreach(Product product in AllProduct)
                {
                    sw.WriteLine(product.Stringify());
                }
            }
        }

        public static void SaveSeller()
        {
            using (StreamWriter sw = new StreamWriter(PathToSeller))
            {
                sw.WriteLine(CurrentCustomer);
            }
        }

        public static void SaveBuyingProducts()
        {
            using (StreamWriter sw = new StreamWriter(PathToBuyingProducts))
            {
                foreach (BuyingProduct product in BuyingProducts)
                {
                    sw.WriteLine(product);
                }
            }
        }

        public static void SaveCustomers()
        {
            using (StreamWriter sw = new StreamWriter(PathToCustomers))
            {
                foreach (AccountCustomer account in CustomerAccounts)
                {
                    sw.WriteLine(account);
                    foreach(BasketProduct product in account.Basket)
                    {
                        sw.WriteLine(product);
                    }
                }
            }
        }

        public static void LoadProducts()
        {
            using (StreamReader sr = new StreamReader(PathToProducts))
            {
                string line = null;
                while((line = sr.ReadLine()) != null)
                {
                    string[] a = line.Split('|');
                    AllProduct.Add(new Product(a));
                }
            }
        }

        public static void LoadSeller()
        {
            using (StreamReader sr = new StreamReader(PathToSeller))
            {
                string[] a = sr.ReadLine().Split('|');
                AccountSeller = new AccountSeller(a);
            }
        }

        public static void LoadBuyingProducts()
        {
            using (StreamReader sr = new StreamReader(PathToBuyingProducts))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] a = line.Split('|');
                    BuyingProducts.Add(new BuyingProduct(a));
                }
            }
        }

        public static void LoadCustomers()
        {
            using (StreamReader sr = new StreamReader(PathToCustomers))
            {
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] a = line.Split('|');
                    AccountCustomer account = new AccountCustomer(a);
                    CustomerAccounts.Add(account);
                    int c = int.Parse(a[a.Length - 1]);
                    for(int i = 0; i < c; i++)
                    {
                        a = sr.ReadLine().Split('|');
                        new BasketProduct(a);
                    }
                }
            }
        }
    }
}
