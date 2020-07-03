using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class BindEmployeeTechniqueViewModel
    {
        public List<TechniqueViewModel> Techniques { get; set; }
        public BindEmployeeTechniqueViewModel(List<TechniqueViewModel> techniqueviewmodel)
        {
            Techniques = techniqueviewmodel;
        }

        public BindEmployeeTechniqueViewModel()
        {
        }


    }
}
