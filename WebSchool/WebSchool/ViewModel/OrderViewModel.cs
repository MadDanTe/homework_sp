using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSchool.Models;

namespace WebSchool.ViewModel
{
    public class OrderViewModel
    {
        public int ID { get; set; }
        public string Number { get; set; }
        public decimal TotalSum => Items.Sum(x=> x.TotalSum);
        public List<OrderItemViewModel> Items { get; set; }
        public OrderStatus status { get; internal set; }
    }
}
