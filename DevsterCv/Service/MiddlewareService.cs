using DevsterCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Service
{
    public class MiddlewareService
    {
        public static List<Middleware> GetByEmployee(int employeeid)
        {
            using (var context = new SqlLiteContext())
            {
                var query = from e in context.Middlewares
                            join d in context.EmployeeMiddlewares on e.MiddlewareId equals d.MiddlewareId
                            where d.EmployeeId == employeeid
                            select e;
                List<Middleware> list = query.ToList();
                return list;
            }
        }
    }
}
