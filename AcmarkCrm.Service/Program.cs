using System;
using CommandLine;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;

namespace AcmarkCrm.Service
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            try
            {
                Parser.Default.ParseArguments(args, options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (options.Help)
            {
                Console.WriteLine(CommandLine.Text.HelpText.AutoBuild(options));
            }
            else if (options.Manual)
            {
                Console.WriteLine("Press [U] to update the CRM entity records");
                Console.ReadKey();

            }
            else if (options.Credits)
            {
                Console.WriteLine("1. Approaches to CRM environments\r\n" +
                                  "As a login and password for accessing CRM, use an Active Directory account " +
                                  "to scroll by email.\r\n\r\nLogin: acmark\\sagan\r\nPassword: rxVotBGzWvS1Vq5d\r\n" +
                                  "\r\nCRM address: https://vpn.acmark.cz:5555/TESTOrg/main.aspx\r\nCRM discovery service:" +
                                  " https://vpn.acmark.cz:5555/XRMServices/2011/Discovery.svc\r\nCRM web service: " +
                                  "https://vpn.acmark.cz:5555/TESTOrg/XRMServices/2011/Organization.svc\r\n\r\nWeb service" +
                                  " – WSDL:\r\nhttps://vpn.acmark.cz:5555/TESTOrg/XRMServices/2011/Organization.svc?wsdl\r\n" +
                                  "CRM 2011 SDK: http://www.microsoft.com/en-us/download/details.aspx?id=24004#\r\n\r\nSince " +
                                  "the SSL certificate is issued by our local local authority certification authority\r\n" +
                                  "server, there may be problems with connecting to CRM, or to the web service. " +
                                  "This is the most common\r\nis the exception \"Metadata contains a reference that " +
                                  "can not be resolved\". In this case\r\nuse the procedure described here, " +
                                  "for example:\r\nhttp://rajeevpentyala.wordpress.com/2012/11/07/metadata-contains-a-reference-that-cannot-be-resolved-issue-with-crm-2011-with-ssl-binding/\r\n\r\n" +
                                  "2. Specify the task\r\nThe database of invalid databases is available on the website of " +
                                  "the Ministry of Interior (http://aplikace.mvcr.cz/neplatne-doklady/)\r\ndocuments in zipped CSV file format that need to be processed and imported into CRM.\r\nThe database consists of several separate files - new OP, old OP, violet CP, green CP, arms\r\ncertificates (these are not of interest to us).\r\nAfter logging in to CRM, you\'ll find the \"List\" entity in the left-hand menu\r\ninvalid documents \". This entity will be imported\r\nindividual records from files downloaded from the MC Web site. Closer\r\nthe entity description is given below. You can check through this interface\r\nrecords automatically imported by the application, modify them and\r\nor delete it.\r\nThe console application will run regularly every day at night. They will be running every time they run\r\nimport new records and update existing ones. Only document types will be imported\r\nlisted below in the \"Document Type\" enumeration.\r\nIn the project, when working with CRM, use the late bound classes (http://msdn.microsoft.com/en-us/library/gg309272.aspx).\r\n\r\n3. Entity description\r\nEntity name: acm_listinvaliddocument\r\nPrimary key: acm_listinvaliddocumentid\r\n\r\nAttributes:\r\nName Scheme name Type\r\nDocument number acm_documentnumber string (10)\r\nSeries acm_batch string (4)\r\nDocument type acm_documenttype picklist\r\nDate of invalidation acm_invalidationdate DateTime\r\n\r\n\"Document Type\" Dial:\r\nLabel Value\r\nOP bez série  805210000\r\nOP se sérií  805210001\r\nCestovní pas - fialový  805210002\r\nCestovní pas - zelený  805210003\r\n\r\n// create enum -> bezserie serie fialovy zeleny\r\n\r\n4. Method of surrender\r\nDeliver the completed solution as a complete project for Visual Studio 2012/2013/2015/20176\r\nin the ZIP archive. Please include a brief description of how to install / set up the application and how to proceed\r\nthe application triggers what input parameters and what outputs outputs.\r\nIf the application uses some third-party libraries, other than the referenced SDK, add them\r\nalso to the archive with the project.");
            }
            else
            {

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

                if (crmService != null)
                {

                    //AddEntityRecord(crmService, "00000008", "5426", TypeOfInvalidatedDocument.Green, "17.3.2010",
                    //    invalidDocumentEntity);
                    //AddEntityRecord(crmService, "00000009", "5826", TypeOfInvalidatedDocument.WithSeries, "17.3.2014",
                    //    invalidDocumentEntity);

                    CsvReader csvrdr = new CsvReader();

                    csvrdr.DownloadBaseCsvFiles();

                    var collection = csvrdr.ReadCsv("op_vse");

                    //new ExecuteMultipleRequest

                    //new CreateRequest

                    foreach (var item in collection)
                    {
                        AddEntityRecord(crmService, item.DocumentId, null, TypeOfInvalidatedDocument.WithoutSeries, item.InvalidationDate,
                            invalidDocumentEntity);
                    }

                }

                DeleteAllEntityRecords(crmService);

                Console.ReadKey();
            }
        }
    }
}