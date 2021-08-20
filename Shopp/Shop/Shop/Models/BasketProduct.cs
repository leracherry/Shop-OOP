using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class BasketProduct : Product
    {
        public AccountCustomer Customer { get; private set; }


        public BasketProduct(
            string name,
            double cost,
            string companyName,
            string description,
            uint count,
            AccountCustomer customer) : base(
                name, 
                cost, 
                companyName, 
                description, 
                count)
        {
            Customer = customer;
            Customer.Basket.Add(this);
        }

        public BasketProduct(string[] args) : this(
            args[0],
            double.Parse(args[1]),
            args[2],
            args[3],
            uint.Parse(args[4]),
            Program.CustomerAccounts[int.Parse(args[5])])
        {

        }

        public BasketProduct(Product product, uint count) : this(
            product.Name,
            product.Cost,
            product.CompanyName,
            product.Description,
            count,
            Program.CurrentCustomer)
        {

        }

        public override string ToString()
        {
            return String.Join(
                "|", 
                base.ToString(),
                Customer.Id);
        }
    }
}
