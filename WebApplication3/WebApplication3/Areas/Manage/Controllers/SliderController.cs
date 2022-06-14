using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Dal;
using WebApplication3.Models;
using WebApplication3.Utilites;

namespace WebApplication3.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class SliderController : Controller
    {
        private  readonly IWebHostEnvironment _env;

        private AppDbContext _context { get; }

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task< IActionResult> Index()
        {
          List<Slider> slider = await _context.sliders.ToListAsync();
            
            return View(slider);
        }
      
        public IActionResult Create()
        {
            


            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool Mustik= _context.sliders.Any(x=>x.FullName==slider.FullName);
            if (Mustik)
            {
                return View();

            }
            if (slider.Iphoto.CheckSize(200))
            {
                ModelState.AddModelError("Photo", "File must be less than 200kb");
                return View();
            }
            if (!slider.Iphoto.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "File must be image");
                return View();
            }
            slider.Images = await slider.Iphoto.SaveFileAsync(Path.Combine(_env.WebRootPath, "images"));

            await _context.sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update(int  Id)
        {

            Slider slider = _context.sliders.Find(Id);
            if (slider==null)
            {
                return BadRequest();

            }
            return View(slider);



        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Update(int Id,Slider slider)
        {
            Slider slider1 = _context.sliders.Find(Id);
            if (slider1==null)
            {
                return BadRequest();

            }
            if (slider.Iphoto.CheckSize(200))
            {
                ModelState.AddModelError("Photo", "File must be less than 200kb");
                return View();
            }
            if (!slider.Iphoto.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "File must be image");
                return View();
            }
            slider.Images = await slider.Iphoto.SaveFileAsync(Path.Combine(_env.WebRootPath, "images"));

            slider1.FullName = slider.FullName;
            slider1.Description = slider.Description;
            slider1.Images = slider.Images;
            slider1.Lorem = slider.Lorem;
         
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
        public IActionResult Delete(int Id)
        {
            Slider slider = _context.sliders.Find(Id);
            if (slider==null)
            {
                return BadRequest();

            }
            _context.sliders.Remove(slider);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
