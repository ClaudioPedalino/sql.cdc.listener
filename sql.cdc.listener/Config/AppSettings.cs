using Microsoft.Extensions.Configuration;
using System;

namespace sql.cdc.listener.Config
{
    public class AppSettings
    {
        public string CDCListenerDb { get; set; }
    }

    public static class ConfigHelper
    {
        public static AppSettings GetAppsettings()
            => new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build().GetSection(nameof(AppSettings)).Get<AppSettings>();
    }
}
