using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Helpers;
using Settings;
using System.Security.Cryptography;

namespace Services
{
    public class CognitoService
    {
        private readonly AmazonCognitoIdentityProviderClient _cognitoClient;
        private readonly CognitoSettings _settings;
        public CognitoService()
        {
            _settings = new CognitoSettings();

            _cognitoClient = new AmazonCognitoIdentityProviderClient(new SessionAWSCredentials(_settings.AwsAccessKey, _settings.AwsSecretAccessKey,_settings.AwsSessionToken), Amazon.RegionEndpoint.USEast1);
                //(new BasicAWSCredentials(_settings.ClientId, _settings.ClientSecret), Amazon.RegionEndpoint.USEast1);

        }

        public async Task RegisterUser(string cpf)
        {
            var secretHash = CognitoHelper.GetSecretHash(cpf, _settings.ClientId, _settings.ClientSecret);


            var signUpRequest = new SignUpRequest
            {
                ClientId = _settings.ClientId,
                Password = cpf,
                Username = cpf,
                SecretHash = secretHash
            };

            await _cognitoClient.SignUpAsync(signUpRequest);

            var request = new AdminConfirmSignUpRequest
            {
                UserPoolId = _settings.UserPoolId,
                Username = cpf
            };
            
            await _cognitoClient.AdminConfirmSignUpAsync(request);
        }
           

        public async Task<string> AuthAsync(string cpf)
        {
            var secretHash = CognitoHelper.GetSecretHash(cpf, _settings.ClientId, _settings.ClientSecret);

            var authRequest = new InitiateAuthRequest
            {

                ClientId = _settings.ClientId,
                AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
                AuthParameters = new Dictionary<string, string>
            {
                {"USERNAME", cpf},
                {"PASSWORD", cpf},
                {"SECRET_HASH", secretHash}
            }
            };

            var authResponse = await _cognitoClient.InitiateAuthAsync(authRequest);
            return authResponse.AuthenticationResult.IdToken;
        }

        public async Task<bool> UserExists(string cpf)
        {
            var request = new AdminGetUserRequest
            {
                UserPoolId = _settings.UserPoolId,
                Username = cpf
            };

            try
            {
                var response = await _cognitoClient.AdminGetUserAsync(request);
                return response != null;
                  
            }
            catch (UserNotFoundException)
            {   
                return false;
            }
        }

    }
}
