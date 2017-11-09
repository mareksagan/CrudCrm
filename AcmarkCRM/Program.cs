using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;
using CommandLine;

namespace AcmarkCrm.Service
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            var isValid = Parser.Default.ParseArguments(args, options);

            // AcmarkCrmService.exe "https://vpn.acmark.cz:5555/TESTOrg/XRMServices/2011/Organization.svc" "acmark\sagan" rxVotBGzWvS1Vq5d
        //    public DateTime Modification = File.GetLastWriteTime(@"C:\test.txt");

        //    public static string Path { get; set; }
        //public OrganizationServiceProxy ServiceProxy { get; set; }
        //private IOrganizationService Service { get; set; }
        //public static string Extension { get; set; }

        //public static string ExtractPath { get; set; }

            IOrganizationService crmService = null;
            
            try
            {
                 crmService = ConnectToCrm(options.OrganizationUrl, options.UserName, options.Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            var invalidDocumentEntity = CreateNewEntity();

            OrganizationServiceContext crmServiceContext = null;
            
            if (crmService != null)
            {
                AddEntityRecord(crmService, 00000008, 5426, TypeOfInvalidatedDocument.Green, "17.3.2010", invalidDocumentEntity);
                AddEntityRecord(crmService, 00000009, 5826, TypeOfInvalidatedDocument.WithSeries, "17.3.2014", invalidDocumentEntity);

                //run thread at 3:00 each night
                //linq the csv and weed out records older than 1 day and then add them to the database
                // if the csv file modified date is not equal to csvLastChangeDate, then update the file, the database and change the date
                // if its equal, then write "there is no need to update"

                // fresh start as service parameter and if there are no csv files or folders
                // validation (first character not equal to zero)

                crmServiceContext = new OrganizationServiceContext(crmService);
            }

            DeleteDuplicates(crmServiceContext, crmService);

            Console.ReadKey();
        }

    }
}