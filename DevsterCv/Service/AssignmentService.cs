using DevsterCv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Service
{
    public class AssignmentService
    {
        public static void Add(Assigment assignment)
        {
            using (var context = new SqlLiteContext())
            {
                var entity = context.Assigments.Add(assignment);
                entity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public static void Update(Assigment assigment)
        {
            using var context = new SqlLiteContext();
            var entity = context.Assigments.Update(assigment);

            entity.State = EntityState.Modified;

            context.SaveChanges();
        }

        public static List<Assigment> GetAllNonFocus(int employeeid)
        {
            using var context = new SqlLiteContext();
            var assignments = context.Assigments.Where(a => a.Employeeid == employeeid && a.Focus == false).ToList();

            return assignments;
        }

        public static List<Assigment> GetAll(int employeeid)
        {
            using var context = new SqlLiteContext();
            var assignments = context.Assigments.Where(a => a.Employeeid == employeeid).ToList();

            return assignments;
        }

        public static List<Assigment> GetEvery()
        {
            using var context = new SqlLiteContext();
            var assignments = context.Assigments.ToList();

            return assignments;
        }

        public static List<Assigment> GetAllFocus(int employeeid)
        {
            using var context = new SqlLiteContext();
            var assignments = context.Assigments.Where(a => a.Employeeid == employeeid && a.Focus == true).ToList();

            return assignments;
        }

        public static Assigment Get(int id)
        {
            using var context = new SqlLiteContext();
            var assignment = context.Assigments.Find(id);

            return assignment;
        }

        public static void Delete(Assigment assigment)
        {
            using var context = new SqlLiteContext();
            var entity = context.Assigments.Remove(assigment);

            entity.State = EntityState.Deleted;

            context.SaveChanges();
        }


    }
}
