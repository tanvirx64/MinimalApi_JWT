using MinimalApi_JWT.Models;
using MinimalApi_JWT.Repositories;

namespace MinimalApi_JWT.Services
{
    public class UserService : IUserService
    {
        public User Get(UserLogin userLogin)
        {
            return UserRepository.users.FirstOrDefault(x => x.Username.Equals(userLogin.Username, StringComparison.OrdinalIgnoreCase) && x.Password == userLogin.Password);
        }
    }
}
