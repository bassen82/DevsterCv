using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevsterCv.Models;
using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevsterCv.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index(String search)
        {
            if (search != null)
            {
                List<SearchViewModel> searchviewmodels = new List<SearchViewModel>();

            var middlewares = SearchService.SearchMiddleware(search);
            var techniques = SearchService.SearchTechnique(search);
            var trades = SearchService.SearchTrade(search);
            var expertises = SearchService.SearchExpertise(search);
            var trainings = SearchService.SearchTraining(search);
            var assignments = SearchService.SearchAssignment(search);


                List<SearchViewModel> allResults = searchviewmodels.Concat(middlewares).Concat(techniques).Concat(trades).Concat(expertises).Concat(trainings).Concat(assignments).ToList();
                return View(allResults.OrderBy(x => x.EmployeeName));
            }
            else
            {
                return View();
            }
        }

 


        public IActionResult Search(String search)
        {
            List<SearchViewModel> searchviewmodels = new List<SearchViewModel>();
           
            var context = new SqlLiteContext();

            var query = from e in context.Employees
                        join d in context.EmployeeMiddlewares on e.EmployeeId equals d.EmployeeId
                        join f in context.Middlewares on d.MiddlewareId equals f.MiddlewareId
                        where f.Name == search
                        select new
                        {
                            Entity = "Middleware/Databas",
                            f.Name,
                            e.EmployeeId,
                            e.EmployeeName
                        };

            var list = query.ToList();
            foreach (var i in list)
            {
                SearchViewModel svm = new SearchViewModel();
                svm.Entity = i.Entity;
                svm.Name = i.Name;
                svm.EmployeeId = i.EmployeeId;
                svm.EmployeeName = i.EmployeeName;
                searchviewmodels.Add(svm);
            }

            if (search != null)
            {
                return View(searchviewmodels);
            }
            else
            {
                return View();
            }
          
        }
    }
}