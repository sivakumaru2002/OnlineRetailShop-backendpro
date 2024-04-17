using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.OAuth.Claims;
using OnlineRetailShop.Service.Interface;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;
namespace OnlineRetailshop.Filter
{
    public class AuthorizationFilter : Attribute, IAuthorizationFilter
    {
        public readonly IUserCheckService userCheck;
        public readonly IAuthenticationRespository authenticationRespository;
        public AuthorizationFilter(IUserCheckService userCheck, IAuthenticationRespository authenticationRespository)
        {
            this.userCheck = userCheck;
            this.authenticationRespository = authenticationRespository;
        }
        public async void OnAuthorization(AuthorizationFilterContext context)
        {
             UserModel isAuth = await AuthorizationLogic(context.HttpContext);
            if (isAuth==null) { context.Result = new UnauthorizedObjectResult("UnAuthorized"); }
        }


        private async Task<UserModel> AuthorizationLogic(HttpContext context)
        {
            string userid =context.User.Claims.First(x => x.Type == "UserId").Value;
            Guid Guiduserid = Guid.Parse(userid);
            UserModel users = await userCheck.CheckUser(Guiduserid);
            return users;
        }

    }
}