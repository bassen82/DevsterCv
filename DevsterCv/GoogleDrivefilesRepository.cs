using Google.Apis.Auth.OAuth2;
using Google.Apis.Download;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Web;

namespace DevsterCv.Models
{
    public class GoogleDriveFilesRepository
    {
        //defined scope.
        public static string[] Scopes = { DriveService.Scope.Drive };

        //create Drive API service.
        public static DriveService GetService()
        {
            //get Credentials from client_secret.json file 
            UserCredential credential;
            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = "token.json";

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            //create Drive API service.
            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "GoogleDriveRestAPI-v3",
            });
            return service;
        }

        //get all files from Google Drive.
        public static List<GoogleDrivefiles> GetDriveFiles(string employeepath)
        {
            DriveService service = GetService();

            // define parameters of request.
            FilesResource.ListRequest FileListRequest = service.Files.List();

            //listRequest.PageSize = 10;
            //listRequest.PageToken = 10;
            FileListRequest.Fields = "nextPageToken, files(id, name, size, version, createdTime)";

            //get file list.
            IList<Google.Apis.Drive.v3.Data.File> files = FileListRequest.Execute().Files;
            List<GoogleDrivefiles> FileList = new List<GoogleDrivefiles>();

            if (files != null && files.Count > 0)
            {
                foreach (var file in files)
                {
                       GoogleDrivefiles File = new GoogleDrivefiles
                      {
                          Id = file.Id,
                          Name = file.Name,
                          Size = file.Size,
                          Version = file.Version,
                          Createdtime = file.CreatedTime
                     };
                     FileList.Add(File);
                   // string path = employeepath + file.Name;
                   // DownloadFile(service, file, path);
                }
            }
           return FileList;
        }


        private static void DownloadFile(Google.Apis.Drive.v3.DriveService service, Google.Apis.Drive.v3.Data.File file, string saveTo)
        {

            var request = service.Files.Get(file.Id);
            var stream = new System.IO.MemoryStream();

            // Add a handler which will be notified on progress changes.
            // It will notify on each chunk download and when the
            // download is completed or failed.
            request.MediaDownloader.ProgressChanged += (Google.Apis.Download.IDownloadProgress progress) =>
            {
                switch (progress.Status)
                {
                    case Google.Apis.Download.DownloadStatus.Downloading:
                        {
                            Console.WriteLine(progress.BytesDownloaded);
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Completed:
                        {
                            Console.WriteLine("Download complete.");
                            SaveStream(stream, saveTo);
                            break;
                        }
                    case Google.Apis.Download.DownloadStatus.Failed:
                        {
                            Console.WriteLine("Download failed.");
                            break;
                        }
                }
            };
            request.Download(stream);

        }

        // file save to server path
        private static void SaveStream(MemoryStream stream, string FilePath)
    {
        using (System.IO.FileStream file = new FileStream(FilePath, FileMode.Create, FileAccess.ReadWrite))
        {
            stream.WriteTo(file);
        }
    }


}
}
