using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevsterCv;
using DevsterCv.Models;
using DevsterCv.Service;

namespace DevsterCv.Controllers
{
    public class TrainingsController : Controller
    {

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            var context = new SqlLiteContext();
            return View(await context.Trainings.OrderBy(foo => foo.Name).ToListAsync());
        }

        // GET: Trainings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var training = await context.Trainings
                .FirstOrDefaultAsync(m => m.TrainingId == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Trainings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TrainingId,Name,IsDegree")] Training training)
        {
            if (ModelState.IsValid)
            {
                bool duplicate = false;

                using var context = new SqlLiteContext();
                var trainings = context.Trainings.ToList();
                foreach (var entity in trainings)
                {
                    if (training.Name == entity.Name)
                    {
                        duplicate = true;
                    }
                }
                if (!duplicate)
                {
                    context.Add(training);
                    await context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction("Duplicate", new { name = training.Name });
        }

        // GET: Trainings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var training = await context.Trainings.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Trainings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TrainingId,Name,IsDegree")] Training training)
        {
            if (id != training.TrainingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var context = new SqlLiteContext();
                    context.Update(training);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.TrainingId))
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
            return View(training);
        }

        // GET: Trainings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var training = await context.Trainings
                .FirstOrDefaultAsync(m => m.TrainingId == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Trainings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var context = new SqlLiteContext();
            var training = await context.Trainings.FindAsync(id);
            context.Trainings.Remove(training);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(int id)
        {
            var context = new SqlLiteContext();
            return context.Trainings.Any(e => e.TrainingId == id);
        }

        public ActionResult UpdateDegree(int employeeid, string utbildning)
        {
            Training training = TrainingService.GetDegreeByEmployee(employeeid);
            if (training != null)
            {
                training.Name = utbildning;
                TrainingService.UpdateDegreeByEmployee(training);
            }
            else
            {
                Training addtrain = new Training();
                addtrain.Name = utbildning;
                TrainingService.Add(addtrain);
            }
            return RedirectToAction("Cv", "Home", new { id = employeeid });
        }

        public ActionResult UpdateCourse(int employeeid, string kurs)
        {
            Training training = TrainingService.GetDegreeByEmployee(employeeid);
            if (training != null)
            {
                training.Name = kurs;
                TrainingService.UpdateCourseByEmployee(training);
            }
            else
            {
                Training addcourse = new Training();
                addcourse.Name = kurs;
                TrainingService.Add(addcourse);
            }
            return RedirectToAction("Cv", "Home", new { id = employeeid });
        }

        public IActionResult Duplicate(string name)
        {
            ViewBag.Name = name;
            return View();
        }
    }
}
