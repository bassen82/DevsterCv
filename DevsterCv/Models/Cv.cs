using DevsterCv.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Cv
    {
        public Employee Employee { get; set; }
        public List<Assigment> Assigments { get; set; }

        public List<Assigment> FocusAssigments { get; set; }
        public List<Expertise> Expertises { get; set; }
        public List<Middleware> Middlewares { get; set; }
        public List<Technique> Techniques { get; set; }
        public Training DegreeTraining { get; set; }
        public List<Training> Trainings { get; set; }
        public List<Trade> Trades { get; set; }



    }
}
