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
    public class EmployeeTrainingsController : Controller
    {
        public ActionResult Admin(int employeeid)
        {
            List<TrainingViewModel> Trainingviewmodellist = new List<TrainingViewModel>();
           
            List<Training> employeetraininglist = TrainingService.GetAllDegreeByEmployee(employeeid);
            using var context = new SqlLiteContext();
            List<Training> traininglist = context.Trainings.Where(a => a.IsDegree == true).ToList();

            foreach (Training t in traininglist)
            {
                TrainingViewModel tvm = new TrainingViewModel();
                tvm.TrainingId = t.TrainingId;
                tvm.EmployeeId = employeeid;
                tvm.Name = t.Name;
                tvm.IsDegree = t.IsDegree;
                foreach (Training te in employeetraininglist)
                {
                    if (t.TrainingId == te.TrainingId)
                    {
                        tvm.Connected = true;
                    }
                }
                Trainingviewmodellist.Add(tvm);
            }
            var arv = new BindEmployeeTrainingViewModel(Trainingviewmodellist);
            return View(arv);
        }

        public ActionResult AdminCourse(int employeeid)
        {
            List<TrainingViewModel> Trainingviewmodellist = new List<TrainingViewModel>();

            List<Training> employeetraininglist = TrainingService.GetByEmployee(employeeid);
            using var context = new SqlLiteContext();
            List<Training> traininglist = context.Trainings.Where(a => a.IsDegree == false).ToList();

            foreach (Training t in traininglist)
            {
                TrainingViewModel tvm = new TrainingViewModel();
                tvm.TrainingId = t.TrainingId;
                tvm.EmployeeId = employeeid;
                tvm.Name = t.Name;
                tvm.IsDegree = t.IsDegree;
                foreach (Training te in employeetraininglist)
                {
                    if (t.TrainingId == te.TrainingId)
                    {
                        tvm.Connected = true;
                    }
                }
                Trainingviewmodellist.Add(tvm);
            }
            var sortedlist = Trainingviewmodellist.OrderBy(foo => foo.Name).ToList();
            var arv = new BindEmployeeTrainingViewModel(sortedlist);
            return View(arv);
        }


        public ActionResult Add(BindEmployeeTrainingViewModel arv)
        {
            SqlLiteContext context = new SqlLiteContext();
            for (int i = 0; i < arv.Trainings.Count(); i++)
            {
                var employeeTraining = context.EmployeeTrainings.Where(a => a.EmployeeId == arv.Trainings[i].EmployeeId && a.TrainingId == arv.Trainings[i].TrainingId).FirstOrDefault();

                if (arv.Trainings[i].Connected)
                {
                    if (employeeTraining == null)
                    {
                        var et = new EmployeeTraining();
                        et.EmployeeId = arv.Trainings[i].EmployeeId;
                        et.TrainingId = arv.Trainings[i].TrainingId;
                        var entity = context.EmployeeTrainings.Add(et);
                        entity.State = EntityState.Added;
                    }
                }
                else
                {
                    if (employeeTraining != null)
                    {
                        var entity = context.EmployeeTrainings.Remove(employeeTraining);
                        entity.State = EntityState.Deleted;
                    }
                }
            }
            context.SaveChanges();
            return RedirectToAction("Cv", "Home", new { id = arv.Trainings[0].EmployeeId });
        }

    }
}
