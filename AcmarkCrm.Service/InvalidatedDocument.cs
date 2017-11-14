using System;
using AcmarkCrm.Service;
using LINQtoCSV;

namespace AcmarkCrm
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidatedDocument : IInvalidatedDocument
    {
        /// <inheritdoc />
        [CsvColumn(FieldIndex = 1, CanBeNull = false)]
        public string DocumentId { get; set; }

        /// <inheritdoc />
        [CsvColumn(FieldIndex = 2, CanBeNull = false, OutputFormat = "dd.mm.yyyy")]
        public DateTime InvalidationDate { get; set; }
    }
}
