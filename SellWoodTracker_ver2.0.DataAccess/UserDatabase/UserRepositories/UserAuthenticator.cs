using Microsoft.Data.SqlClient;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnectionInterfaces;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using SellWoodTracker_ver2._0.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories
{
    public class UserAuthenticator : IUserAuthenticator
    {
        private readonly ISqlConnectionManager _connectionManager;
        private readonly ISqlCommandExecutor _commandExecutor;

        public UserAuthenticator(ISqlConnectionManager connectionManager, ISqlCommandExecutor commandExecutor)
        {
            _connectionManager = connectionManager;
            _commandExecutor = commandExecutor;
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            int userCount = _commandExecutor.ExecuteCommand(command => Convert.ToInt32(command.ExecuteScalar()),
            "SELECT COUNT(*) FROM [User] WHERE [username]=@username AND [password]=@password",
            new SqlParameter("@username", SqlDbType.NVarChar, 50) { Value = credential.UserName },
            new SqlParameter("@password", SqlDbType.NVarChar, 50) { Value = credential.Password });

            return userCount > 0;
        }
    }
}
