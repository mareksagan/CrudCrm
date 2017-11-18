using System;
using CommandLine;
using Microsoft.Xrm.Sdk;

namespace CrudCrm.Service
{
    partial class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();

            try
            {
                Parser.Default.ParseArguments(args, options);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            EntityManipulator manipulator = EntityManipulator.GetEntityManipulator();

            CrmConnector crmConnector = CrmConnector.GetCrmConnector();



            if (options.Verbose)
            {
                manipulator.Logging = true;
                crmConnector.Logging = true;
            }
            
            if (options.Initialize)
            {

                IOrganizationService crmService = null;

                try
                {
                    crmService = ConnectToCrm(options.OrganizationUrl, options.UserName, options.Password);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }

                if (crmService != null)
                {
                    

                }
            }
            else if (options.Delete)
            {

                Console.WriteLine("WARNING. THIS WILL REMOVE ALL RECORDS FROM THE ENTITY. " +
                                  "DO YOU WISH TO CONTINUE? (Y/N)");

                string answer = Console.ReadLine();

                if (answer == "y" || answer == "Y")
                {
                    crmConnector.Url = options.OrganizationUrl;
                    crmConnector.Login = options.UserName;
                    crmConnector.Password = options.Password;

                    crmConnector.ConnectToCrm();

                    manipulator.CrmService = crmConnector.CrmService;

                    manipulator.DeleteAllEntityRecords();
                }
                else
                {
                    Console.WriteLine("OPERATION ABORTED");
                }

            }
            else if (options.Update)
            {
                
            }
            else if (options.Autoupdate!=null)
            {
                DateTime updateTime = DateTime.Parse(options.Autoupdate);
            }
            else if (options.Credits)
            {
                PrintCredits();
            }
            else if (options.Help)
            {
                Console.WriteLine(CommandLine.Text.HelpText.AutoBuild(options));
            }
            else
            {
                Console.WriteLine("WRONG OR MISSING ARGUMENTS. CLOSING");
            }
        }
    }
}