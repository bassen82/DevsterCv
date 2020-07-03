using DevsterCv.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Service
{
    public class SearchService
    {
        public static List<SearchViewModel> SearchMiddleware(string search)
        {
            List<SearchViewModel> searchviewmodels = new List<SearchViewModel>();
            var context = new SqlLiteContext();

            var query = from e in context.Employees
                        join d in context.EmployeeMiddlewares on e.EmployeeId equals d.EmployeeId
                        join f in context.Middlewares on d.MiddlewareId equals f.MiddlewareId
                        where f.Name.ToLower().Contains(search.ToLower())
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
                svm.IsEmpty = false;
                searchviewmodels.Add(svm);
            }

            return searchviewmodels;
        }

        public static List<SearchViewModel> SearchTechnique(string search)
        {
            List<SearchViewModel> searchviewmodels = new List<SearchViewModel>();
            var context = new SqlLiteContext();

            var query = from e in context.Employees
                        join d in context.EmployeeTechniques on e.EmployeeId equals d.EmployeeId
                        join f in context.Techniques on d.TechniqueId equals f.TechniqueId
                        where f.Name.ToLower().Contains(search.ToLower())
                        select new
                        {
                            Entity = "Teknik/Verktyg",
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
                svm.IsEmpty = false;
                searchviewmodels.Add(svm);
            }

            return searchviewmodels;
        }

        public static List<SearchViewModel> SearchExpertise(string search)
        {
            List<SearchViewModel> searchviewmodels = new List<SearchViewModel>();
            var context = new SqlLiteContext();

            var query = from e in context.Employees
                        join d in context.EmployeeExpertises on e.EmployeeId equals d.EmployeeId
                        join f in context.Expertises on d.ExpertiseId equals f.ExpertiseId
                        where f.Name.ToLower().Contains(search.ToLower())
                        select new
                        {
                            Entity = "Expertise",
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
                svm.IsEmpty = false;
                searchviewmodels.Add(svm);
            }

            return searchviewmodels;
        }

        public static List<SearchViewModel> SearchTraining(string search)
        {
            List<SearchViewModel> searchviewmodels = new List<SearchViewModel>();
            var context = new SqlLiteContext();

            var query = from e in context.Employees
                        join d in context.EmployeeTrainings on e.EmployeeId equals d.EmployeeId
                        join f in context.Trainings on d.TrainingId equals f.TrainingId
                        where f.Name.ToLower().Contains(search.ToLower())
                        select new
                        {
                            Entity = "Utbildning/Kurs",
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
                svm.IsEmpty = false;
                searchviewmodels.Add(svm);
            }

            return searchviewmodels;
        }

        public static List<SearchViewModel> SearchTrade(string search)
        {
            List<SearchViewModel> searchviewmodels = new List<SearchViewModel>();
            var context = new SqlLiteContext();

            var query = from e in context.Employees
                        join d in context.EmployeeTrades on e.EmployeeId equals d.EmployeeId
                        join f in context.Trades on d.TradeId equals f.TradeId
                        where f.Name.ToLower().Contains(search.ToLower()) 
                        select new
                        {
                            Entity = "Bransch",
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
                svm.IsEmpty = false;
                searchviewmodels.Add(svm);
            }

            return searchviewmodels;
        }

        public static List<SearchViewModel> SearchAssignment(string search)
        {
            List<SearchViewModel> searchviewmodels = new List<SearchViewModel>();
            var context = new SqlLiteContext();

            var query = from e in context.Assigments
                        join d in context.Employees on e.Employeeid equals d.EmployeeId
                        where e.Teknik.ToLower().Contains(search.ToLower())
                        select new
                        {
                            Entity = "Uppdrag",
                            Name = e.Teknik,
                            d.EmployeeId,
                            d.EmployeeName
                        };

            var list = query.ToList();
            foreach (var i in list)
            {
                SearchViewModel svm = new SearchViewModel();
                svm.Entity = i.Entity;
                svm.Name = i.Name;
                svm.EmployeeId = i.EmployeeId;
                svm.EmployeeName = i.EmployeeName;
                svm.IsEmpty = false;
                searchviewmodels.Add(svm);
            }

            return searchviewmodels;
        }
    }
}
