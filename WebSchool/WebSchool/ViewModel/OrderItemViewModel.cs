using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchool.ViewModel
{
    public class OrderItemViewModel
    {
        public decimal TotalSum => ProductPrice * Count;
        public string ProductName { get; set; }
        public int Count { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
