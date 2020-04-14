using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DevsterCv.Models
{
    public class Assigment
    {


        public string id { get; set; } = string.Empty;

        public string Uppdrag { get; set; } = string.Empty;
        public string Tid { get; set; } = string.Empty;
        public string Roll { get; set; } = string.Empty;
        public string Beskrivning { get; set; } = string.Empty;
        public string Teknik { get; set; } = string.Empty;

        public List<AssignmentViewModel> GetAllAssignments (string employee)
    {
            string path = @"c:\\CvAppen\\Devster\\" + employee + "\\Uppdrag\\data.json";
            string data = File.ReadAllText(path);

            // Deserialize Data.  
            List<Assigment> targetData = JsonConvert.DeserializeObject<List<Assigment>>(data);

            List<AssignmentViewModel> AssignmentViewModels = new List<AssignmentViewModel>();
            foreach (Assigment target in targetData)
            {
                AssignmentViewModel c = new AssignmentViewModel();
                c.id = target.id;
                c.Beskrivning = target.Beskrivning;
                c.Roll = target.Roll;
                c.Teknik = target.Teknik;
                c.Tid = target.Tid;
                c.Uppdrag = target.Uppdrag;
                AssignmentViewModels.Add(c);

            }

            return AssignmentViewModels;
        }

}
}
