using TodoListApiWithAuth.Models;
using TodoListApiWithAuth.Models.Request;

namespace TodoListApiWithAuth.Repository.User
{
    public interface IUserAuthenticationRepository
    {
        UserResponse SignUp(SignUpRequest request);
        string Login(LoginRequest request);
    }
}
