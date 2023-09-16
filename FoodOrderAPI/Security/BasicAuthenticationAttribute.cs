using System.Net;
using System.Text;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace FoodOrderAPI.Security
{
    public class BasicAuthenticationAttribute:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            else
            {
                string auth_String = actionContext.Request.Headers.Authorization.Parameter;
                string original_String = Encoding.UTF8.GetString(Convert.FromBase64String(auth_String));
                string username = original_String.Split(':')[0];
                string password = original_String.Split(':')[1];
                if(!username.Equals("testingapp") && !password.Equals("Bangsat12345"))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            base.OnAuthorization(actionContext);    
        }
    }
}
