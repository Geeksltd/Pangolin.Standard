using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Parameters;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;

namespace Geeks.Pangolin
{

    public class ConfigHelper
    {
        #region [Property]

        private static ConfigHelper instance = null;
        public static ConfigHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigHelper();
                    instance.Init();
                }
                return instance;
            }
        }
        public static string AppSettingsFilenames { get; set; } = "appsettings.test.json;appsettings.test.secret.json;app.test.json;app.test.secret.json";
        public static string AppSettingsSection { get; set; } = "Pangolin";

        private IConfiguration _configuration;

        #endregion

        #region [Constructor]

        private ConfigHelper() { }

        private void Init()
        {            
            var appSettingsFilenames = AppSettingsFilenames?.Split(";,".ToCharArray(), System.StringSplitOptions.RemoveEmptyEntries);
            
            var builder= new ConfigurationBuilder()
                .SetBasePath(AppConstants.ProjectPath);

            foreach (var appSettingsFilename in appSettingsFilenames)
                builder.AddJsonFile(appSettingsFilename, true);

            _configuration = builder.Build();
        }

        #endregion

        #region [Public Method]

        public string Get(string key, string defaultValue) => _configuration.GetValue(key, defaultValue);

        public T Get<T>(string key) => Get<T>(key, default(T));

        public T Get<T>(string key, T defaultValue) => _configuration.GetValue(key, defaultValue);

        public string Get(string key) => Get(key, string.Empty);

        public string GetOrThrow(string key)
        {
            var result = Get(key);

            if (result.HasValue()) return result;
            else throw new System.Exception($"AppSetting value of '{key}' is not specified.");
        }

        #endregion
    }
}
