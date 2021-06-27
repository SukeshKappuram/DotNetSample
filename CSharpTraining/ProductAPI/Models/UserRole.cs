using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class UserRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool HasAccess { get; set; }
    }
}
