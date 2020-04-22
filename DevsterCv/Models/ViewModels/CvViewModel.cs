using DevsterCv.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class CvViewModel
    {
        public Task<EmployeeViewModel> Employee { get; set; }
        public Task<ContactViewModel> Contact { get; set; }
        public Task<SpecViewModel> Spec { get; set; }
        public Task<List<AssignmentViewModel>> Assigments { get; set; }
        public Task<List<FocusAssignmentViewModel>> FocusAssigments { get; set; }
        public string Photopath { get; set; }


    }
}
