using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.Models.Users
{
    public class UserAccountModel
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string LastName {  get; set; }
        public string DisplayName { get; set; }
        public byte[] ProfilePicture { get; set; }

    }
}
