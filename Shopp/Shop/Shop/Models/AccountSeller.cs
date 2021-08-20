using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class AccountSeller : Account
    {
        public AccountSeller(string login, string password) : base(login, password)
        {
            
        }

        public AccountSeller(string[] args) : base(args)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
