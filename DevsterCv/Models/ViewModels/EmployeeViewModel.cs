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
        public string EmployeeName { get; set; }
        public string ProfilRole { get; set; }
        public string ProfileCompany { get; set; }
        public string ProfileCompanyAdress { get; set; }
        public string ProfileCompanyPostalAdress { get; set; }
        public string EmployeeInfo { get; set; }
        public string EmployeRole { get; set; }
        public string Photopath { get; set; }
    }
}
