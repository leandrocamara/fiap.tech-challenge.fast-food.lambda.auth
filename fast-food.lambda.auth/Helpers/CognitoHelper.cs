namespace Helpers;

public static class CognitoHelper
{
    public static string GetSecretHash(string username, string clientId, string clientSecret)
    {
        var hmac = new System.Security.Cryptography.HMACSHA256(System.Text.Encoding.UTF8.GetBytes(clientSecret));
        var secretBlock = username + clientId;
        return Convert.ToBase64String(hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(secretBlock)));
    }
}
