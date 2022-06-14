using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApplication3.Dal;
using WebApplication3.Models;

namespace WebApplication3.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class CatagoryController : Controller
    {
        private AppDbContext _context { get; }

        public CatagoryController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
          List<Catagory> catagory = _context.catagories.ToList();
            return View(catagory);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( Catagory catagory)
        {
            bool Mustik = _context.catagories.Any(x => x.Model == catagory.Model);
            if (Mustik)
            {
                return View();
            }
            _context.catagories.Add(catagory);
            _context.SaveChanges();
            return RedirectToAction (nameof(Index));

        }
        public IActionResult Delete(int Id)
        {
            Catagory catagory = _context.catagories.Find(Id);
            if (catagory==null)
            {
                return BadRequest();


            }
            _context.catagories.Remove(catagory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Update(int Id)
        {
            Catagory catagory = _context.catagories.Find(Id);
            if (catagory==null)
            {
                return BadRequest();

            }


            return View(catagory);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int Id,Catagory catagory)
        {
            Catagory catagory1 = _context.catagories.Find(Id);
            if (catagory == null)
            {
                return BadRequest();

            }
            catagory1.Model = catagory.Model;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
