using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public abstract class Account
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public Account(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public Account(string[] args) : this(args[0], args[1])
        {
            
        }

        public override string ToString()
        {
            return String.Join("|", Login, Password);
        }
    }
}
