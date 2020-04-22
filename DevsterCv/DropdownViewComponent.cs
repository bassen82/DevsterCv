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




        public async Task<IViewComponentResult> InvokeAsync(
        int maxPriority, bool isDone)
        {
          //  string[] dirs = Directory.GetDirectories(@"C:\CvAppen\Devster");
           List<string> employees = new List<string>();

            DropBoxRepository dr = new DropBoxRepository();
            string data = await dr.GetEmployeeDir();
            string[] dirs = data.Split(',');
            foreach (string dir in dirs)
            {
                String name = dir;
                employees.Add(name);
            }
            employees.Sort();
            var query = employees.Select(c => new { c });
            ViewBag.c = new SelectList(query.AsEnumerable(), "c", "c", 3);

            return View();
        }

    }
}