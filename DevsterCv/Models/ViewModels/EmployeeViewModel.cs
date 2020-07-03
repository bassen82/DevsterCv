using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Namn")]
        public string EmployeeName { get; set; }
        [Display(Name = "Presentation")]
        public string EmployeeInfo { get; set; }
        public string ShortEmployeeInfo { get { if (EmployeeInfo.Length > 30) { return EmployeeInfo.Substring(0, 30); } else { return EmployeeInfo; } } }

        [Display(Name = "Roll")]
        public string EmployeRole { get; set; }

        [Display(Name = "Intressen")]
        public string Interest { get; set; }
        [Display(Name = "Profilbild")]
        public string ProfilePicture { get; set; }

        [Display(Name = "Profilbild")]
        public IFormFile ProfileImage { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "Telefon")]
        public string Tele { get; set; } = string.Empty;
        [Display(Name = "Mail")]
        public string Mail { get; set; } = string.Empty;
        [Display(Name = "Linkedin")]
        public string Linkedin { get; set; } = string.Empty;


    }
}
