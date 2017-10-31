using System;
using System.IO;
using System.IO.Compression;
using System.Net;
using Microsoft.Xrm.Sdk.WebServiceClient;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk.Discovery;

namespace AcmarkCRM
{
    class AcmarkCrmService
    {
        /* DocumentationClass: Is the class that will be used for explaining the 
        example of automated documentation
        */

        public DateTime Modification = File.GetLastWriteTime(@"C:\test.txt");
        public string path { get; set; }

        static void Main(string[] args)
        {
            DownloadDocs();

            OrganizationServiceClient client = new OrganizationServiceClient();

            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();

            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
        }

        private static void DownloadDocs()
        {
            WebClient webClient = new WebClient();

            string path = AppDomain.CurrentDomain.BaseDirectory + @"\CSV\";
            const string extension = ".zip";

            string extractPath = path + @"\Unzipped\";

            Directory.CreateDirectory(path);
            Directory.CreateDirectory(extractPath);

            webClient.DownloadFile(new Uri("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=0"), path + "new" + extension);
            ZipFile.ExtractToDirectory(path + "new" + extension, extractPath);

            webClient.DownloadFile(new Uri("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=1"), path + "old" + extension);
            ZipFile.ExtractToDirectory(path + "old" + extension, extractPath);

            webClient.DownloadFile(new Uri("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=2"), path + "violet"+ extension);
            ZipFile.ExtractToDirectory(path + "violet" + extension, extractPath);

            webClient.DownloadFile(new Uri("http://aplikace.mvcr.cz/neplatne-doklady/ViewFile.aspx?typ_dokladu=3"), path + "green" + extension);
            ZipFile.ExtractToDirectory(path + "green" + extension, extractPath);


        }
    }
}
