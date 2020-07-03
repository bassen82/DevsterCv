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
using DevsterCv.Models.ViewModels;

namespace DevsterCv.Controllers
{
    public class AssigmentsController : Controller
    {
        // GET: Assigments
        public IActionResult Index()
        {
            List<AssignmentViewModel> AssignmentViewModels = new List<AssignmentViewModel>();
            List<Assigment> targetData = AssignmentService.GetEvery();

            if (targetData != null)
            {
                foreach (Assigment target in targetData)
                {

                    Employee employee = EmployeeService.Get(target.Employeeid);
                    AssignmentViewModel avm = new AssignmentViewModel
                    {
                        Id = target.Id,
                        Employee = employee,
                        Beskrivning = target.Beskrivning,
                        Roll = target.Roll,
                        Teknik = target.Teknik,
                        Tid = target.Tid,
                        Uppdrag = target.Uppdrag,
                        Focus = target.Focus
                    };
                    if (employee == null)
                    {
                        Employee temp = new Employee();
                        temp.EmployeeId = 0;
                            temp.EmployeeName = "INTE KOPPLAD TILL NÅGON ANSTÄLLD";
                        avm.Employee = temp;
                    }
                    AssignmentViewModels.Add(avm);
                }
            }
            var sortedlist = AssignmentViewModels.OrderBy(foo => foo.Employee.EmployeeName).ToList();
            return View(sortedlist);
        }

        // GET: Assigments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            AssignmentViewModel assignmentviewmodel = new AssignmentViewModel();
            var context = new SqlLiteContext();
            Assigment assigment = await context.Assigments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assigment == null)
            {
                return NotFound();
            }
            AssignmentViewModel avm = new AssignmentViewModel
            {
                Id = assigment.Id,
                Employee = EmployeeService.Get(assigment.Employeeid),
                Beskrivning = assigment.Beskrivning,
                Roll = assigment.Roll,
                Teknik = assigment.Teknik,
                Tid = assigment.Tid,
                Uppdrag = assigment.Uppdrag,
                Focus = assigment.Focus
            };
            return View(avm);
        }

        // GET: Assigments/Create
        public IActionResult Create()
        {
            List<SelectItem> list = new List<SelectItem>();
            List<Employee> employees = EmployeeService.GetAll();
            foreach (Employee c in employees)
            {
                SelectItem item = new SelectItem { Key = c.EmployeeId.ToString(), Value = c.EmployeeName };
                list.Add(item);
            }

            AssignmentViewModel avm = new AssignmentViewModel
            {
                Employees = list
            };
            return View(avm);
        }

        // POST: Assigments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Employeeid,SelectedEmployeeId,Uppdrag,Tid,Roll,Beskrivning,Teknik,Focus")] AssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Assigment assignment = new Assigment
                {
                    Employeeid = model.SelectedEmployeeId,
                    Beskrivning = model.Beskrivning,
                    Uppdrag = model.Uppdrag,
                    Focus = model.Focus,
                    Roll = model.Roll,
                    Tid = model.Tid,
                    Teknik = model.Teknik,
                    
                };


                var context = new SqlLiteContext();
                context.Add(assignment);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Assigments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AssignmentViewModel assignmentviewmodel = new AssignmentViewModel();
            var context = new SqlLiteContext();
            Assigment assigment = await context.Assigments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assigment == null)
            {
                return NotFound();
            }

            List<Employee> employees = EmployeeService.GetAll();
            var items = new List<SelectItem>();

            foreach (Employee c in employees)
            {
                SelectItem item = new SelectItem { Key = c.EmployeeId.ToString(), Value = c.EmployeeName, Selected = assigment.Employeeid };
                items.Add(item);
            }

            AssignmentViewModel avm = new AssignmentViewModel
            {
                Id = assigment.Id,
                Employee = EmployeeService.Get(assigment.Employeeid),
                Employees = items,
                Beskrivning = assigment.Beskrivning,
                Roll = assigment.Roll,
                Teknik = assigment.Teknik,
                Tid = assigment.Tid,
                Uppdrag = assigment.Uppdrag,
                Focus = assigment.Focus
            };
            return View(avm);
        }


        // POST: Assigments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Employee,EmployeeId,Uppdrag,Tid,Roll,Beskrivning,Teknik,Focus")] AssignmentViewModel assigmentviewmodel)
        {
            if (id != assigmentviewmodel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                try
                {
                    Assigment assignment = AssignmentService.Get(assigmentviewmodel.Id);

                    assignment.Id = assigmentviewmodel.Id;
                    assignment.Employeeid = assigmentviewmodel.Employee.EmployeeId;
                    assignment.Beskrivning = assigmentviewmodel.Beskrivning;
                    assignment.Focus = assigmentviewmodel.Focus;
                    assignment.Uppdrag = assigmentviewmodel.Uppdrag;
                    assignment.Roll = assigmentviewmodel.Roll;
                    assignment.Teknik = assigmentviewmodel.Teknik;
                    assignment.Tid = assigmentviewmodel.Tid;

                    var context = new SqlLiteContext();
                    context.Update(assignment);
                    await context.SaveChangesAsync();


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssigmentExists(assigmentviewmodel.Id))
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
            
            return View();
        }

        // GET: Assigments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var assigment = await context.Assigments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assigment == null)
            {
                return NotFound();
            }

            AssignmentViewModel avm = new AssignmentViewModel
            {
                Id = assigment.Id,
                Employee = EmployeeService.Get(assigment.Employeeid),
            Beskrivning = assigment.Beskrivning,
                Roll = assigment.Roll,
                Teknik = assigment.Teknik,
                Tid = assigment.Tid,
                Uppdrag = assigment.Uppdrag,
                Focus = assigment.Focus
            };

            return View(avm);
        }

        // POST: Assigments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var context = new SqlLiteContext();
            var assigment = await context.Assigments.FindAsync(id);
            context.Assigments.Remove(assigment);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssigmentExists(int id)
        {
            var context = new SqlLiteContext();
            return context.Assigments.Any(e => e.Id == id);
        }

        public ActionResult CreateByEmployee(int employeeid, string uppdrag, string roll, string tid, string beskrivning, string teknik, string focus)
        {
            Assigment assignment = new Assigment(employeeid, uppdrag, roll, tid, beskrivning, teknik, check(focus));

            AssignmentService.Add(assignment);

            return RedirectToAction("Cv", "Home", new { id = employeeid });
        }

        public ActionResult UpdateByEmployee(int employeeid, int id, string uppdrag, string roll, string tid, string beskrivning, string teknik, string focus)
        {
            Assigment assignment = AssignmentService.Get(id);
            assignment.Roll = roll;
            assignment.Uppdrag = uppdrag;

            assignment.Tid = tid;
            assignment.Beskrivning = beskrivning;
            assignment.Teknik = teknik;
            assignment.Focus = check(focus);

            AssignmentService.Update(assignment);

            return RedirectToAction("Cv", "Home", new { id = employeeid });
        }

        public ActionResult DeleteByEmployee(int id)
        {

            Assigment assignment = AssignmentService.Get(id);
            AssignmentService.Delete(assignment);

            return RedirectToAction("Cv", "Home", new { id = assignment.Employeeid });
        }

        private static bool check(string s)
        {
            return (s == null || s == String.Empty) ? false : true;
        }
    }
}
