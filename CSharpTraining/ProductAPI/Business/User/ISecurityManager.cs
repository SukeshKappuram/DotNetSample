using ProductAPI.Models.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Business.User
{
    public interface ISecurityManager
    {
        void BuildUserAuthObject(AppUserAuth authUser);//new token based on user login
        string ExtendJwtTokenExpiration(string token);//new Token based on old one
    }
}
