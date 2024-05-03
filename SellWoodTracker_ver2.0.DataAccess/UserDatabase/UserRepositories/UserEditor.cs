using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnectionInterfaces;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using SellWoodTracker_ver2._0.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories
{
    public class UserEditor : IUserEditor
    {
        private readonly ISqlConnectionManager _connectionManager;
        private readonly ISqlCommandExecutor _commandExecutor;

        public UserEditor(ISqlConnectionManager connectionManager, ISqlCommandExecutor commandExecutor)
        {
            _connectionManager = connectionManager;
            _commandExecutor = commandExecutor;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }
    }
}
