﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DevsterCv.Models;
using DevsterCv.Models.ViewModels;
using Dropbox.Api;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;

namespace DevsterCv
{
    public class DropBoxRepository
    {
        static string token = "IaVslLrvb6AAAAAAAAAAS54uAvcjvKxaezWQyVdGoZ8vbA82Gl2fCNlckFf8-WLb";

        public async Task<string> GetEmployeeDir()
        {
            string path = "/CvAppen/Devster/";
            string dirs = "";
            using (var dbx = new DropboxClient(token))
            {
                var list = await dbx.Files.ListFolderAsync(path);

                foreach (var dir in list.Entries.Where(i => i.IsFolder))
                {
                    dirs = dirs + dir.Name + ",";
                }
                dirs = dirs.TrimEnd(',');
                return dirs;    
            }
        }

        public async Task<string> GetFile(string employee, string part)
        {
            using (var dbx = new DropboxClient(token))
            {
                string folder = "/CvAppen/Devster/" + employee + "/" + part;
                string file = "data.json";

                using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
                {
                    var s = response.GetContentAsStringAsync();
                    s.Wait();
                    var data = s.Result;

                    return data;
                }
            }
        }

        public async Task<byte[]> GetProfilePic(string employee, string part)
        {
            byte[] photo;
            using (var dbx = new DropboxClient(token))
            {
                string folder = "/CvAppen/Devster/" + employee + "/" + part;
                //string folder = "";
                 string file = "profile.webp";
                
                using (var response = await dbx.Files.DownloadAsync(folder + "/" + file))
                {
                    var s = response.GetContentAsByteArrayAsync();
                    s.Wait();
                    photo = s.Result;
                } 
            }
            return photo;
        }
    }
}
