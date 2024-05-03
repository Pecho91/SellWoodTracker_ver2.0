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
    public class UserGetter : IUserGetter
    {
        private readonly ISqlConnectionManager _connectionManager;
        private readonly ISqlCommandExecutor _commandExecutor;

        public UserGetter(ISqlConnectionManager connectionManager, ISqlCommandExecutor commandExecutor)
        {
            _connectionManager = connectionManager;
            _commandExecutor = commandExecutor;
        }

       
        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel? GetByUsername(string username)
        {
            return _commandExecutor.ExecuteCommand(command =>
            {
                UserModel user = null;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString()
                        };
                    }
                }
                return user;
            },
            "select *from[User] where [username]=@username",
            new SqlParameter("@username", SqlDbType.NVarChar) { Value = username });
        }     
    }
}
