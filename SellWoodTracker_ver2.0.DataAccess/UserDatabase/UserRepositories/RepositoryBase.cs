using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=SellWoodTrcker_ver2.0_test;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        }

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
