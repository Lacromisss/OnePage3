using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Dal;
using WebApplication3.Models;

namespace WebApplication3.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashboardController : Controller
    {

       
        public  IActionResult Index()
        {
            return View();
        }
    }
}
