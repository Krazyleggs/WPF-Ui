using System.Configuration;


namespace Uiprogramming
{
    public class ConnectionStringHelper
    {
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
