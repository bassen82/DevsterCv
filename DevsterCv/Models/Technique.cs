using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Technique
    {
        [Key]
        [Display(Name = "Id")]
        public int TechniqueId { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }

        public virtual ICollection<EmployeeTechnique> EmployeeTechniques { get; set; }


        public List<TechniqueViewModel> GetTechniqueView(int employee)
        {
            List<TechniqueViewModel> TechniqueViewModels = new List<TechniqueViewModel>();

            List<Technique> targetData = TechniqueService.GetByEmployee(employee);

            if (targetData == null)
            {
                return TechniqueViewModels;
            }
            foreach (Technique target in targetData)
            {
                TechniqueViewModel evm = new TechniqueViewModel
                {
                    TechniqueId = target.TechniqueId,
                    Name = target.Name
                };

                TechniqueViewModels.Add(evm);
            }
            return TechniqueViewModels;
        }
    }
}
