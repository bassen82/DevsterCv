using DevsterCv.Models;
using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv
{
    [ViewComponent(Name = "Dropdown")]
    public class DropdownViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var model = EmployeeService.GetAll();
            List<EmployeeViewModel> items = new List<EmployeeViewModel>();

            foreach (Employee employee in model)
                         {
                             EmployeeViewModel item = new EmployeeViewModel();
                             item.EmployeeId = employee.EmployeeId;
                             item.EmployeeName = employee.EmployeeName;
                             items.Add(item);
                         }


                return View(items);
        }
}
}