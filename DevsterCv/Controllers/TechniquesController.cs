using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevsterCv;
using DevsterCv.Models;
using X.PagedList;

namespace DevsterCv.Controllers
{
    public class TechniquesController : Controller
    {

        // GET: Techniques
        public IActionResult Index()
        {
             using var context = new SqlLiteContext();
           var techniques = context.Techniques.OrderBy(foo => foo.Name).ToList();

            return View(techniques);
        }

        // GET: Techniques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using var context = new SqlLiteContext();
            var technique = await context.Techniques
                .FirstOrDefaultAsync(m => m.TechniqueId == id);
            if (technique == null)
            {
                return NotFound();
            }

            return View(technique);
        }

        // GET: Techniques/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Techniques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechniqueId,Name")] Technique technique)
        {
            if (ModelState.IsValid)
            {
                bool duplicate = false;
                
                using var context = new SqlLiteContext();
                var techniques = context.Techniques.ToList();
                foreach (var entity in techniques)
                {
                    if (technique.Name == entity.Name)
                    {
                        duplicate = true;
                    }
                }
                if (!duplicate)
                {
                    context.Add(technique);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction("Duplicate", new { name = technique.Name });
        }

        // GET: Techniques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            using var context = new SqlLiteContext();
            var technique = await context.Techniques.FindAsync(id);
            if (technique == null)
            {
                return NotFound();
            }
            return View(technique);
        }

        // POST: Techniques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechniqueId,Name")] Technique technique)
        {
            if (id != technique.TechniqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using var context = new SqlLiteContext();
                    context.Update(technique);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechniqueExists(technique.TechniqueId))
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
            return View(technique);
        }

        // GET: Techniques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var context = new SqlLiteContext();
            var technique = await context.Techniques
                .FirstOrDefaultAsync(m => m.TechniqueId == id);
            if (technique == null)
            {
                return NotFound();
            }

            return View(technique);
        }

        // POST: Techniques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using var context = new SqlLiteContext();
            var technique = await context.Techniques.FindAsync(id);
            context.Techniques.Remove(technique);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechniqueExists(int id)
        {
            using var context = new SqlLiteContext();
            return context.Techniques.Any(e => e.TechniqueId == id);
        }

        public IActionResult Duplicate(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
