using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchool.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public String Sex { get; set; }
        public int Budget { get; set; }
        public List<Order> Orders { get; set; }
    }
}
