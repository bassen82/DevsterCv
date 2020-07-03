using DevsterCv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Service
{
    public class TechniqueService
    {
        public static List<Technique> GetByEmployee(int employeeid)
        {
            using (var context = new SqlLiteContext())
            {
                var query = from e in context.Techniques
                            join d in context.EmployeeTechniques on e.TechniqueId equals d.TechniqueId
                            where d.EmployeeId == employeeid
                            select e;
                List<Technique> list = query.ToList();
                return list;
            }
        }

        public static Technique Get(int techid)
        {
            using var context = new SqlLiteContext();
            var tech = context.Techniques.Single(a => a.TechniqueId == techid);

            return tech;
        }

    }
}
