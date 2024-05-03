using Microsoft.Data.SqlClient;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnectionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnections
{
    public class SqlConnectionManager : ISqlConnectionManager
    {
        private readonly string _connectionString;

        public SqlConnectionManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
