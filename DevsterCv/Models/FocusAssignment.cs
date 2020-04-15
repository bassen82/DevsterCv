using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DevsterCv.Models
{
    public class FocusAssignment
    {
        public string id { get; set; } = string.Empty;
        public string Uppdrag { get; set; } = string.Empty;
        public string Tid { get; set; } = string.Empty;
        public string Roll { get; set; } = string.Empty;
        public string Beskrivning { get; set; } = string.Empty;
        public string Teknik { get; set; } = string.Empty;

        public List<FocusAssignmentViewModel> GetAllAssignments(string employee)
        {
            string path = @"c:\\CvAppen\\Devster\\" + employee + "\\Uppdragifokus\\data.json";
            string data = File.ReadAllText(path);

            // Deserialize Data.  
            List<FocusAssignment> targetData = JsonConvert.DeserializeObject<List<FocusAssignment>>(data);

            List<FocusAssignmentViewModel> FocusAssignmentViewModels = new List<FocusAssignmentViewModel>();
            foreach (FocusAssignment target in targetData)
            {
                FocusAssignmentViewModel c = new FocusAssignmentViewModel();
                c.id = target.id;
                c.Beskrivning = target.Beskrivning;
                c.Roll = target.Roll;
                c.Teknik = target.Teknik;
                c.Tid = target.Tid;
                c.Uppdrag = target.Uppdrag;
                FocusAssignmentViewModels.Add(c);

            }

            return FocusAssignmentViewModels;
        }

    }
}
