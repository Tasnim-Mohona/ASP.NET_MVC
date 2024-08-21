using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDevelopmentPractice.DBConnection
{
    public class DbConnection
    {
        private static string connectionString = "User id = ICCD; Password = mohona; data source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVICE_NAME = ORCL)))";

        public void setConnectionString(string connectionString)
        {
            connectionString = connectionString;
        }
        public string getConnectionString()
        {
            return connectionString;
        }
    }
}
