using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoListApiWithAuth.AppDbContext;
using TodoListApiWithAuth.Models;
using TodoListApiWithAuth.Models.Response;

namespace TodoListApiWithAuth.Repository.User
{
    public class UserRepository : IUserRepository
    {
        private TodoDbContext _context = new TodoDbContext();
        public UserResponse GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public IEnumerable<UserResponse> GetUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        
    }
}