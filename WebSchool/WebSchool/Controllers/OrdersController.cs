using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebSchool.Data;
using WebSchool.Models;
using WebSchool.ViewModel;

namespace WebSchool.Controllers
{
    public class OrdersController : Controller
    {
        private readonly WebSchoolContext _context;

        public OrdersController(WebSchoolContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var orders = await _context.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .ToListAsync();
            var ordersViewModel = orders
                .Select(order => new OrderViewModel
                {
                    Number = order.Number,
                    Items = order.Items
                    .Select(item => new OrderItemViewModel
                    {
                        ProductName = item.Product.Name,
                        ProductPrice = item.Product.Price,
                        Count = item.Count
                    }).ToList()
                });
            return View(ordersViewModel);
        }

        [HttpGet]
        [Route("Order/AddOrd")]
        public async Task<IActionResult> AddOrd(int? ID)
        {
            var orderItem = await _context.OrderItems.FirstOrDefaultAsync(x=> x.ProductId==ID);
            if (orderItem != null)
            {
                orderItem.Count = orderItem.Count + 1;
                _context.OrderItems.Update(orderItem);
                _context.SaveChanges();
            }
            else
            {
                orderItem = new OrderItem(await _context.Products.FindAsync(ID), 1);
                if (!await _context.Orders.AnyAsync())
                {
                    var order = new Order();
                    order.Items.Add(orderItem);
                    _context.Orders.Add(order);
                }
                else
                {
                    var order = _context.Orders.First();
                    order.Items.Add(orderItem);
                    _context.Orders.Update(order);
                }
                //_context.OrderItems.Add(orderItem);
                _context.SaveChanges();
            }

            return View(orderItem);
        }
    }
}
