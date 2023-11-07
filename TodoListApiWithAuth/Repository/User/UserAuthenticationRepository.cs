using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using TodoListApiWithAuth.AppDbContext;
using TodoListApiWithAuth.Models;
using TodoListApiWithAuth.Models.Request;

namespace TodoListApiWithAuth.Repository.User
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private TodoDbContext _context = new TodoDbContext();

        public string Login(LoginRequest request)
        {
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email);

            if(user is null)
            {
                throw new System.Exception("User Not Found");
            }

            if(!_verifyPassword(request.Password, user.PasswordHash, user.PasswrodSalt))
            {
                throw new System.Exception("Password Incorrect");
            }

            var token = _createUserToken(user);

            return token;
        }

        public UserResponse SignUp(SignUpRequest request)
        {
            _createPasswordHash(request.Password, out byte[] hash, out byte[] salt);

            var user = new UserResponse
            {
                Name = request.Name,
                Email = request.Email,
                PasswordHash = hash,
                PasswrodSalt = salt
            };

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        private void _createPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        { 
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool _verifyPassword(string password, byte[] hash, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(hash);
            }
        }

        private string _createUserToken(UserResponse user)
        {
            string key = WebConfigurationManager.AppSettings["JwtKey"];
            string issuer = "http://mysite.com";
            List<Claim> claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var userToken = new JwtSecurityToken(
                                    issuer,
                                    issuer,
                                    claims,
                                    expires: DateTime.UtcNow.AddDays(1),
                                    signingCredentials: credentials
                                ) ;

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(userToken);
            return jwtToken;
        }
    }
}