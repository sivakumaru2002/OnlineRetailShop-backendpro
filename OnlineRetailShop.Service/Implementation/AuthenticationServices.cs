
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
    public class AuthenticationServices: IAuthenticationServices
    {
        public IAuthenticationRespository _authrepo;
        public AuthenticationServices(IAuthenticationRespository authenticationRespository) {
            _authrepo = authenticationRespository;
        }
        public async Task<UserModel> GetUser(Guid userid)
        {
            return await _authrepo.GetUser(userid);
        }
    }
}
