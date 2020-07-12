using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly ModelsContext db;
        public HomeController(ModelsContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Catalog()
        {
            return View(await db.Movies.OrderBy(s => s.Title).ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        public async Task<IActionResult> ViewContent(string? id)
        {
            if (id != null)
            {
                MovieModel movie = await db.Movies.FirstOrDefaultAsync(p => p.ID == id);
                if (movie != null)
                    return View(movie);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(string? id)
        {
            if (id != null)
            {
                MovieModel movie = await db.Movies.FirstOrDefaultAsync(p => p.ID == id);
                if (movie != null)
                    return View(movie);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MovieModel movie)
        {
            db.Movies.Update(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Catalog");
        }
        [HttpPost]
        public async Task<IActionResult> Create(MovieModel movie)
        {
            db.Movies.Add(movie);
            await db.SaveChangesAsync();
            return RedirectToAction("Catalog");
        }
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(string? id)
        {
            if (id != null)
            {
                MovieModel movie = await db.Movies.FirstOrDefaultAsync(p => p.ID == id);
                if (movie != null)
                    return View(movie);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string? id)
        {
            if (id != null)
            {
                MovieModel movie = await db.Movies.FirstOrDefaultAsync(p => p.ID == id);
                if (movie != null)
                {
                    db.Movies.Remove(movie);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Catalog");
                }
            }
            return NotFound();
        }

    }
}
