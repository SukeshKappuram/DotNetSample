namespace ProductAPI.DataLayer.User
{
    using Models;
    using System.Threading.Tasks;
    public interface IUserRepository
    {
        public Task<bool> AddUserAsync(User user, string userRole);
        public Task<bool> UpdateUserAsync(User user);
        public Task<bool> DeleteUserAsync(User user);
        public Task<User> GetUserDetailsAsync(AppLogin user);
        public Task<bool> IsEmailUniqueAsync(string emailAddress);
    }
}
