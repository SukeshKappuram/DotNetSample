using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.DataLayer.User;
using ProductAPI.Models;
using ProductAPI.Models.Security;

namespace ProductAPI.Business.User
{
    public class UserBusiness:IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        private readonly ISecurityManager _securityManager;

        public UserBusiness(IUserRepository userRepository, ISecurityManager securityManager)
        {
            _userRepository = userRepository;
            _securityManager = securityManager;
        }

        public Task<bool> AddUserAsync(Models.User user, string userRole)
        {
           return _userRepository.AddUserAsync(user, userRole);
        }

        public Task<bool> UpdateUserAsync(Models.User user)
        {
            return _userRepository.UpdateUserAsync(user);
        }

        public Task<bool> DeleteUserAsync(Models.User user)
        {
            return _userRepository.DeleteUserAsync(user);
        }

        public async Task<Models.User> GetUserDetailsAsync(AppLogin user)
        {
            var result = await _userRepository.GetUserDetailsAsync(user);

            if (result != null)
            {
                if (result.Id > 0 && result.UserRoles == null)
                {
                    throw new Exception("Invalid Password");
                }
                if (result.Id == 0)
                {
                    throw new Exception("Invalid Username and Password");
                }
                AppUserAuth appUserAuth = new AppUserAuth() {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    EmailAddress = result.EmailAddress,
                    MobileNumber = result.MobileNumber,
                    UserRoles = result.UserRoles
                };
                _securityManager.BuildUserAuthObject(appUserAuth);
                return appUserAuth;//success
            }
            throw new Exception("Invalid Username and Password");
        }

        public Task<bool> IsEmailUniqueAsync(string emailAddress)
        {
            return _userRepository.IsEmailUniqueAsync(emailAddress);
        }
    }
}
