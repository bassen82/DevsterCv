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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Dropbox.Api.Sharing;

namespace DevsterCv.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public EmployeesController(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            Employee emp = new Employee();
            using var context = new SqlLiteContext();
            var list = await context.Employees.OrderBy(foo => foo.EmployeeName).ToListAsync();

            var evm = emp.GetEmployeesView(list);
            return View(evm);
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            Employee employee = await context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            CvViewModel CompleteCv = new CvViewModel();
            Assigment assigment = new Assigment();
            Assigment focusassingment = new Assigment();

            Expertise expertise = new Expertise();
            Middleware middelware = new Middleware();
            Training training = new Training();
            Trade trade = new Trade();
            Technique tech = new Technique();


            CompleteCv.Employee = employee.GetEmployeeView(employee);
            CompleteCv.Expertises = expertise.GetExpertiseView(id);
            CompleteCv.Middlewares = middelware.GetMiddlewareView(id);
            CompleteCv.Techniques = tech.GetTechniqueView(id);
            CompleteCv.Trades = trade.GetTradeView(id);
            CompleteCv.DegreeTraining = training.GetDegreeTrainingView(id);
            CompleteCv.Trainings = training.GetTrainingView(id);
            CompleteCv.Assigments = assigment.GetAllNonFocusAssignments(id);
            CompleteCv.FocusAssigments = focusassingment.GetAllFocusAssignments(id);

            return View(CompleteCv);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = UploadedFile(model);
                Employee employee = new Employee
                {
                    EmployeeName = model.EmployeeName,
                    EmployeeInfo = model.EmployeeInfo,
                    EmployeRole = model.EmployeRole,
                    Interest = model.Interest,
                    ProfilePicture = uniqueFileName,
                    City = model.City,
                    Tele = model.Tele,
                    Linkedin = model.Linkedin,
                    Mail = model.Mail
                };

                var context = new SqlLiteContext();
                context.Add(employee);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        private string UploadedFile(EmployeeViewModel model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var employee = await context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee.GetEmployeeView(employee));
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
       
            if (ModelState.IsValid)
            {
                Employee employee = EmployeeService.Get(model.EmployeeId);
                
                if(model.ProfileImage != null)
                {
                    string uniqueFileName = UploadedFile(model);
                    employee.ProfilePicture = uniqueFileName;
                }
                employee.EmployeeId = model.EmployeeId;
                employee.City = model.City;
                employee.Tele = model.Tele;
                employee.Linkedin = model.Linkedin;
                employee.Mail = model.Mail;
                employee.EmployeeName = model.EmployeeName;
                employee.EmployeeInfo = model.EmployeeInfo;
                employee.EmployeRole = model.EmployeRole;
                employee.Interest = model.Interest;

                try
                {
                    var context = new SqlLiteContext();
                    context.Update(employee);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.EmployeeId))
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

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var context = new SqlLiteContext();
            var employee = await context.Employees
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var context = new SqlLiteContext();
            var employee = await context.Employees.FindAsync(id);
            context.Employees.Remove(employee);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            var context = new SqlLiteContext();
            return context.Employees.Any(e => e.EmployeeId == id);
        }

        public ActionResult UpdateEmployeeinfo(int employeeid, string employeeinfo)
        {
            Employee employee = EmployeeService.Get(employeeid);
            employee.EmployeeInfo = employeeinfo;
            EmployeeService.Update(employee);

            return RedirectToAction("Cv", "Home", new { id = employeeid });
        }
        public ActionResult UpdateEmployeerole(int employeeid, string employeerole)
        {
            Employee employee = EmployeeService.Get(employeeid);
            employee.EmployeRole = employeerole;
            EmployeeService.Update(employee);

            return RedirectToAction("Cv", "Home", new { id = employeeid });
        }

        public ActionResult UpdateEmployeeintrest(int employeeid, string intressen)
        {
            Employee employee = EmployeeService.Get(employeeid);
            employee.Interest = intressen;
            EmployeeService.Update(employee);

            return RedirectToAction("Cv", "Home", new { id = employeeid });
        }

        public ActionResult UpdateContact(int employeeid, int id, string tele, string city, string mail, string linkedin)
        {

                Employee employee = EmployeeService.Get(employeeid);

            employee.Tele = tele;
            employee.Mail = mail;
            employee.Linkedin = linkedin;
            employee.City = city;

            EmployeeService.Update(employee);
         
            return RedirectToAction("Cv", "Home", new { id = employeeid });
        }

    }
}
