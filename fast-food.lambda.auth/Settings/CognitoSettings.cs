using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Settings
{
    public class CognitoSettings
    {
        public string UserPoolId { get; private set; }
        public string ClientId { get; private set; }
        public string ClientSecret { get; private set; }

        public string AwsAccessKey { get; private set; }
        public string AwsSecretAccessKey { get; private set; }
        public string AwsSessionToken { get; set; }

        public CognitoSettings()
        {
            //UserPoolId = "";
            //ClientId = "";
            //ClientSecret = "";
            //AwsAccessKey = "";
            //AwsSecretAccessKey = "";
            //AwsSessionToken = "";
        }
    }
}
