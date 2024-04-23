using Microsoft.Data.SqlClient;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnections
{
    public class SqlCommandExecutor : ISqlCommandExecutor
    {
        private readonly ISqlConnectionManager _connectionManager;

        public SqlCommandExecutor(ISqlConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public T ExecuteCommand<T>(Func<SqlCommand, T> commandFunc, string commandText, params SqlParameter[] parameters)
        {
            using (var connection = _connectionManager.GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = commandText;
                command.Parameters.AddRange(parameters);

                return commandFunc(command);
            }
        }
    }
}
