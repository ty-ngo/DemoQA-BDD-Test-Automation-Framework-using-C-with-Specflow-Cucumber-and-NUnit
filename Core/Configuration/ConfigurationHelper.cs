using Microsoft.Extensions.Configuration;

namespace Core.Configuration
{
    public class ConfigurationHelper
    {
        private static IConfigurationRoot _config = null;
        public static IConfiguration ReadConfiguration(string path)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(path)
                .Build();
            _config = config;
            return _config;
        }

        public static IConfigurationRoot GetConfiguration()
        {
            return _config;
        }

    }
}