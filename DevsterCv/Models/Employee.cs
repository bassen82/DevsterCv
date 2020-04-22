using DevsterCv.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string ProfilRole { get; set; }
        public string ProfileCompany { get; set; }
        public string ProfileCompanyAdress { get; set; }
        public string ProfileCompanyPostalAdress { get; set; }    
        public string EmployeeInfo { get; set; }
        public string EmployeRole { get; set; }
    

        public async Task<EmployeeViewModel> GetEmployeeAsync(string employee, string part)
        {
            DropBoxRepository dr = new DropBoxRepository();
            string data = await dr.GetFile(employee, part);
                             
            // Deserialize Data.  
            Employee target = JsonConvert.DeserializeObject<Employee>(data);

            EmployeeViewModel EVM = new EmployeeViewModel();

            EVM.ProfilRole = target.ProfilRole;
            EVM.ProfileCompany = target.ProfileCompany;
            EVM.ProfileCompanyAdress = target.ProfileCompanyAdress;
            EVM.ProfileCompanyPostalAdress = target.ProfileCompanyPostalAdress;
            EVM.EmployeeName = target.EmployeeName;
            EVM.EmployeeInfo = target.EmployeeInfo;
            EVM.EmployeRole = target.EmployeRole;
            EVM.Photo = await dr.GetProfilePic(employee, part);

            return EVM;
        }


    }
}
