using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchool.Models
{
    public class OrderItem
    {
        public OrderItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }

        public int ID { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Count { get; set; }

    }
}
