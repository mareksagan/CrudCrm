using System.Collections.Generic;
using CommandLine;

namespace AcmarkCrm.Service
{
    class Options
    {
        [Option('o', "OrganizationUrl", Required = true, HelpText = "The SVC file location of your organization",
            DefaultValue = "https://vpn.acmark.cz:5555/TESTOrg/XRMServices/2011/Organization.svc")]
        public string OrganizationUrl { get; set; }

        [Option('u', "UserName", Required = true, HelpText = "Username used for CRM login",
            DefaultValue = "acmark\\sagan")]
        public string UserName { get; set; }

        [Option('p', "Password", Required = true, HelpText = "Password used for CRM login", DefaultValue = "rxVotBGzWvS1Vq5d")]
        public string Password { get; set; }

        [Option(DefaultValue = true, HelpText = "Automatic mode")]
        public bool Language { get; set; }

        [Option(DefaultValue = false, HelpText = "Prints all messages to standard output")]
        public bool Verbose { get; set; }
    }
}
