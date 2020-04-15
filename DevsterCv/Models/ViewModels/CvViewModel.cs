using DevsterCv.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class CvViewModel
    {
        public EmployeeViewModel Employee { get; set; }
        public ContactViewModel Contact { get; set; }
        public SpecViewModel Spec { get; set; }
        public List<AssignmentViewModel> Assigments { get; set; }
        public List<FocusAssignmentViewModel> FocusAssigments { get; set; }
        public string Photopath { get; set; }


    }
}
