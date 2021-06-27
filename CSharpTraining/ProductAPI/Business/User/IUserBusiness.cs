using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Business.User
{
    using Models;
    public interface IUserBusiness
    {
        public Task<bool> AddUserAsync(User user, string userRole);
        public Task<bool> UpdateUserAsync(User user);
        public Task<bool> DeleteUserAsync(User user);
        public Task<User> GetUserDetailsAsync(AppLogin user);
        public Task<bool> IsEmailUniqueAsync(string emailAddress);
    }
}
