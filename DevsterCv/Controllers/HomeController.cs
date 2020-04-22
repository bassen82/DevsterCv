using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DevsterCv.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DevsterCv.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cv(String c)
        {

            CvViewModel CompleteCv = new CvViewModel();
            Assigment assigment = new Assigment();
            FocusAssignment focusassigment = new FocusAssignment();
            Contact contact = new Contact();
            Employee employee = new Employee();
            Spec spec = new Spec();

            CompleteCv.Assigments = assigment.GetAllAssignmentsAsync(c, "Uppdrag");
            CompleteCv.Contact = contact.GetContactAsync(c, "Kontakt");
            CompleteCv.Employee = employee.GetEmployeeAsync(c, "Profile");
            CompleteCv.FocusAssigments = focusassigment.GetAllAssignmentsAsync(c, "Uppdragifokus");
            CompleteCv.Spec = spec.GetSpecAsync(c, "Spec");
           

            return View(CompleteCv);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
