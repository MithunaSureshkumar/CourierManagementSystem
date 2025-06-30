using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CourierManagementSystem.ConnectionUtil
{
    static class DbConnection
    {
        private static IConfiguration iConfiguration;

        static DbConnection()
        {
            GetAppSettingsFile();

        }
        private static void GetAppSettingsFile()
        {
            var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())   // this is to see the  json file
                        .AddJsonFile("AppSettings.json");    //loads the configuration builder file
            iConfiguration = builder.Build();
        }



        public static string GetConnectionString()
        {
            return iConfiguration.GetConnectionString("LocalConnection");
        }

        public static SqlConnection GetConnectionObject()
        {
            SqlConnection sqlConn = new SqlConnection(GetConnectionString());
            return sqlConn;
        }
    }
}

