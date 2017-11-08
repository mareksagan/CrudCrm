using System.Linq;
using Microsoft.Xrm.Sdk.Client;

namespace AcmarkCrm.Service
{
    partial class Program
    {
        private static void DeleteDuplicates(OrganizationServiceContext crmServiceContext)
        {
            //sql query to weed out duplicates (leave the newest/highest id) after adding new ones
            var queryContactwithFirstNameasNishant = from r in crmServiceContext.CreateQuery("contact")
                where ((string)r["firstname"]).Contains("Nishant")
                select new
                {
                    FirstName = r["firstname"],
                    LastName = r["lastname"]
                };

            var queryContactStartsWithN = from r in crmServiceContext.CreateQuery("contact")
                where ((string)r["firstname"]).StartsWith("N")
                select new
                {
                    FirstName = r["firstname"],
                    LastName = r["lastname"]
                };

            foreach (var account in queryContactStartsWithN)
            {
            }
        }
    }
}
