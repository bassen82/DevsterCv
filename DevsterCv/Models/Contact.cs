using DevsterCv.Models.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DevsterCv.Models
{
    public class Contact
    {
        public string Tele { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Mail { get; set; } = string.Empty;
        public string Linkedin { get; set; } = string.Empty;
  

    public async Task<ContactViewModel> GetContactAsync(string employee, string part)
    {
            DropBoxRepository d = new DropBoxRepository();
            string data = await d.GetFile(employee, part);

            // Deserialize Data.  
            Contact target = JsonConvert.DeserializeObject<Contact>(data);

            ContactViewModel CVM = new ContactViewModel();
            CVM.Tele = target.Tele;
            CVM.City = target.City;
            CVM.Mail = target.Mail;
            CVM.Linkedin = target.Linkedin;

        return CVM;
    }
    }
}
