using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product
    {
        public string ImagePath { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public uint Count { get; set; }

        public Product()
        {

        }

        public Product(
            string name, 
            double cost, 
            string companyName, 
            string description,
            uint count)
        {
            Name = name;
            Cost = cost;
            CompanyName = companyName;
            Description = description;
            Count = count;
        }

        public Product(string[] args) : this(
            args[0],
            double.Parse(args[1]),
            args[2],
            args[3],
            uint.Parse(args[4]))
        {
            ImagePath = args[5];
        }

        public override string ToString()
        {
            return String.Join(
                "|",
                Name, 
                Cost,
                CompanyName,
                Description,
                Count);
        }

        public string Stringify()
        {
            return ToString() + "|" + ImagePath;
        }
    }
}
