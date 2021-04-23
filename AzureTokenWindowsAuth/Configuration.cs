using Microsoft.Extensions.Configuration;
using System;

namespace AzureTokenWindowsAuth
{
    public class Configuration
    {
        protected IConfigurationRoot ConfigurationRoot;
        public string MicrosoftOnlineLoginUrl { get; set; }
        public string TenantId { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public bool IsRunningOnLocalMachine { get; set; }

        public Configuration()
        {
            ConfigurationRoot = new ConfigurationBuilder()
                                .AddJsonFile("appsettings.json", false)
                                .Build();

            MicrosoftOnlineLoginUrl = ConfigurationRoot.GetSection("MicrosoftOnlineLoginUrl").Value;
            TenantId = ConfigurationRoot.GetSection("TenantId").Value;
            ClientId = ConfigurationRoot.GetSection("ClientId").Value;
            ClientSecret = ConfigurationRoot.GetSection("ClientSecret").Value;
            IsRunningOnLocalMachine = bool.Parse(ConfigurationRoot.GetSection("IsRunningOnLocalMachine").Value);
        }
    }
}
