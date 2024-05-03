using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnectionInterfaces;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.UserServices
{
    public class UserServiceFactory
    {
        private readonly string _connectionString;
        public UserServiceFactory(string connectionString) 
        {
            _connectionString = connectionString;
        }

        public ISqlConnectionManager CreateSqlConnectionManager()
        {
            return new SqlConnectionManager(_connectionString);
        }

        public ISqlCommandExecutor CreateSqlCommandExecutor(ISqlConnectionManager connectionManager)
        {
            return new SqlCommandExecutor(connectionManager);
        }
    }
}
