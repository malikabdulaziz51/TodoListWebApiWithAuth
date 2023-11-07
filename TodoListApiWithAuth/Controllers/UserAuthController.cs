using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoListApiWithAuth.Models;
using TodoListApiWithAuth.Models.Request;
using TodoListApiWithAuth.Models.Response;
using TodoListApiWithAuth.Repository.User;

namespace TodoListApiWithAuth.Controllers
{
    [RoutePrefix("api/user")]
    public class UserAuthController : ApiController
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly IUserRepository _userRepository;

        public UserAuthController()
        {
            _userAuthenticationRepository = new UserAuthenticationRepository();
            _userRepository = new UserRepository();
        }

        [HttpGet]
        [Route("get")]
        public IHttpActionResult Get()
        {
            var users = _userRepository.GetUsers();
            var result = users.Select(Mapper.Map<UserResponse, GetUsersResponse>);
            return Ok(result);
        }

        [HttpGet]
        [Route("get/{id}")]
        public IHttpActionResult GetById(int id)
        {
            var user = _userRepository.GetUserById(id);
            var result = Mapper.Map<UserResponse, GetUsersResponse>(user);
            return Ok(result);
        }

        [HttpPost]
        [Route("signup")]
        public IHttpActionResult Register(SignUpRequest request)
        {
            var result = _userAuthenticationRepository.SignUp(request);
            return Ok(result);
        }

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginRequest request)
        {
            var result = _userAuthenticationRepository.Login(request);
            return Ok(result);
        }

    }
}
