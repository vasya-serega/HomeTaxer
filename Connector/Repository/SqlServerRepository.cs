using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Connector.Interfaces;

namespace Connector.Repository
{
    public class SqlServerRepository
    {
        public static SqlConnection EstablishConnection(string userName, string password)
        {
            var connStr = "Server=VASYA;Database=HomeTaxes;User Id=sa;Password=123456";
            var connection = new SqlConnection(connStr);
            connection.Open();

            return connection;
        }

        public static Dictionary<int, string> GetCurrencies(SqlConnection connection)
        {
            var dict = new Dictionary<int, string>();

            return dict;
        }

        public int GetUserId(SqlConnection connection, string username)
        {
            return 1;   // Stub
        }
        
    }
}