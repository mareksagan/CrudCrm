using Microsoft.Xrm.Client.Services;
using Microsoft.Xrm.Sdk;
using System;

namespace AcmarkCRM
{
    class Program
    {
        static void Main(string[] args)
        {
            IOrganizationService service = new OrganizationService("connection");

            Entity contact = new Entity("contact")
            {
                ["firstname"] = "Suresh",
                ["lastname"] = "Maurya"
            };

            Console.WriteLine("Creating Contact");

            Guid contactId = new Guid();

            try
            {
                contactId = service.Create(contact);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Contact with guid=" + contactId + " created");

            Console.WriteLine("updating Record");

            Entity contactToUpdate = new Entity("contact")
            {
                ["contactid"] = contactId,
                ["firstname"] = "Suresh-updated",
                ["lastname"] = "Maurya-Updated"
            };
            try
            {
                service.Update(contactToUpdate);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("Contact updated");

            Console.ReadKey();
        }
    }
}