using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevsterCv;
using DevsterCv.Models;

namespace DevsterCv.Controllers
{
    public class MiddlewaresController : Controller
    {

        // GET: Middlewares
        public async Task<IActionResult> Index()
        {
            using var context = new SqlLiteContext();
            return View(await context.Middlewares.OrderBy(foo => foo.Name).ToListAsync());
        }

        // GET: Middlewares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var context = new SqlLiteContext();
            var middleware = await context.Middlewares
                .FirstOrDefaultAsync(m => m.MiddlewareId == id);
            if (middleware == null)
            {
                return NotFound();
            }

            return View(middleware);
        }

        // GET: Middlewares/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Middlewares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MiddlewareId,Name")] Middleware middleware)
        {
            if (ModelState.IsValid)
            {
                bool duplicate = false;
                using var context = new SqlLiteContext();
                var middlewares = context.Middlewares.ToList();
                foreach (var entity in middlewares)
                {
                    if (middleware.Name == entity.Name)
                    {
                        duplicate = true;
                    }
                }

                if (!duplicate)
                {
                context.Add(middleware);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction("Duplicate", new { name = middleware.Name });
        }

        // GET: Middlewares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var context = new SqlLiteContext();
            var middleware = await context.Middlewares.FindAsync(id);
            if (middleware == null)
            {
                return NotFound();
            }
            return View(middleware);
        }

        // POST: Middlewares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MiddlewareId,Name")] Middleware middleware)
        {
            if (id != middleware.MiddlewareId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using var context = new SqlLiteContext();
                    context.Update(middleware);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MiddlewareExists(middleware.MiddlewareId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(middleware);
        }

        // GET: Middlewares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var context = new SqlLiteContext();
            var middleware = await context.Middlewares
                .FirstOrDefaultAsync(m => m.MiddlewareId == id);
            if (middleware == null)
            {
                return NotFound();
            }

            return View(middleware);
        }

        // POST: Middlewares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using var context = new SqlLiteContext();
            var middleware = await context.Middlewares.FindAsync(id);
            context.Middlewares.Remove(middleware);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MiddlewareExists(int id)
        {
            using var context = new SqlLiteContext();
            return context.Middlewares.Any(e => e.MiddlewareId == id);
        }

        public IActionResult Duplicate(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
