using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

            return View();
        }
    }
}
