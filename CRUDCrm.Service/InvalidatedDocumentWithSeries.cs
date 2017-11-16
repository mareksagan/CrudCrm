using System;
using LINQtoCSV;

namespace CrudCrm.Service
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidatedDocumentWithSeries : IInvalidatedDocument
    {
        /// <inheritdoc />
        [CsvColumn(FieldIndex = 1, CanBeNull = false)]
        public string DocumentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [CsvColumn(FieldIndex = 2, CanBeNull = false)]
        public string DocumentSeries { get; set; }

        /// <inheritdoc />
        [CsvColumn(FieldIndex = 3, CanBeNull = false, OutputFormat = "dd.mm.yyyy")]
        public DateTime InvalidationDate { get; set; }
    }
}