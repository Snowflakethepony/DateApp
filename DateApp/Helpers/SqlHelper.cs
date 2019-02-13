using System.Configuration;

namespace DateApp.Helpers
{
    public class SqlHelper
    {
        public static string ConVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}