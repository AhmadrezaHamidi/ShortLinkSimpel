using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace VestaAbner.Model
{
    public class TbUserRole :IdentityUserRole<string>
    {
        public User User { get; set; }
        public TbRole Role { get; set; }
    }
}
