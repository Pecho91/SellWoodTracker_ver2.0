using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using SellWoodTracker_ver2._0.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.UserServices
{
    public class UserAccountPreview
    {
        private readonly IUserRepository _userRepository;

        public UserAccountPreview(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserAccountModel GetCurrentUserAccount()
        {
            var userName = Thread.CurrentPrincipal?.Identity?.Name;
            if (userName != null)
            {
                var user = _userRepository.GetByUsername(userName);
                if (user != null)
                {
                    return new UserAccountModel
                    {
                        Username = user.Username,
                        DisplayName = $"{user.Name} {user.LastName}",
                        ProfilePicture = null
                    };
                }
            }
            return new UserAccountModel { DisplayName = "Invalid user, not logged in" };
        }
    }
}
