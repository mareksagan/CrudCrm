using System;
using System.IO;
using System.Net;

namespace AcmarkCrm.Service
{
    class CsvManipulator
    {
        public bool DownloadCsvFiles()
        {
            WebClient webClient = new WebClient();

            //Path = AppDomain.CurrentDomain.BaseDirectory + @"\CSV\";
            //this.Extension = ".zip";
            //ExtractPath = Path + @"\Unzipped\";

            //Directory.CreateDirectory(Path);
            //Directory.CreateDirectory(ExtractPath);

            //webClient.DownloadFile(new Uri("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=0"), Path + "new" + Extension);

            //try { ZipFile.ExtractToDirectory(Path + "new" + Extension, ExtractPath); } catch (Exception e) { }


            //webClient.DownloadFile(new Uri("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=1"), Path + "old" + Extension);
            //ZipFile.ExtractToDirectory(Path + "old" + Extension, ExtractPath);

            //webClient.DownloadFile(new Uri("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=2"), Path + "violet" + Extension);
            //ZipFile.ExtractToDirectory(Path + "violet" + Extension, ExtractPath);

            //webClient.DownloadFile(new Uri("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=3"), Path + "green" + Extension);
            //ZipFile.ExtractToDirectory(Path + "green" + Extension, ExtractPath);
            return true;

        }

//        class AcmarkCrm
//        {
//            /* DocumentationClass: Is the class that will be used for explaining the 
//            example of automated documentation
//            */

//            public DateTime Modification = File.GetLastWriteTime(@"C:\test.txt");

//            public static string Path { get; set; }
//            public OrganizationServiceProxy ServiceProxy { get; set; }
//            private IOrganizationService Service { get; set; }
//            public static string Extension { get; set; }

//            public static string ExtractPath { get; set; }

//            static void Main(string[] args)
//            {

//                DownloadDocs();
//private static void DownloadDocs()
//            {
//                throw new NotImplementedException();
//            }



//            // Define the IDs needed for this sample.
//            private Guid _accountId;

//            //_service = (IOrganizationService)_serviceProxy;

//            //ServicePointManager.ServerCertificateValidationCallback = (s, Microsoft.Xrm.Sdk.Deployment.Certificate, Claim, SslPolicyErrors) => true;
//        }

//        private void DownloadDocs()
//        {
//            


//        }
//    }
}
}
