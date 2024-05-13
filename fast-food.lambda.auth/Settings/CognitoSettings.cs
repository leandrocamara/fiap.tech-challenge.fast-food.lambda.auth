using Helpers;
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
            UserPoolId = EnvironmentHelper.GetRequiredEnvironmentVariable("USER_POOL_ID");
            ClientId = EnvironmentHelper.GetRequiredEnvironmentVariable("CLIENT_ID");
            ClientSecret = EnvironmentHelper.GetRequiredEnvironmentVariable("CLIENT_SECRET");
            AwsAccessKey = EnvironmentHelper.GetRequiredEnvironmentVariable("AWS_ACCESS_KEY_ID");
            AwsSecretAccessKey = EnvironmentHelper.GetRequiredEnvironmentVariable("AWS_SECRET_ACCESS_KEY");
            AwsSessionToken = EnvironmentHelper.GetRequiredEnvironmentVariable("AWS_SESSION_TOKEN");
        }     
    }
}
