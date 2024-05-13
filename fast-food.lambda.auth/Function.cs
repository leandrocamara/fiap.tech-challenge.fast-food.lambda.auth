using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Helpers;

using Services;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace fast_food.lambda.auth;

public class Function
{
    private readonly CognitoService _cognitoService;
    public Function()
    {
        _cognitoService = new CognitoService();
    }

    public async Task<APIGatewayProxyResponse> FunctionHandler(string cpf, ILambdaContext context)
    {
        //verifica se o CPF � v�lido

        bool cpfIsValid = CPFHelper.IsValid(cpf);
        if(!cpfIsValid) 
        {
            return new APIGatewayProxyResponse
            {
                StatusCode = 400,
                Body = "BadRequest"
            };
        }

        // Verifica se o CPF j� existe na base de dados
        bool cpfExists = await _cognitoService.UserExists(cpf);
        
        // Cadastra o usu�rio no Amazon Cognito
        if (!cpfExists)        
            await _cognitoService.RegisterUser(cpf);        
       
        //autentica o Usu�rio    
        string token = await _cognitoService.AuthAsync(cpf);
        return new APIGatewayProxyResponse
        {
            StatusCode = 200,
            Body = token // Retorna o token gerado
        };
        
    }
}
