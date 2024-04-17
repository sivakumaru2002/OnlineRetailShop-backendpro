using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;
using OnlineRetailShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Service.Implementation
{
    public class UserCheckService: IUserCheckService
    {
        public IAuthenticationRespository authenticationRespository;
        public UserCheckService(IAuthenticationRespository authenticationRespository)
        {
            this.authenticationRespository = authenticationRespository;
        }
        public async Task<UserModel> CheckUser(Guid userid)
        {
            UserModel exists =await authenticationRespository.GetUser(userid);
            return exists;
        }
    }
}
