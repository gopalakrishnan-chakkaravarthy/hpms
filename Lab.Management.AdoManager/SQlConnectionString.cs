using System.Configuration;
namespace Lab.Management.AdoManager
{
    public static class SQlConnectionString
    {

        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["LMSDBConnection"].ConnectionString;

        }
    }
}
