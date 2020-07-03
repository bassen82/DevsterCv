using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class EmployeeExpertise
    {
        [Key]
        [Column(Order = 1)]
        public int EmployeeId { get; set; }
        [Column(Order = 2)]
        public int ExpertiseId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Expertise Expertise { get; set; }
    }
}
