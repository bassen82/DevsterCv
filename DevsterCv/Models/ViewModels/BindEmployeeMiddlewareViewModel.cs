using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class BindEmployeeMiddlewareViewModel
    {
        public List<MiddlewareViewModel> Middlewares { get; set; }
        public BindEmployeeMiddlewareViewModel(List<MiddlewareViewModel> middlewareviewmodel)
        {
            Middlewares = middlewareviewmodel;
        }

        public BindEmployeeMiddlewareViewModel()
        {
        }


    }
}
