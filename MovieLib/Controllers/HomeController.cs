using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieLib.Data;
using MovieLib.Models;

namespace MovieLib.Controllers
{
    public class HomeController : Controller
    {
        private ModelsContext db;
        public HomeController(ModelsContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Movies.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieModel movie)
        {
            db.Movies.Add(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
