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
    public class EmployeeTechniquesController : Controller
    {
        public ActionResult Admin(int employeeid)
        {
            List<TechniqueViewModel> Techniqueviewmodellist = new List<TechniqueViewModel>();
            List<Technique> employeetechlist = TechniqueService.GetByEmployee(employeeid);
            using var context = new SqlLiteContext();
            List<Technique> techlist = context.Techniques.ToList();

            foreach (Technique t in techlist)
            {
                TechniqueViewModel tvm = new TechniqueViewModel();
                tvm.TechniqueId = t.TechniqueId;
                tvm.EmployeeId = employeeid;
                tvm.Name = t.Name;
                tvm.Connected = false;
                foreach (Technique te in employeetechlist)
                {
                    if (t.TechniqueId == te.TechniqueId)
                    {
                        tvm.Connected = true;
                    }
                }
                Techniqueviewmodellist.Add(tvm);
            }
            var sortedlist = Techniqueviewmodellist.OrderBy(foo => foo.Name).ToList();
            var arv = new BindEmployeeTechniqueViewModel(sortedlist);
            return View(arv);
        }


        public ActionResult Add(BindEmployeeTechniqueViewModel arv)
        {
            SqlLiteContext context = new SqlLiteContext();
            for (int i = 0; i < arv.Techniques.Count(); i++)
            {
                var employeeTechnique = context.EmployeeTechniques.Where(a => a.EmployeeId == arv.Techniques[i].EmployeeId && a.TechniqueId == arv.Techniques[i].TechniqueId).FirstOrDefault();

                if (arv.Techniques[i].Connected)
                {
                    if (employeeTechnique == null)
                    {
                        var et = new EmployeeTechnique();
                        et.EmployeeId = arv.Techniques[i].EmployeeId;
                        et.TechniqueId = arv.Techniques[i].TechniqueId;
                        var entity = context.EmployeeTechniques.Add(et);
                        entity.State = EntityState.Added;
                    } 
                  
                }
                else
                {
                   if (employeeTechnique != null) { 
                    var entity = context.EmployeeTechniques.Remove(employeeTechnique);
                    entity.State = EntityState.Deleted;
                    }
                }
            }

            context.SaveChanges();

            return RedirectToAction("Cv", "Home", new { id = arv.Techniques[0].EmployeeId });
        }

    }
}
