using DevsterCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Service
{
    public class TradeService
    {

        public static List<Trade> GetByEmployee(int employeeid)
        {
            using (var context = new SqlLiteContext())
            {
                var query = from e in context.Trades
                            join d in context.EmployeeTrades on e.TradeId equals d.TradeId
                            where d.EmployeeId == employeeid
                            select e;
                List<Trade> list = query.ToList();
                return list;
            }
        }
    }
}
