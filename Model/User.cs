using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VestaAbner.Model
{
    public class User : IdentityUser
    {
        public string  firstname { get; set; }
        public string lastName { get; set; }
        public int Age { get; set; }
        /// public DateTime? Birthday { get; set; }
        public List<TbUserRole> userRoles { get; set; }

    }
}
