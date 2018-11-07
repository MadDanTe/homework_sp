using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebSchool.ViewModel
{
    public class OrderViewModel
    {
        public string Number { get; set; }
        public decimal TotalSum => Items.Sum(x=> x.TotalSum);
        public List<OrderItemViewModel> Items { get; set; }
    }
}
