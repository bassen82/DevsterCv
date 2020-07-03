using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models.ViewModels
{
    public class SpecViewModel
    {
        public int Id { get; set; }
        public string[] Expertis { get; set; }
        public string Utbildning { get; set; }
        public string[] Kurser { get; set; }
        public string[] teknik { get; set; }
        public string[] Middleware { get; set; }
        public string[] Branscher { get; set; }
        public string Intressen { get; set; }
    }
}
