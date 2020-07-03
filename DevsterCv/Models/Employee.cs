using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevsterCv.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        public string CompanyId { get; set; }
        [Display(Name = "Namn")]
        public string EmployeeName { get; set; }
        [Display(Name = "Presentation")]
        public string EmployeeInfo { get; set; }
        [Display(Name = "Roll")]
        public string EmployeRole { get; set; }
        [Display(Name = "Intressen")]
        public string Interest { get; set; }
        [Display(Name = "Profilbild")]
        public string ProfilePicture { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "Telefon")]
        public string Tele { get; set; } = string.Empty;
        [Display(Name = "Mail")]
        public string Mail { get; set; } = string.Empty;
        [Display(Name = "Linkedin")]
        public string Linkedin { get; set; } = string.Empty;
        public virtual ICollection<EmployeeTechnique> EmployeeTechniques { get; set; }
        public virtual ICollection<EmployeeMiddleware> EmployeeMiddleswares { get; set; }
        public virtual ICollection<EmployeeTraining> EmployeeTrainings { get; set; }
        public virtual ICollection<EmployeeTrade> EmployeeTrades { get; set; }
        public virtual ICollection<EmployeeExpertise> EmployeeExpertises { get; set; }



        public EmployeeViewModel GetEmployeeView(Employee emp)
        {
            EmployeeViewModel EVM = new EmployeeViewModel();
            
            EVM.EmployeeId = emp.EmployeeId;
            EVM.EmployeeName = emp.EmployeeName;
            EVM.EmployeeInfo = emp.EmployeeInfo;
            EVM.EmployeRole = emp.EmployeRole;
            EVM.Interest = emp.Interest;
            EVM.ProfilePicture = emp.ProfilePicture;
            EVM.City = emp.City;
            EVM.Mail = emp.Mail;
            EVM.Linkedin = emp.Linkedin;
            EVM.Tele = emp.Tele;

            return EVM;
        }

        public List<EmployeeViewModel> GetEmployeesView(List <Employee> emplist)
        {
            List<EmployeeViewModel> EmployeeViewModels = new List<EmployeeViewModel>();
            
            foreach (Employee e in emplist)
            {
                EmployeeViewModel EVM = new EmployeeViewModel();
                EVM.EmployeeId = e.EmployeeId;
                EVM.EmployeeName = e.EmployeeName;
                EVM.EmployeeInfo = e.EmployeeInfo;
                EVM.EmployeRole = e.EmployeRole;
                EVM.Interest = e.Interest;
                EVM.City = e.City;
                EVM.Mail = e.Mail;
                EVM.Linkedin = e.Linkedin;
                EVM.Tele = e.Tele;
                EVM.ProfilePicture = e.ProfilePicture;
                EmployeeViewModels.Add(EVM);

            }

            return EmployeeViewModels;
        }


    }
}
