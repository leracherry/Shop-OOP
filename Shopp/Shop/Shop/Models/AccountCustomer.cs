using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class AccountCustomer : Account
    {
        public uint Id { get; set; }
        public string FullName { get; set; }
        public List<BasketProduct> Basket { get; } = new List<BasketProduct>();

        public AccountCustomer(
            string login, 
            string password,
            uint id,
            string fullName) : base(login, password)
        {
            Id = id;
            FullName = fullName;
        }

        public AccountCustomer(string[] args) : this(
            args[0], 
            args[1], 
            uint.Parse(args[2]), 
            args[3])
        {

        }

        public override string ToString()
        {
            return String.Join(
                "|", 
                base.ToString(),
                Id,
                FullName,
                Basket.Count);
        }
    }
}
