using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class BindEmployeeExpertiseViewModel
    {
        public List<ExpertiseViewModel> Expertises { get; set; }
        public BindEmployeeExpertiseViewModel(List<ExpertiseViewModel> expertiseviewmodel)
        {
            Expertises = expertiseviewmodel;
        }

        public BindEmployeeExpertiseViewModel()
        {
        }


    }
}
