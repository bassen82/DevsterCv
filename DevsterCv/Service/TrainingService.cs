using DevsterCv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Service
{
    public class TrainingService
    {

        public static List<Training> GetByEmployee(int employeeid)
        {
            using (var context = new SqlLiteContext())
            {
                var query = from e in context.Trainings
                            join d in context.EmployeeTrainings on e.TrainingId equals d.TrainingId
                            where d.EmployeeId == employeeid && e.IsDegree == false
                            select e;
                List<Training> list = query.ToList();
                return list;
            }
        }

        public static List<Training> GetAllDegreeByEmployee(int employeeid)
        {
            using (var context = new SqlLiteContext())
            {
                List<Training> degree = (from e in context.Trainings
                                   join d in context.EmployeeTrainings on e.TrainingId equals d.TrainingId
                                   where d.EmployeeId == employeeid && e.IsDegree == true
                                   select e).ToList();

                return degree;
            }
        }

        public static Training GetDegreeByEmployee(int employeeid)
        {
            using (var context = new SqlLiteContext())
            {
                Training degree = (from e in context.Trainings
                                   join d in context.EmployeeTrainings on e.TrainingId equals d.TrainingId
                                   where d.EmployeeId == employeeid && e.IsDegree == true
                                   select e).SingleOrDefault();

                return degree;
            }
        }

        public static void UpdateDegreeByEmployee(Training training)
        {
            using var context = new SqlLiteContext();
            var entity = context.Trainings.Update(training);

            entity.State = EntityState.Modified;

            context.SaveChanges();
        }

        public static void UpdateCourseByEmployee(Training training)
        {
            using var context = new SqlLiteContext();
            var entity = context.Trainings.Update(training);

            entity.State = EntityState.Modified;

            context.SaveChanges();
        }

        public static void Add(Training training)
        {
            using (var context = new SqlLiteContext())
            {
                var entity = context.Trainings.Add(training);
                entity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

    }
}
