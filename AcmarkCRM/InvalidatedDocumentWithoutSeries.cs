using LINQtoCSV;
using System;

namespace AcmarkCrm
{
    class InvalidatedDocumentWithoutSeries
    {
        [CsvColumn(Name = "DocumentNumber", FieldIndex = 1)]
        public int DocumentNumber { get; set; }
    }
}
