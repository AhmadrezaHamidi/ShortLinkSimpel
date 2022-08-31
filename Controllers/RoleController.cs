using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VestaAbner.Dto;

namespace VestaAbner.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleMameger;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleMameger=roleManager;
        }
        [HttpPost]
        public async Task<string> Create([FromQuery] string titeel)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleMameger.CreateAsync(new IdentityRole(titeel));
                if (result.Succeeded)
                {
                    return "Okey ";
                }
                else
                {
                    return "Not Okey";
                }
            }
            return "The user is not  valid";
        }
        [HttpPost]
        public async Task<string> Delete([FromQuery] string UserName)
        {
            var role = await _roleMameger.FindByNameAsync(UserName);
            if (role == null)
            {
                return "I cant found this User!!!";
            }
            else
            {
                IdentityResult resul = await _roleMameger.DeleteAsync(role);
                if (resul.Succeeded)
                {
                    return "role Deleted ";
                }
                else
                {
                    return "Role is not deleted ";
                }
            }
        }
       public async Task<List<RoleDtu>> ShowAllrole()
        {
            var AllRouls =await _roleMameger.Roles.Select(x => new RoleDtu
            {
                Name = x.Name

            }).ToListAsync();
            return AllRouls;
            


        }


    }
}
