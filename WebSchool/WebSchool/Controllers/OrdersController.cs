using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSchool.Data;
using WebSchool.Models;

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
            return View();
        }
    }
}
