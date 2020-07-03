using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Training
    {
        [Key]
        [Display(Name="Id")]
        public int TrainingId { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }
        [Display(Name = "Examen")]
        public bool IsDegree { get; set; }

        public virtual ICollection<EmployeeTraining> EmployeeTrainings { get; set; }

        public List<TrainingViewModel> GetTrainingView(int employee)
        {
            List<TrainingViewModel> TrainingViewModels = new List<TrainingViewModel>();

            List<Training> targetData = TrainingService.GetByEmployee(employee);
            if (targetData != null)
            {
                foreach (Training target in targetData)
            {
                TrainingViewModel evm = new TrainingViewModel
                {
                    TrainingId = target.TrainingId,
                    Name = target.Name,
                    IsDegree = target.IsDegree
                };

                TrainingViewModels.Add(evm);
            }
            }

            return TrainingViewModels;
        }

        public TrainingViewModel GetDegreeTrainingView(int employeeid)
        {
            TrainingViewModel TrainingViewModel = new TrainingViewModel();

            Training targetData = TrainingService.GetDegreeByEmployee(employeeid);
            if (targetData == null)
            {
                return TrainingViewModel;
            }
            TrainingViewModel.TrainingId = targetData.TrainingId;
            TrainingViewModel.Name = targetData.Name;
            TrainingViewModel.IsDegree = targetData.IsDegree;
            return TrainingViewModel;
        }
    }
}
