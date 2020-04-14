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
            string[] dirs = Directory.GetDirectories(@"C:\CvAppen\Devster");
            List<string> employees = new List<string>();

            foreach (string dir in dirs)
            {
                String name = dir.Substring(19);
                employees.Add(name);
            }

            var query = employees.Select(c => new { c });
            ViewBag.c = new SelectList(query.AsEnumerable(), "c", "c", 3);

            return View();
        }

        public IActionResult Privacy(string name)
        {

            return View();
        }

        [HttpPost]
        public IActionResult Cv(String c)
        {
            CvViewModel CompleteCv = new CvViewModel();
            Assigment assigment = new Assigment();
            Contact contact = new Contact();
            Employee employee = new Employee();
            Spec spec = new Spec();

            CompleteCv.Assigments = assigment.GetAllAssignments(c);
            CompleteCv.Contact = contact.GetContact(c);
            CompleteCv.Employee = employee.GetEmployee(c);
            CompleteCv.Spec = spec.GetSpec(c);

            return View(CompleteCv);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
