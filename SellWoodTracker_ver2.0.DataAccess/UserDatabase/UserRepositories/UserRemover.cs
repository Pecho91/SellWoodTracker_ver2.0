using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnectionInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories
{
    internal class UserRemover
    {
        private readonly ISqlConnectionManager _connectionManager;
        private readonly ISqlCommandExecutor _commandExecutor;

        public UserRemover(ISqlConnectionManager connectionManager, ISqlCommandExecutor commandExecutor)
        {
            _connectionManager = connectionManager;
            _commandExecutor = commandExecutor;
        }
        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
