using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class BindEmployeeTrainingViewModel
    {
        public List<TrainingViewModel> Trainings { get; set; }
        public BindEmployeeTrainingViewModel(List<TrainingViewModel> trainingviewmodel)
        {
            Trainings = trainingviewmodel;
        }

        public BindEmployeeTrainingViewModel()
        {
        }


    }
}
