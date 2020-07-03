using DevsterCv.Models.ViewModels;
using DevsterCv.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Middleware
    {
        [Display(Name = "Id")]
        public int MiddlewareId { get; set; }
        [Display(Name = "Namn")]
        public string Name { get; set; }

        public virtual ICollection<EmployeeMiddleware> EmployeeMiddleswares { get; set; }


        public List<MiddlewareViewModel> GetMiddlewareView(int employee)
        {
            List<MiddlewareViewModel> MiddlewareViewModels = new List<MiddlewareViewModel>();

            List<Middleware> targetData = MiddlewareService.GetByEmployee(employee);

            if (targetData == null)
            {
                return MiddlewareViewModels;
            }
            foreach (Middleware target in targetData)
            {
                MiddlewareViewModel evm = new MiddlewareViewModel
                {
                    MiddlewareId = target.MiddlewareId,
                    Name = target.Name
                };

                MiddlewareViewModels.Add(evm);
            }
            return MiddlewareViewModels;
        }
    }
}
