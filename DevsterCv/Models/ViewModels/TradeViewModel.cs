using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class TradeViewModel
    {
        public int TradeId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public bool Connected { get; set; }

    }
}
