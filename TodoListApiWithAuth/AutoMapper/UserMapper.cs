using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoListApiWithAuth.Models;
using TodoListApiWithAuth.Models.Response;

namespace TodoListApiWithAuth.AutoMapper
{
    public class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<UserResponse, GetUsersResponse>();
        }
    }
}