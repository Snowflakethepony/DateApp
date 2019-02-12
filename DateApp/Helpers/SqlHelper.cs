using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
