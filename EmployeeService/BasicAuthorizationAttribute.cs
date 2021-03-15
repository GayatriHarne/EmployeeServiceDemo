using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace EmployeeService
{
    public class BasicAuthorizationAttribute:AuthorizationFilterAttribute
    {
     /// <summary>
    /// Validate login credentials provided in http header
    /// </summary>
    /// <param name="actionContext"></param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
            else
            {
                string AuthenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodatedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(AuthenticationToken));
                string[] UsernamePasswordarray = decodatedAuthenticationToken.Split(':');
                string Username = UsernamePasswordarray[0];
                string Password=UsernamePasswordarray[1];
                if(EmployeeSecurity.Login(Username,Password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username),null);
                }
                else
                {
                    actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}