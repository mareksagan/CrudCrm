using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using LINQtoCSV;

namespace AcmarkCrm.Service
{
    sealed class CsvReader
    {
        //singleton
        //run thread at 3:00 each night
        //linq the csv and weed out records older than 1 day and then add them to the database
        // if the csv file modified date is not equal to csvLastChangeDate, then update the file, the database and change the date
        // if its equal, then write "there is no need to update"

        // fresh start as service parameter and if there are no csv files or folders
        // validation (first character not equal to zero)

        //use Verbose with it
        public bool Logging { get; set; }

        private string _downloadedFile = "downloaded_file";

        private void DownloadAndDeleteFile(string uri, string directory, string filepath)
        {
            Downloader.DownloadFile(new Uri(uri), filepath);
            ZipFile.ExtractToDirectory(filepath, directory);
            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
        }

        public void DownloadBaseCsvFiles()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            DownloadAndDeleteFile("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=0", Path, Path + _downloadedFile + ArchiveExtension);
            DownloadAndDeleteFile("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=1", Path, Path + _downloadedFile + ArchiveExtension);
            DownloadAndDeleteFile("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=2", Path, Path + _downloadedFile + ArchiveExtension);
            DownloadAndDeleteFile("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=3", Path, Path + _downloadedFile + ArchiveExtension);
        }

        public void DownloadUpdateCsvFiles()
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }

            DownloadAndDeleteFile("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=0&rozdil=1", Path, Path + _downloadedFile + ArchiveExtension);
            DownloadAndDeleteFile("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=1&rozdil=1", Path, Path + _downloadedFile + ArchiveExtension);
            DownloadAndDeleteFile("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=2&rozdil=1", Path, Path + _downloadedFile + ArchiveExtension);
            DownloadAndDeleteFile("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=3&rozdil=1", Path, Path + _downloadedFile + ArchiveExtension);
        }

        public CsvReader()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory + @"\csv\";
            Downloader = new WebClient();
            ArchiveExtension = ".zip";
            InputFileContext = new CsvContext();
            InputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = false,
                EnforceCsvColumnAttribute = true
            };
            InputFileExtension = ".csv";

        }

        public static CsvFileDescription InputFileDescription { get; set; }

        public static CsvContext InputFileContext { get; set; }

        public DateTime Modification = File.GetLastWriteTime(@"C:\test.txt");

        public WebClient Downloader { get; set; }

        public string Path { get; set; }
        public static string ArchiveExtension { get; set; }
        public string InputFileExtension { get; set; }

        public static string ExtractPath { get; set; }

        public string DownloadedFile
        {
            get
            {
                return _downloadedFile;
            }

            set
            {
                _downloadedFile = value;
            }
        }

        public IEnumerable<InvalidatedDocumentWithoutSeries> ReadCsv(string fileName)
        {
            IEnumerable<InvalidatedDocumentWithoutSeries> products =
    InputFileContext.Read<InvalidatedDocumentWithoutSeries>(Path + fileName + InputFileExtension, InputFileDescription);
            return products;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetPath()
        {
            return Path;
        }
    }
}
