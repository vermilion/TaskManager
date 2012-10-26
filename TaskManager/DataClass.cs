using System.Configuration;

namespace TaskManager
{
    public static class DataClass
    {
        public static void SaveSettings(string parameter, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings.Remove(parameter);
            configuration.AppSettings.Settings.Add(parameter, value);
            configuration.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}