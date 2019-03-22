using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspDotNetCoreWebApi_BasicAuthentication_Demo.Model;

namespace AspDotNetCoreWebApi_BasicAuthentication_Demo.IRepository
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();

        Task<User> Get(int id);
    }
}
