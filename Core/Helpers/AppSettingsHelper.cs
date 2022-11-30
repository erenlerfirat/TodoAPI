
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Core.Helpers
{
    public static class AppSettingsHelper
    {   
        private static readonly IConfigurationRoot Configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();

        public static T GetValue<T>(string key, T defaultValue)
        {            
            var value = Configuration.GetValue<T>(key, defaultValue);

            if (string.IsNullOrEmpty(value.ToString()))
                return defaultValue;

            return (T)Convert.ChangeType(value, typeof(T));
        }
    }

}
