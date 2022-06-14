using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dal;
using WebApplication3.Models;
using WebApplication3.ViewModel;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }

        public HomeController(AppDbContext context)
        {
            _context = context;

        }

        public IActionResult Index()
        {

            Vm vm = new Vm { 
                catagory=_context.catagories.ToList(),
                Sliders=_context.sliders.ToList()
            
            
            };

            return View(vm);
        }

       


    }
}
