using System;
using System.Net;
using System.ServiceModel.Description;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Client;

namespace CRUDCrm.Service
{
    partial class Program
    {

        //move to class CrmConnector - factory method/singleton class
        private static IOrganizationService ConnectToCrm(string url, string login, string password)
        {
            Uri oUri = new Uri(url);

            var credentials = new ClientCredentials();

            credentials.UserName.UserName = login;
            credentials.UserName.Password = password;

            ServicePointManager.ServerCertificateValidationCallback = (s, certificate, chain, sslPolicyErrors) => true;

            OrganizationServiceProxy proxy = new OrganizationServiceProxy(oUri, null, credentials, null);
            IOrganizationService crmService = proxy;

            return crmService;
        }
    }
}
