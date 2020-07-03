using DevsterCv.Models;
using Dropbox.Api.TeamLog;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Service
{
    public class EmployeeService
    {

        public static void Add(Employee employee)
        {
            using (var context = new SqlLiteContext())
            {
                var entity = context.Employees.Add(employee);
                entity.State = EntityState.Added;

                context.SaveChanges();
            }
        }

        public static void Update(Employee employee)
        {
            using var context = new SqlLiteContext();
                var entity = context.Employees.Update(employee);
 
            entity.State = EntityState.Modified;

                context.SaveChanges();
        }

        public static Employee Get(int employeeid)
        {
            using var context = new SqlLiteContext();
            var employee = context.Employees.SingleOrDefault(a => a.EmployeeId == employeeid);

            return employee;
        }

        public static List<Employee> GetAll()
        {
            
            List<Employee> data = new List<Employee>();

            using var context = new SqlLiteContext();
            if (context.Employees.Any())
            {
                data = context.Employees.ToList();

            }
            return data;
        }

    }
}
