using SellWoodTracker_ver2._0.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces
{
    public interface IUserAdder
    {
        void Add(UserModel userModel);
    }
}
