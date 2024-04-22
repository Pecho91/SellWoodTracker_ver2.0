﻿using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SellWoodTracker_ver2._0.DataAccess.BuyerDatabase.BuyerContext;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserConnections;
using SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserInterfaces;
using SellWoodTracker_ver2._0.Models.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellWoodTracker_ver2._0.DataAccess.UserDatabase.UserRepositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlCommandExecutor _commandExecutor;

        public UserRepository(string connectionString) 
        {
            var connectionManager = new SqlConnectionManager(connectionString);
            _commandExecutor = new SqlCommandExecutor(connectionManager);
        }

        public void Add(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            int userCount = _commandExecutor.ExecuteCommand(command => Convert.ToInt32(command.ExecuteScalar()),
            "SELECT COUNT(*) FROM [User] WHERE [username]=@username AND [password]=@password",
            new SqlParameter("@username", SqlDbType.NVarChar, 50) { Value = credential.UserName },
            new SqlParameter("@password", SqlDbType.NVarChar, 50) { Value = credential.Password });

            return userCount > 0;

            //bool validUser = false;
            //try
            //{
            //    using (var connection = GetConnection())
            //    using (var command = new SqlCommand())
            //    {
            //        connection.Open();
            //        command.Connection = connection;
            //        command.CommandText = "SELECT COUNT(*) FROM [User] WHERE [username]=@username AND [password]=@password";
            //        command.Parameters.Add("@username", SqlDbType.NVarChar, 50).Value = credential.UserName;
            //        command.Parameters.Add("@password", SqlDbType.NVarChar, 50).Value = credential.Password;

            //        int userCount = Convert.ToInt32(command.ExecuteScalar());
            //        validUser = userCount > 0;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine($"Error while authenticating user: {ex.Message}");
            //}
            //return validUser;
        }

        public void Edit(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetByAll()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel? GetByUsername(string username)
        {
            return _commandExecutor.ExecuteCommand(command =>
            {
                UserModel user = null;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader[0].ToString(),
                            Username = reader[1].ToString(),
                            Password = string.Empty,
                            Name = reader[3].ToString(),
                            LastName = reader[4].ToString(),
                            Email = reader[5].ToString()
                        };
                    }
                }
                return user;
            },
            "select *from[User] where [username]=@username",
            new SqlParameter("@username", SqlDbType.NVarChar) { Value = username });
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
