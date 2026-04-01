using Microsoft.Extensions.Configuration;

namespace Core
{
    public static class ConfigReader
    {
        private static readonly IConfiguration configuration;
        static ConfigReader()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }
        public static string? BaseUrl => configuration["AppSettings:BaseUrl"];
        public static string? Browser => configuration["AppSettings:Browser"];
    }
}