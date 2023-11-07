using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

[assembly: OwinStartup(typeof(TodoListApiWithAuth.OwinStartup))]

namespace TodoListApiWithAuth
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            string key = WebConfigurationManager.AppSettings["JwtKey"];
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = Microsoft.Owin.Security.AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "http://mysite.com",
                        ValidAudience = "http://mysite.com",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                    }
                });
        }
    }
}
