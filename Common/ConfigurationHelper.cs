using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Common
{
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Allows to save settings to app.config file in appSettings section
        /// </summary>
        /// <param name="parameter">parameter name</param>
        /// <param name="value">parameter value</param>
        public static void SaveSettings(string parameter, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Remove(parameter);
            configuration.AppSettings.Settings.Add(parameter, value);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

        /// <summary>
        /// Allows to compute MD5 from input
        /// </summary>
        /// <param name="input">input string</param>
        /// <returns>MD5 string</returns>
        public static string ComputeMd5Checksum(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] data = md5.ComputeHash(Encoding.Default.GetBytes(input));
            return BitConverter.ToString(data).Replace("-", String.Empty);
        }
    }
}