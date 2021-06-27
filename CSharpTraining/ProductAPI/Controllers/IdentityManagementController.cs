using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductAPI.Business.User;
using ProductAPI.Models;

namespace ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityManagementController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public IdentityManagementController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }

        [HttpPost]
        [Route("signup")]
        public Task<bool> RegisterUser(User user)
        {
            return _userBusiness.AddUserAsync(user, "Consumer");
        }

        [HttpPost]
        [Route("addSeller")]
        public Task<bool> addSeller(User user)
        {
            return _userBusiness.AddUserAsync(user, "Seller");
        }

        [HttpPost]
        [Route("login")]
        public Task<User> LoginUser(AppLogin user)
        {
            return _userBusiness.GetUserDetailsAsync(user);
        }

        [HttpPost]
        [Route("updateProfile")]
        public Task<bool> UpdateUser(User user)
        {
            return _userBusiness.UpdateUserAsync(user);
        }

        [HttpPost]
        [Route("deleteAccount")]
        public Task<bool> DeleteUser(User user)
        {
            return _userBusiness.DeleteUserAsync(user);
        }

        [HttpGet]
        [Route("isEmailUnique/{emailAddress}")]
        public Task<bool> IsEmailAddressUnique(string emailAddress)
        {
            return _userBusiness.IsEmailUniqueAsync(emailAddress);
        }
    }
}
