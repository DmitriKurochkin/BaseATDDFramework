using System;
using System.Configuration;
using System.IO;
using System.Reflection;

namespace AIMS.Tests.Common
{
    public static class CommonSettings
    {
        private static readonly ExeConfigurationFileMap ConfigMap = new ExeConfigurationFileMap
        {
            ExeConfigFilename = GetConfigFilePath()
        };

        /// <summary>
        /// Get path to configuration file for executing assembly
        /// </summary>
        /// <returns></returns>
        private static string GetConfigFilePath()
        {
            string configFile = Assembly.GetExecutingAssembly().Location + ".config";
            if (File.Exists(configFile))
                return configFile;
            throw new Exception(configFile + " configuration file does not exist.");
        }

        /// <summary>
        /// Load common configuration file
        /// </summary>
        private static readonly Configuration Config = ConfigurationManager.OpenMappedExeConfiguration(ConfigMap,
            ConfigurationUserLevel.None);

        public static class Urls
        {
            /// <summary>
            /// Base URL to portal, last "/" is trimmed
            /// </summary>
            public static string Base
            {
                get
                {
                    string url = "https://" + Config.AppSettings.Settings["BaseUrl"].Value;
                    return url.TrimEnd(new[] {'/'});
                }
            }

            /// <summary>
            /// Base user with maximize permissions  
            /// </summary>
            public static class BaseUser
            {
                public static string Username
                {
                    get { return Config.AppSettings.Settings["Username"].Value; }
                }

                public static string Password
                {
                    get { return Config.AppSettings.Settings["Password"].Value; }
                }

                public static string Company
                {
                    get { return Config.AppSettings.Settings["Company"].Value; }
                }

                public static string Upn
                {
                    get { return Config.AppSettings.Settings["Upn"].Value; }
                }
            }

            /// <summary>
            /// Get path to configuration file for executing assembly
            /// </summary>
            /// <returns></returns>
            private static string GetConfigFilePath()
            {
                string configFile = Assembly.GetExecutingAssembly().Location + ".config";
                if (File.Exists(configFile))
                    return configFile;
                throw new Exception(configFile + " configuration file does not exist.");
            }
        }
    }
}