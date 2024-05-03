using SellWoodTracker_ver2._0.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces
{
    public interface IUserGetter
    {
        UserModel GetById(int id);
        UserModel GetByUsername(string username);
        IEnumerable<UserModel> GetByAll();
    }
}
