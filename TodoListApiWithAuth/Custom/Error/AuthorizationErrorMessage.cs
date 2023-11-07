using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace TodoListApiWithAuth.Custom.Error
{
    public class AuthorizationErrorMessage : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.ControllerContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new
            {
                code = HttpStatusCode.Unauthorized,
                message = "Sorry you are not authorized to perform this action"
            });
        }
    }
}