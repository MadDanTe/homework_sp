using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchool.Models
{
    public class Order
    {
        public Order()
        {
            Number = GenerateNumber();
            Items = new List<OrderItem>();
        }

        public int ID { get; set; }
        public string Number { get; set; }
        public List<OrderItem> Items { get; set; }

        private string GenerateNumber()
        {
            return $"{DateTime.Now.ToString("yyyyMMdd-HHmmss")}";
        }
    }
}
