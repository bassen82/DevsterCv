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
    

        public EmployeeViewModel GetEmployee(string employee)
        {
            string path = @"c:\\CvAppen\\Devster\\" + employee + "\\Profile\\data.json";
       string data = File.ReadAllText(path);
            string fullImagePath = Path.Combine(@"c:\\CvAppen\\Devster\\", employee, "\\Profile\\profile.jpg");
            byte[] img = File.ReadAllBytes(fullImagePath);

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
            EVM.Photo = img;
          

            return EVM;
        }
    }
}
