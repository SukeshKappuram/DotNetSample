using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models.Security
{
    public class AppUserAuth: User
    {
        public string BearerToken { get; set; }
    }
}
