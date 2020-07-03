using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class SearchViewModel
    {
        [Display(Name = "Typ")]
        public string Entity { get; set; }
        [Display(Name = "Sökparameter")]
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        [Display(Name = "Anställd")]
        public string EmployeeName { get; set; }
        public bool IsEmpty { get; set; }

    }
}
