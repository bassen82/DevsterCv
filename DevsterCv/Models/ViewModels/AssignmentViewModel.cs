using DevsterCv.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class AssignmentViewModel 
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }
        public int SelectedEmployeeId { get; set; }

        public IEnumerable<SelectItem> Employees { get; set; }
        public string Uppdrag { get; set; } = string.Empty;
        public string Tid { get; set; } = string.Empty;
        public string Roll { get; set; } = string.Empty;
        public string Beskrivning { get; set; } = string.Empty;
        public string ShortBeskrivning { get { if (Beskrivning.Length > 30) { return Beskrivning.Substring(0, 30); } else { return Beskrivning; } } }
        public string Teknik { get; set; } = string.Empty;
        public bool Focus { get; set; }
    }
}
