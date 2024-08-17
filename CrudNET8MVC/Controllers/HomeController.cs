using CrudNET8MVC.Data;
using CrudNET8MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CrudNET8MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.People.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(People NewPeople)
        {

            if (ModelState.IsValid)
            {

                //Add createdAt
                NewPeople.CreatedAt = DateTime.Now;

                _context.People.Add(NewPeople);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var People = _context.People.Find(Id);

            if (People == null)
            {
                return NotFound();
            }

            return View(People);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(People NewPeople)
        {

            if (ModelState.IsValid)
            {
                _context.Update(NewPeople);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }

            var People = _context.People.Find(Id);
            
            if(People == null)
            {
                return NotFound();
            }

            return View(People);
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var People = _context.People.Find(Id);

            if (People == null)
            {
                return NotFound();
            }

            return View(People);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteById(int? Id)
        {

            var People = await _context.People.FindAsync(Id);
            if(People == null)
            {
                return NotFound();
            }

            _context.People.Remove(People);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
