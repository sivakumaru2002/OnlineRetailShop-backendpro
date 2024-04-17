using OnlineRetailShop.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailShop.Service.Interface
{
    public interface IAuthenticationServices
    {
        Task<UserModel> GetUser(Guid userid);
    }
}
