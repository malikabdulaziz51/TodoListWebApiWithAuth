using System.Collections.Generic;
using TodoListApiWithAuth.Models;

namespace TodoListApiWithAuth.Repository.User
{
    public interface IUserRepository
    {
        IEnumerable<UserResponse> GetUsers();
        UserResponse GetUserById(int id);

    }
}
