using Microsoft.AspNetCore.Http;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Service.Interface;

namespace OnlineRetailShop.MiddleWare
{
    public class AuthorizationMiddleware:IMiddleware
    {
        private readonly IUserCheckService _userCheckService;
        public AuthorizationMiddleware(IUserCheckService userCheckService)
        {
            _userCheckService = userCheckService;
        }
        public async Task InvokeAsync(HttpContext httpContext,RequestDelegate next)
        {

            string userid = httpContext.User.Claims.First(x => x.Type == "UserId").Value;
            Guid Guiduserid = Guid.Parse(userid);
            UserModel users = await _userCheckService.CheckUser(Guiduserid);
            if (users == null)
            {
                httpContext.Response.WriteAsync("Unauthorized");
                httpContext.Response.StatusCode = 401;
            }
            else
            await next(httpContext);
        }
    }
    public static class useAuthorizationMiddleWareClass
    {
        public static IApplicationBuilder useAuthorizationMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}
