using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Expertise
    {
        [Display(Name = "Id")]
        public int ExpertiseId { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }

        public virtual ICollection<EmployeeExpertise> EmployeeExpertises { get; set; }


        public List<ExpertiseViewModel> GetExpertiseView(int employee)
        {
            List<ExpertiseViewModel> ExpertiseViewModels = new List<ExpertiseViewModel>();

            List<Expertise> targetData = ExpertiseService.GetByEmployee(employee);
            if (targetData != null)
            {
            foreach (Expertise target in targetData)
            {
                ExpertiseViewModel evm = new ExpertiseViewModel
                {
                    ExpertiseId = target.ExpertiseId,
                    Name = target.Name
                };

                ExpertiseViewModels.Add(evm);
            }
            }

            return ExpertiseViewModels;
        }
    }
}
