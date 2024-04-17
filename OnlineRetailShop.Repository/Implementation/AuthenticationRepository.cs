using Microsoft.EntityFrameworkCore;
using OnlineRetailShop.Repository.Entity;
using OnlineRetailShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.Implementation
{
    public class AuthenticationRepository : IAuthenticationRespository
    {
        public readonly AppDbContext _appDbContext;
        public AuthenticationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<UserModel> GetUser(Guid userid)
        {
            return  _appDbContext.UserModel.FirstOrDefault(x=>x.UserId==userid);
        }
    }
}
