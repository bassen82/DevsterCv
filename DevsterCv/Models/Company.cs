using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevsterCv.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id")]
        public int CompanyId { get; set; }
        [Display(Name = "Bolag")]
        public string CompanyName { get; set; }
        [Display(Name = "Bolagsadress")]
        public string CompanyAdress { get; set; }
        [Display(Name = "Bolagspostadress")]
        public string CompanyPostalAdress { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }

    }
}
