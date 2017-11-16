using System;
using LINQtoCSV;

namespace CrudCrm.Service
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
        [CsvColumn(FieldIndex = 2, CanBeNull = false)]
        public DateTime InvalidationDate { get; set; }
    }
}
