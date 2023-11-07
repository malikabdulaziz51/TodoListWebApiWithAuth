using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoListApiWithAuth.Models.Request;
using TodoListApiWithAuth.Repository.User;

namespace TodoListApiWithAuth.Controllers
{
    [RoutePrefix("api/user")]
    public class UserAuthController : ApiController
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;

        public UserAuthController()
        {
            _userAuthenticationRepository = new UserAuthenticationRepository();
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
