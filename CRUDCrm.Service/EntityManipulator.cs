using System;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;

namespace CrudCrm.Service
{
    sealed class EntityManipulator
    {
        public static string EntityName { get; set; }

        public IOrganizationService CrmService { get; set; }

        public bool Logging { get; set; }

        private static readonly EntityManipulator Instance = new EntityManipulator();

        private EntityManipulator()
        {
            EntityName = "acm_listinvaliddocument";
            Logging = false;
        }

        public static EntityManipulator GetEntityManipulator()
        {
            return Instance;
        }

        public void DeleteAllEntityRecords()
        {
            if (Logging)
            {
                Console.WriteLine("DELETING ALL ENTITY RECORDS");
            }

            BulkDeleteRequest request = new BulkDeleteRequest
            {
                JobName = "Delete All",
                ToRecipients = new Guid[] { },
                CCRecipients = new Guid[] { },
                RecurrencePattern = String.Empty,
                QuerySet = new[]
                {
                    new QueryExpression { EntityName = EntityName}
                }
            };

            CrmService.Execute(request);

            if (Logging)
            {
                Console.WriteLine("DELETE REQUEST SENT TO THE SERVER");
            }
        }

        public static Entity CreateNewEntity(string entityName)
        {
            return new Entity(entityName);
        }

        public static Entity CreateNewEntity()
        {
            return new Entity(EntityName);
        }

        public void AddEntityRecords()
        {
            CsvReader csvrdr = new CsvReader();

            csvrdr.DownloadBaseCsvFiles();

            var collection = csvrdr.ReadCsv("op_vse");

            var requestWithResults = new ExecuteMultipleRequest()
            {
                // Assign settings that define execution behavior: continue on error, return responses. 
                Settings = new ExecuteMultipleSettings()
                {
                    ContinueOnError = false,
                    ReturnResponses = true
                },
                // Create an empty organization request collection.
                Requests = new OrganizationRequestCollection()
            };

            EntityCollection entityCollection = new EntityCollection()
            {
                EntityName = "acm_listinvaliddocument"
            };

            foreach (var item in collection)
            {
                if (!string.IsNullOrEmpty(item.DocumentId))
                {
                    Entity tempEntity = new Entity("acm_listinvaliddocument")
                    {
                        Attributes =
                                {
                                    ["acm_documentnumber"] = item.DocumentId,
                                    ["acm_documenttype"] = DocumentType.WithoutSeries,
                                    ["acm_invalidationdate"] = item.InvalidationDate
                                }
                    };

                    entityCollection.Entities.Add(tempEntity);
                }

                Console.WriteLine(item.DocumentId);
            }

            foreach (var entity in entityCollection.Entities)
            {
                CreateRequest createRequest = new CreateRequest { Target = entity };
                requestWithResults.Requests.Add(createRequest);
            }

            CrmService.Execute(requestWithResults);
        }

        public void AddEntityRecord(string documentNumber, string batch, DocumentType typeOfDocument, DateTime date)
        {
            OptionSetValue documentType = new OptionSetValue { Value = (int)typeOfDocument };

            Entity entityRecord = new Entity(EntityName)
            {
                Attributes =
                {
                    ["acm_documentnumber"] = documentNumber,
                    ["acm_batch"] = batch,
                    ["acm_documenttype"] = documentType,
                    ["acm_invalidationdate"] = date
                }
            };

            Guid id = Guid.Empty;

            try
            {
                id = CrmService.Create(entityRecord);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine($"RECORD CREATED - Guid: {id}");
        }
    }
}

