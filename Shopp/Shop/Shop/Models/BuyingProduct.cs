using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class BuyingProduct : Product
    {
        public DateTime BuyingDate { get; private set; }
        public bool IsDelivered { get; private set; }
        public AccountCustomer Customer { get; private set; }

        public BuyingProduct(
            string name,
            double cost,
            string companyName,
            string description,
            uint count,
            DateTime buyingDate,
            bool isDelivered,
            AccountCustomer customer) : base(
                name, 
                cost, 
                companyName, 
                description, 
                count)
        {
            BuyingDate = buyingDate;
            IsDelivered = isDelivered;
            Customer = customer;
        }

        public BuyingProduct(string[] args) : this(
            args[0],
            double.Parse(args[1]),
            args[2],
            args[3],
            uint.Parse(args[4]),
            DateTime.Parse(args[5]),
            bool.Parse(args[6]),
            Program.CustomerAccounts[int.Parse(args[7])])
        {

        }

        public BuyingProduct(BasketProduct product) : this(
            product.Name,
            product.Cost,
            product.CompanyName,
            product.Description,
            product.Count,
            DateTime.Now,
            false,
            product.Customer)
        {

        }

        public override string ToString()
        {
            return String.Join(
                "|", 
                base.ToString(), 
                BuyingDate,
                IsDelivered,
                Customer.Id);
        }
    }
}
