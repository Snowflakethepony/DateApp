using System.Configuration;

namespace DateApp.Helpers
{
    /// <summary>
    /// Class used as SQL interpretor.
    /// </summary>
    public class SqlHelper
    {
        /// <summary>
        /// Gets a connectionstring by name.
        /// </summary>
        /// <param name="name"> Connectring name. </param>
        /// <returns></returns>
        public static string ConVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}