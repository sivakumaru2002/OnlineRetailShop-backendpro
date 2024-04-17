using OnlineRetailShop.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Repository.Interface
{
    public interface IAuthenticationRespository
    {
        Task<UserModel> GetUser(Guid userid);
    }
}
