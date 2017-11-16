using CommandLine;

namespace CRUDCrm.Service
{
    class Options
    {
        [Option('o', "organizationurl", Required = true, HelpText = "The SVC file location of your organization",
            DefaultValue = "https://vpn.acmark.cz:5555/TESTOrg/XRMServices/2011/Organization.svc")]
        public string OrganizationUrl { get; set; }

        [Option('u', "username", Required = true, HelpText = "Username used for CRM login",
            DefaultValue = "acmark\\sagan")]
        public string UserName { get; set; }

        [Option('p', "password", Required = true, HelpText = "Password used for CRM login", DefaultValue = "rxVotBGzWvS1Vq5d")]
        public string Password { get; set; }

        [Option('t', "time", Required = false, HelpText = "Automatic mode", DefaultValue = "03:00")]
        public string Time { get; set; }

        [Option('m', "manual", Required = false, HelpText = "Manual mode", DefaultValue = false)]
        public bool Manual { get; set; }

        [Option('v', "verbose", Required = false, HelpText = "Prints all messages to standard output", DefaultValue = false)]
        public bool Verbose { get; set; }

        [Option('c', "credits", Required = false, HelpText = "Prints the credits", DefaultValue = false)]
        public bool Credits { get; set; }

        [Option('h', "help", Required = false, HelpText = "Prints this help",  DefaultValue = false)]
        public bool Help { get; set; }
    }
}
