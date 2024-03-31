using BasicWebAPI.Models;
using BasicWebAPI.Request_Models;

namespace BasicWebAPI.Interfaces
{
    public interface IAuthService
    {
        User AddUser(User user);
        string Login(LoginRequest loginRequest);
    }
}
