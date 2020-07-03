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
using Microsoft.AspNetCore.Http;

namespace DevsterCv.Controllers
{
    public class EmployeeMiddlewaresController : Controller
    {
        public ActionResult Admin(int employeeid)
        {
            List<MiddlewareViewModel> Middlewareviewmodellist = new List<MiddlewareViewModel>();
            List<Middleware> employeemiddlewarelist = MiddlewareService.GetByEmployee(employeeid);
            using var context = new SqlLiteContext();
            List<Middleware> middlewarelist = context.Middlewares.ToList();

            foreach (Middleware t in middlewarelist)
            {
                MiddlewareViewModel mvm = new MiddlewareViewModel();
                mvm.MiddlewareId = t.MiddlewareId;
                mvm.EmployeeId = employeeid;
                mvm.Name = t.Name;
                foreach (Middleware te in employeemiddlewarelist)
                {
                    if (t.MiddlewareId == te.MiddlewareId)
                    {
                        mvm.Connected = true;
                    }
                }
                Middlewareviewmodellist.Add(mvm);
            }
            var sortedlist = Middlewareviewmodellist.OrderBy(foo => foo.Name).ToList();
            var arv = new BindEmployeeMiddlewareViewModel(sortedlist);
            return View(arv);
        }


        public ActionResult Add(BindEmployeeMiddlewareViewModel arv)
        {
            SqlLiteContext context = new SqlLiteContext();
            for (int i = 0; i < arv.Middlewares.Count(); i++)
            {
                var employeeMiddleware = context.EmployeeMiddlewares.Where(a => a.EmployeeId == arv.Middlewares[i].EmployeeId && a.MiddlewareId == arv.Middlewares[i].MiddlewareId).FirstOrDefault();

                if (arv.Middlewares[i].Connected)
                {
                    if (employeeMiddleware == null)
                    {
                        var et = new EmployeeMiddleware();
                        et.EmployeeId = arv.Middlewares[i].EmployeeId;
                        et.MiddlewareId = arv.Middlewares[i].MiddlewareId;
                        var entity = context.EmployeeMiddlewares.Add(et);
                        entity.State = EntityState.Added;
                    }

                }
                else
                {
                    if (employeeMiddleware != null)
                    {
                        var entity = context.EmployeeMiddlewares.Remove(employeeMiddleware);
                        entity.State = EntityState.Deleted;
                    }
                }
            }

            context.SaveChanges();

            return RedirectToAction("Cv", "Home", new { id = arv.Middlewares[0].EmployeeId });
        }

    }
}
