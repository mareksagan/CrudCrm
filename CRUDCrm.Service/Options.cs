using CommandLine;

namespace CrudCrm.Service
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

        [Option('i', "initialize", Required = false, HelpText = "Initialize the entity records", DefaultValue = false)]
        public bool Initialize { get; set; }

        [Option('d', "delete", Required = false, HelpText = "Delete the entity records", DefaultValue = false)]
        public bool Delete { get; set; }

        [Option('u', "update", Required = false, HelpText = "Update the entity records", DefaultValue = false)]
        public bool Update { get; set; }

        [Option('a', "autoupdate", Required = false, HelpText = "Autoupdate the entity records at the given time", DefaultValue = null)]
        public string Autoupdate { get; set; }

        [Option('v', "verbose", Required = false, HelpText = "Sets the log verbosity", DefaultValue = false)]
        public bool Verbose { get; set; }

        [Option('c', "credits", Required = false, HelpText = "Print the credits and the project description", DefaultValue = false)]
        public bool Credits { get; set; }

        [Option('h', "help", Required = false, HelpText = "Print this help",  DefaultValue = false)]
        public bool Help { get; set; }

    }
}
