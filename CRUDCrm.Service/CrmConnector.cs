using System;
using System.Net;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace CrudCrm.Service
{
    class CrmConnector
    {
        public bool Logging { get; set; }

        public string Url { get; set; }

        private Uri OrganizationUri { get; set; }

        private ClientCredentials Credentials { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public IOrganizationService CrmService { get; private set; }

        private static readonly CrmConnector Instance = new CrmConnector();

        private CrmConnector()
        {
            SetUri();
        }

        public static CrmConnector GetCrmConnector()
        {
            return Instance;
        }

        public void SetUri()
        {
            OrganizationUri = new Uri(Url);
            if (Logging) Console.WriteLine("URI HAS BEEN SET");
        }

        public void SetCredentials()
        {
            Credentials.UserName.UserName = Login;
            Credentials.UserName.Password = Password;
            if (Logging) Console.WriteLine("CREDENTIALS HAVE BEEN SET");
        }

        private void AllowCustomSslCertificates()
        {
            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;
            if (Logging) Console.WriteLine("SELF-SIGNED SSL CERTIFICATES ARE NOW ALLOWED");
        }

        public void SetCrmService()
        {
            try
            {
                CrmService = new OrganizationServiceProxy(OrganizationUri, null, Credentials, null);
                if (Logging) Console.WriteLine("ESTABLISHED A CONNECTION WITH THE CRM ORGANISATION");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void ConnectToCrm()
        {
            SetCredentials();

            AllowCustomSslCertificates();

            SetCrmService();
        }
    }
}
