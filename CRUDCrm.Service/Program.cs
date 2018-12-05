using System;
using CommandLine;

namespace CrudCrm.Service
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Options options = new Options();

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
            ArchiveDownloader archiveDownloader = ArchiveDownloader.GetArchiveDownloader();
            CsvReader csvReader = CsvReader.GetCsvReader();

            if (options.Verbose)
            {
                VerboseOption(manipulator, crmConnector);
            }
            
            if (options.Initialize)
            {
                InitializeOption(crmConnector, options, manipulator);
            }
            else if (options.Delete)
            {
                DeleteOption(crmConnector, options, manipulator);
            }
            else if (options.Update)
            {
                UpdateOption(crmConnector, options, manipulator);
            }
            else if (!string.IsNullOrEmpty(options.Autoupdate))
            {
                AutoupdateOption(crmConnector, options, manipulator);
            }
            else if (options.Credits)
            {
                CreditsOption();
            }
            else if (options.Help)
            {
                HelpOption(options);
            }
            else
            {
                OtherOption();
            }
        }

        private static void InitializeOption(CrmConnector crmConnector, Options options, EntityManipulator manipulator)
        {
            Console.Write("INITIALIZING CRM ENTITY");

            SetUpCrmConnection(crmConnector, options, manipulator);

            manipulator.DeleteAllEntityRecords();

            manipulator.AddEntityRecords();
        }

        private static void UpdateOption(CrmConnector crmConnector, Options options, EntityManipulator manipulator)
        {
            Console.Write("UPDATING CRM ENTITY");

            SetUpCrmConnection(crmConnector, options, manipulator);

            manipulator.DeleteEntityRecords();

            manipulator.AddEntityRecords();
        }

        private static void AutoupdateOption(CrmConnector crmConnector, Options options, EntityManipulator manipulator)
        {
            Console.Write("AUTOUPDATING CRM ENTITY ON " + options.Autoupdate + " EVERY DAY");

            DateTime updateTime = DateTime.Parse(options.Autoupdate);

            SetUpCrmConnection(crmConnector, options, manipulator);
            //schedule QuartzNet job
            manipulator.DeleteEntityRecords();

            manipulator.AddEntityRecords();

        }

        private static void VerboseOption(EntityManipulator manipulator, CrmConnector crmConnector)
        {
            manipulator.Logging = true;
            crmConnector.Logging = true;
        }

        private static void OtherOption()
        {
            Console.Write("WRONG OR MISSING ARGUMENTS");
        }

        private static void HelpOption(Options options)
        {
            Console.Write(CommandLine.Text.HelpText.AutoBuild(options));
        }

        private static void DeleteOption(CrmConnector crmConnector, Options options, EntityManipulator manipulator)
        {
            Console.Write("WARNING. THIS WILL REMOVE ALL RECORDS FROM THE ENTITY. " +
                          "DO YOU WISH TO CONTINUE? (Y/N)");

            string answer = Console.ReadLine();

            if (answer == "y" || answer == "Y")
            {
                SetUpCrmConnection(crmConnector, options, manipulator);

                manipulator.DeleteAllEntityRecords();
            }
            else
            {
                Console.Write("OPERATION ABORTED");
            }
        }

        private static void SetUpCrmConnection(CrmConnector crmConnector, Options options, EntityManipulator manipulator)
        {
            //add Castle Windsor?
            try
            {
                crmConnector.Url = options.OrganizationUrl;
                crmConnector.Login = options.UserName;
                crmConnector.Password = options.Password;

                crmConnector.ConnectToCrm();

                manipulator.CrmService = crmConnector.CrmService;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }
    }
}