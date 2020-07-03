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
    public class ExpertisesController : Controller
    {
      

        // GET: Expertises
        public async Task<IActionResult> Index()
        {
            using var context = new SqlLiteContext();
            return View(await context.Expertises.OrderBy(foo => foo.Name).ToListAsync());
        }

        // GET: Expertises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var context = new SqlLiteContext();
            var expertise = await context.Expertises
                .FirstOrDefaultAsync(m => m.ExpertiseId == id);
            if (expertise == null)
            {
                return NotFound();
            }

            return View(expertise);
        }

        // GET: Expertises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Expertises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExpertiseId,Name")] Expertise expertise)
        {
            if (ModelState.IsValid)
            {
                bool duplicate = false;

                using var context = new SqlLiteContext();
                var expertises = context.Expertises.ToList();
                foreach (var entity in expertises)
                {
                    if (expertise.Name == entity.Name)
                    {
                        duplicate = true;
                    }
                }
                if (!duplicate)
                {
                    context.Add(expertise);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction("Duplicate", new { name = expertise.Name });
        }

        // GET: Expertises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var context = new SqlLiteContext();
            var expertise = await context.Expertises.FindAsync(id);
            if (expertise == null)
            {
                return NotFound();
            }
            return View(expertise);
        }

        // POST: Expertises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExpertiseId,Name")] Expertise expertise)
        {
            if (id != expertise.ExpertiseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    using var context = new SqlLiteContext();
                    context.Update(expertise);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpertiseExists(expertise.ExpertiseId))
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
            return View(expertise);
        }

        // GET: Expertises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            using var context = new SqlLiteContext();
            var expertise = await context.Expertises
                .FirstOrDefaultAsync(m => m.ExpertiseId == id);
            if (expertise == null)
            {
                return NotFound();
            }

            return View(expertise);
        }

        // POST: Expertises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            using var context = new SqlLiteContext();
            var expertise = await context.Expertises.FindAsync(id);
            context.Expertises.Remove(expertise);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpertiseExists(int id)
        {
            using var context = new SqlLiteContext();
            return context.Expertises.Any(e => e.ExpertiseId == id);
        }

        public IActionResult Duplicate(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
