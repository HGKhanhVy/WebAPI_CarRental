using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace CarRental.Core.Configs
{
    public class SystemSettingModel
    {
        public static SystemSettingModel Instance { get; set; }

        public static IConfiguration Configs { get; set; }
        public string ApplicationName { get; set; } = Assembly.GetEntryAssembly()?.GetName().Name;

        public string? Domain { get; set; }
    }
}
