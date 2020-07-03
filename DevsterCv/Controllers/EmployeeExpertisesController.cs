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
    public class EmployeeExpertisesController : Controller
    {
        public ActionResult Admin(int employeeid)
        {
            List<ExpertiseViewModel> Expertiseviewmodellist = new List<ExpertiseViewModel>();
            List<Expertise> employeeexpertiselist = ExpertiseService.GetByEmployee(employeeid);
            using var context = new SqlLiteContext();
            List<Expertise> expertiselist = context.Expertises.ToList();

            foreach (Expertise t in expertiselist)
            {
                ExpertiseViewModel evm = new ExpertiseViewModel();
                evm.ExpertiseId = t.ExpertiseId;
                evm.EmployeeId = employeeid;
                evm.Name = t.Name;
                foreach (Expertise te in employeeexpertiselist)
                {
                    if (t.ExpertiseId == te.ExpertiseId)
                    {
                        evm.Connected = true;
                    }
                }
                Expertiseviewmodellist.Add(evm);
            }
            var sortedlist = Expertiseviewmodellist.OrderBy(foo => foo.Name).ToList();
            var arv = new BindEmployeeExpertiseViewModel(sortedlist);
            return View(arv);
        }


        public ActionResult Add(BindEmployeeExpertiseViewModel arv)
        {
            SqlLiteContext context = new SqlLiteContext();
            for (int i = 0; i < arv.Expertises.Count(); i++)
            {
                var employeeExpertise = context.EmployeeExpertises.Where(a => a.EmployeeId == arv.Expertises[i].EmployeeId && a.ExpertiseId == arv.Expertises[i].ExpertiseId).FirstOrDefault();

                if (arv.Expertises[i].Connected)
                {
                    if (employeeExpertise == null)
                    {
                        var et = new EmployeeExpertise();
                        et.EmployeeId = arv.Expertises[i].EmployeeId;
                        et.ExpertiseId = arv.Expertises[i].ExpertiseId;
                        var entity = context.EmployeeExpertises.Add(et);
                        entity.State = EntityState.Added;
                    }

                }
                else
                {
                    if (employeeExpertise != null)
                    {
                        var entity = context.EmployeeExpertises.Remove(employeeExpertise);
                        entity.State = EntityState.Deleted;
                    }
                }
            }

            context.SaveChanges();

            return RedirectToAction("Cv", "Home", new { id = arv.Expertises[0].EmployeeId });
        }

    }
}
