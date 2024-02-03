using MinimalApi_JWT.Models;

namespace MinimalApi_JWT.Services
{
    public interface IUserService
    {
        public User Get(UserLogin userLogin);
    }
}
