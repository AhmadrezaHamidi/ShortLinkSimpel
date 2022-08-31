using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VestaAbner.Model
{
    public class TbRole : IdentityRole
    {
        public List<TbUserRole> userRoles { get; set; }
    }
}
