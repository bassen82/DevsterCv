using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class TrainingViewModel
    {
        public int TrainingId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        [Display(Name = "Examen")]
        public bool IsDegree { get; set; }
        public bool Connected { get; set; }
    }
}
