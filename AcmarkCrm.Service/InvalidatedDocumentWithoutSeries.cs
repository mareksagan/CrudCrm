using System;
using LINQtoCSV;

namespace AcmarkCrm.Service
{
    public class InvalidatedDocumentWithoutSeries
    {
        [CsvColumn(Name = "ProductName", FieldIndex = 1)]
        public string Name { get; set; }
        [CsvColumn(FieldIndex = 2, OutputFormat = "dd MMM HH:mm:ss")]
        public DateTime LaunchDate { get; set; }
        [CsvColumn(FieldIndex = 3, CanBeNull = false, OutputFormat = "C")]
        public decimal Price { get; set; }

        // remove unneccessary project references
    }
}