﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreWebApi_BasicAuthentication_Demo.IRepository;
using AspDotNetCoreWebApi_BasicAuthentication_Demo.Model;

namespace AspDotNetCoreWebApi_BasicAuthentication_Demo.Repository
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        };


        public async Task<User> Authenticate(string username, string password)
        {
            var user = await Task.Run(() => _users.SingleOrDefault(x => x.Username == username && x.Password == password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details without password
            user.Password = null;
            return user;
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            // return users without passwords
            return await Task.Run(() => _users.Select(x => {
                x.Password = null;
                return x;
            }));
        }

        public async Task<User> Get(int id)
        {
            // return users without passwords
            return await Task.Run(() => _users.FirstOrDefault(x => x.Id == id)); 
            
        }
    }
}
