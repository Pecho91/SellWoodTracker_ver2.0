using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnections
{
    public class SqlCommandExecutor
    {
        private readonly SqlConnectionManager _connectionManager;

        public SqlCommandExecutor(SqlConnectionManager connectionManager)
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
