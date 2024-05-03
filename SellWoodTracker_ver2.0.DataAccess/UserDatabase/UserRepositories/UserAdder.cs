using Microsoft.Data.SqlClient;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnectionInterfaces;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using SellWoodTracker_ver2._0.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories
{
    public class UserAdder : IUserAdder
    {
        private readonly ISqlConnectionManager _connectionManager;
        private readonly ISqlCommandExecutor _commandExecutor;

        public UserAdder(ISqlConnectionManager connectionManager, ISqlCommandExecutor commandExecutor)
        {
            _connectionManager = connectionManager;
            _commandExecutor = commandExecutor;
        }

        public void Add(UserModel userModel)
        {
            _commandExecutor.ExecuteCommand(command => command.ExecuteNonQuery(),
            "INSERT INTO [User] (Id, Username, Password, Name, LastName, Email) VALUES (@Id, @Username, @Password, @Name, @LastName, @Email)",
            new SqlParameter("@Id", SqlDbType.NVarChar) { Value = userModel.Id },
            new SqlParameter("@Username", SqlDbType.NVarChar) { Value = userModel.Username },
            new SqlParameter("@Password", SqlDbType.NVarChar) { Value = userModel.Password },
            new SqlParameter("@Name", SqlDbType.NVarChar) { Value = userModel.Name },
            new SqlParameter("@LastName", SqlDbType.NVarChar) { Value = userModel.LastName },
            new SqlParameter("@Email", SqlDbType.NVarChar) { Value = userModel.Email });
        }
    }
}
