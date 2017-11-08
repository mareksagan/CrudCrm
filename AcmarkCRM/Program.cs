using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace AcmarkCrm.Service
{
    partial class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService crmService = null;
            
            try
            {
                 crmService = ConnectToCrm(args[0], args[1], args[2]);
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

                //run thread at 3:00 each night
                //linq the csv and weed out records older than 1 day and then add them to the database
                // if the csv file modified date is not equal to csvLastChangeDate, then update the file, the database and change the date

                crmServiceContext = new OrganizationServiceContext(crmService);
            }

            DeleteDuplicates(crmServiceContext);

            Console.ReadKey();
        }

    }
}