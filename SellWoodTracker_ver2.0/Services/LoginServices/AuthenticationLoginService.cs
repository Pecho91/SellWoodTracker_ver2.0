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
        private readonly IUserAuthenticator _userAuthenticator;

        public AuthenticationLoginService(IUserAuthenticator userAuthenticator)
        {
            _userAuthenticator = userAuthenticator;
        }

        public bool AuthenticateLoginUser(string username, SecureString password)
        {
            return _userAuthenticator.AuthenticateUser(new NetworkCredential(username, password));
        }
    }
}
