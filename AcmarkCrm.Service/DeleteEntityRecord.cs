﻿using System;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace AcmarkCrm.Service
{
    partial class Program
    {
        private static void DeleteAllEntityRecords(IOrganizationService crmService)
        {
            Console.WriteLine("Deleting all records. Please wait.");

            BulkDeleteRequest request = new BulkDeleteRequest
            {
                JobName = "Delete All",
                ToRecipients = new Guid[] { },
                CCRecipients = new Guid[] { },
                RecurrencePattern = string.Empty,
                QuerySet = new QueryExpression[]
                {
                    new QueryExpression { EntityName = "acm_listinvaliddocument" }
                }
            };


            crmService.Execute(request);
        }
    }
}