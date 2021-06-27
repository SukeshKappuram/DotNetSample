using System.Linq;

namespace ProductAPI.DataLayer.User
{
    using Models;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;
    using Dapper;
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;

        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> AddUserAsync(User user,string userRole)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<bool>("sp_AddUser",new
                {
                    user.FirstName,
                    user.LastName,
                    user.MobileNumber,
                    user.EmailAddress,
                    user.Password,
                    userRole
                },null,null,CommandType.StoredProcedure);
            }
        }

        public async Task<bool> DeleteUserAsync(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<bool>("sp_DeleteUser", new
                {
                    user.Id
                }, null, null, CommandType.StoredProcedure);
            }
        }

        public  Task<User> GetUserDetailsAsync(AppLogin appUser)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                var result = con.QueryMultiple("sp_GetUserDetails", new
                {
                    appUser.UserName,
                    appUser.Password
                }, null, null, CommandType.StoredProcedure);

                User user = result.Read<User>().FirstOrDefault();
                if (user != null && user.EmailAddress != null)
                {
                    user.UserRoles = result.Read<UserRole>().ToList();
                }

                return Task.FromResult(user);
            }
        }

        public Task<bool> UpdateUserAsync(User user)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return con.QueryFirstOrDefaultAsync<bool>("sp_UpdateUser", new
                {
                    user.Id,
                    user.FirstName,
                    user.LastName,
                    user.MobileNumber,
                    user.EmailAddress,
                    user.Password
                }, null, null, CommandType.StoredProcedure);
            }
        }

        public async Task<bool> IsEmailUniqueAsync(string emailAddress)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                return await con.QueryFirstOrDefaultAsync<bool>("sp_IsEmailUnique", new
                {
                    emailAddress
                }, null, null, CommandType.StoredProcedure);
            }
        }
    }
}
