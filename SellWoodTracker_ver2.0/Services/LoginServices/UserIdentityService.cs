using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2_0.Services.LoginServices
{
    public class UserIdentityService
    {
        public void  SetCurrentPrincipal(string username) 
        {
            GenericIdentity identity = new GenericIdentity(username);
            GenericPrincipal principal = new GenericPrincipal(identity, null);
            Thread.CurrentPrincipal = principal;
        }

    }
}
