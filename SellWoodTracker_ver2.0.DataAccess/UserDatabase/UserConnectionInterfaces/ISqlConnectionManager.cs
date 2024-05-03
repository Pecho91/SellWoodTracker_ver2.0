using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnectionInterfaces
{
    public interface ISqlConnectionManager
    {
        SqlConnection GetConnection();
    }
}
