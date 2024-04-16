using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.LoginServices
{
    public class AuthenticationLoginService
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationLoginService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool AuthenticateUser(string username, SecureString password)
        {
            return _userRepository.AuthenticateUser(new NetworkCredential(username, password));
        }
    }
}
