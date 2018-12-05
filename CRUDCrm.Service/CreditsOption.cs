using System;

namespace CrudCrm.Service
{
    partial class Program
    {
        private static void CreditsOption()
        {
            Console.WriteLine(
                "COPYRIGHT\n" +
                
                "Marek Sagan, 2017\n\n" +

                "THE TASK\n" +

                "The database consists of several files that need to be imported to a CRM entity.\n" +
                "The update procedure may run regularly every day at night.\n\n" +

                "USED APPROACH\n" +

                "Late-bound classes\n\n" +

                "ENTITY DESCRIPTION\n" +

                "Entity name: acm_listinvaliddocument\n" +
                "Primary key: acm_listinvaliddocumentid (GUID)\n\n" +

                "ENTITY ATTRIBUTES\n" +

                "Document number: acm_documentnumber, string (10)\n" +
                "Series: acm_batch, string (4)\n" +
                "Document type: acm_documenttype, picklist\n" +
                "Date of invalidation: acm_invalidationdate, DateTime\n\n" +

                "DOCUMENT TYPE\n" +

                "WithoutSeries: 805210000\n" +
                "WithSeries: 805210001\n" +
                "Violet: 805210002\n" +
                "Green: 805210003"
            );
        }
    }
}
