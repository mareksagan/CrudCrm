using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;

namespace CrudCrm.Service
{
    class ArchiveDownloader
    {
        public static bool Logging { get; set; }

        public DateTime Modification = File.GetLastWriteTime(@"C:\test.txt");

        public static WebClient Downloader { get; set; }

        public string Path { get; set; }
        public static string ArchiveExtension { get; set; } = ".zip";

        public static string ExtractPath { get; set; }

        static readonly string DownloadedFile = "downloaded_file";

        private static readonly ArchiveDownloader Instance = new ArchiveDownloader();

        public static ArchiveDownloader GetArchiveDownloader()
        {
            return Instance;
        }


        private ArchiveDownloader()
        {
            Downloader = new WebClient();
            ArchiveExtension = ".zip";
            Logging = false;
        }

        private static void DownloadAndDeleteFile(string uri, string directory, string filepath)
        {
            Downloader?.DownloadFile(new Uri(uri), filepath);

            ZipFile.ExtractToDirectory(filepath, directory);

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
                if (Logging) Console.WriteLine(filepath + " deleted");
            }
        }

        public static void DownloadZipsFromList(string path, List<string> urlList)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var url in urlList)
            {
                DownloadAndDeleteFile(url, path, path + DownloadedFile + ArchiveExtension);
            }

        }
    }
}
