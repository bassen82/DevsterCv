using DevsterCv.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Spec
    {
        public string Expertis { get; set; }
        public string Utbildning { get; set; }
        public string Tekniker { get; set; }
        public string Middleware { get; set; }
        public string Branscher { get; set; }
        public string Intressen { get; set; }

        public SpecViewModel GetSpec(string employee)
        {
            string path = @"c:\\CvAppen\\Devster\\" + employee + "\\Spec\\data.json";
            string data = File.ReadAllText(path);

            // Deserialize Data.  
            Spec target = JsonConvert.DeserializeObject<Spec>(data);

            SpecViewModel SVM = new SpecViewModel();

            

            SVM.Expertis = target.Expertis.Split(',');
            SVM.Utbildning = target.Utbildning.Split(',');
            SVM.teknik = target.Tekniker.Split(',');
            SVM.Middleware = target.Middleware.Split(',');
            SVM.Branscher = target.Branscher.Split(',');
            SVM.Intressen = target.Intressen;

            return SVM;
        }
    }
}
