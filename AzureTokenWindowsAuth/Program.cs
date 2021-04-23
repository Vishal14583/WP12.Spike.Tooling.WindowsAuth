using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;

namespace AzureTokenWindowsAuth
{
    public static class Program
    {
        static async Task Main(string[] args)
        {
            string jwtToken;
            Configuration configuration = new Configuration();

            AuthTokenProvider authTokenProvider = new AuthTokenProvider();
            jwtToken = await authTokenProvider.GenerateToken(configuration.ClientId, configuration.TenantId, configuration.MicrosoftOnlineLoginUrl);

            Console.WriteLine(jwtToken);
        }
    }

    public class AuthTokenProvider
    {
        public async Task<string> GenerateToken(string clientId, string tenantId, string microsoftOnlineLoginUrl)
        {
            string authority = $"{microsoftOnlineLoginUrl}{tenantId}";
            string[] scopes = new string[] { $"{clientId}/.default" };

            IPublicClientApplication debugapp = PublicClientApplicationBuilder
                                                  .Create(clientId)
                                                  .WithAuthority(authority)
                                                  .Build();

            //Acquiring token through windows auth
            AuthenticationResult tokenTask = await debugapp.AcquireTokenByIntegratedWindowsAuth(scopes)
                                                           .ExecuteAsync();
            return tokenTask.AccessToken;
        }
    }
}
