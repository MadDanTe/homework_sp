using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchool.Models
{
    public class Product
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public decimal Price { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public Product()
        {

        }
    }
}
