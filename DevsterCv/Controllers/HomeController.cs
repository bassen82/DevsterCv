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
using Dropbox.Api;
using DevsterCv.Service;

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


        public ViewResult Cv(int id)
        {
            CvViewModel CompleteCv = new CvViewModel();
            Assigment assigment = new Assigment();
            Assigment focusassingment = new Assigment();
            Employee employee = new Employee();

            Expertise expertise = new Expertise();
            Middleware middelware = new Middleware();
            Training training = new Training();
            Trade trade = new Trade();
            Technique tech = new Technique();

            var emp = EmployeeService.Get(id);

            CompleteCv.Employee = employee.GetEmployeeView(emp);
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


        public IActionResult About()
        {
            
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
