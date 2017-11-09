using System;
using System.Linq;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace AcmarkCrm.Service
{
    partial class Program
    {
        private static void DeleteDuplicates(OrganizationServiceContext crmServiceContext, IOrganizationService crmService)
        {
            // Query to weed out duplicates (leave the newest/highest id) after adding new ones

            var queryDuplicates = from r in crmServiceContext.CreateQuery("acm_listinvaliddocument")
                where ((string)r["acm_documentnumber"]).StartsWith("0")
                select new
                {
                    DocumentNumber = r["acm_documentnumber"],
                    InvalidationDate = r["acm_invalidationdate"],
                    Batch = r["acm_batch"],
                    Guid = r["acm_listinvaliddocumentid"]
                };

            foreach (var duplicate in queryDuplicates)
            {
                Console.WriteLine("DELETED RECORD - Document number: " + duplicate.DocumentNumber.ToString() + " Batch number: " + duplicate.Batch + " Invalidation date: " + duplicate.InvalidationDate.ToString()+ " Guid: "+ duplicate.Guid.ToString());
                crmService.Delete("acm_listinvaliddocument", (Guid) duplicate.Guid);
                //automatic and manual mode - input interval in minutes
            }
        }
    }
}
