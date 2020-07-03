using DevsterCv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Service
{
    public class ExpertiseService
    {
        public static List<Expertise> GetByEmployee(int employeeid)
        {
            using (var context = new SqlLiteContext())
            {
                var query = from e in context.Expertises
                            join d in context.EmployeeExpertises on e.ExpertiseId equals d.ExpertiseId
                            where d.EmployeeId == employeeid
                            select e;
                List<Expertise> list = query.ToList();
                return list;
            }
        }

    }
}
