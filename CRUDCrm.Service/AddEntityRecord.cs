using System;
using Microsoft.Xrm.Sdk;

namespace CRUDCrm.Service
{
    partial class Program
    {
        public enum TypeOfInvalidatedDocument
        {
            WithoutSeries = 805210000,
            WithSeries = 805210001,
            Violet = 805210002,
            Green = 805210003
        }

        private static Entity CreateNewEntity()
        {
            return new Entity("acm_listinvaliddocument");
        }

        private static void AddEntityRecord(IOrganizationService crmService, string documentNumber, string batch, TypeOfInvalidatedDocument typeOfDocument, DateTime date, Entity entity)
        {
            OptionSetValue documentType = new OptionSetValue {Value = (int) typeOfDocument};

            Entity entityRecord = entity;

            entityRecord.Attributes["acm_documentnumber"] = documentNumber;
            entityRecord.Attributes["acm_batch"] = batch;
            entityRecord.Attributes["acm_documenttype"] = documentType;
            entityRecord.Attributes["acm_invalidationdate"] = date;

            Guid id = Guid.Empty;

            try
            {
                id = crmService.Create(entityRecord);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            Console.WriteLine($"RECORD CREATED - Guid: {id}");
        }
    }
}
