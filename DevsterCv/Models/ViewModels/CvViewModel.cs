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
        public List<AssignmentViewModel> Assigments { get; set; }

        public List<FocusAssignmentViewModel> FocusAssigments { get; set; }
        public List<ExpertiseViewModel> Expertises { get; set; }
        public List<MiddlewareViewModel> Middlewares { get; set; }
        public List<TechniqueViewModel> Techniques { get; set; }
        public TrainingViewModel DegreeTraining { get; set; }
        public List<TrainingViewModel> Trainings { get; set; }
        public List<TradeViewModel> Trades { get; set; }

        public string Photopath { get; set; }


    }
}
