using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using LINQtoCSV;

namespace CrudCrm.Service
{
    sealed class CsvReader
    {
        public bool Logging { get; set; }

        public string Path { get; set; }

        public static CsvFileDescription InputFileDescription { get; set; }

        public static CsvContext InputFileContext { get; set; }

        public string InputFileExtension { get; set; }

        private static readonly CsvReader Instance = new CsvReader();

        public static CsvReader GetCsvReader()
        {
            return Instance;
        }

        private CsvReader()
        {
            Path = AppDomain.CurrentDomain.BaseDirectory + @"csv\";

            InputFileContext = new CsvContext();
            InputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ';',
                FirstLineHasColumnNames = false,
                EnforceCsvColumnAttribute = true
            };

            InputFileExtension = ".csv";

            Logging = false;

        }

        public IEnumerable<InvalidatedDocument> ReadCsv(string fileName)
        {
            IEnumerable<InvalidatedDocument> products = null;

            try
            {
                products = InputFileContext.Read<InvalidatedDocument>(Path + fileName + InputFileExtension,
                    InputFileDescription);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return products;
        }

    }
}
