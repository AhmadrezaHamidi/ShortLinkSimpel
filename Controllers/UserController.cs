using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Microsoft.VisualBasic;
using VestaAbner.Dbcontext;
using VestaAbner.Dto;
using VestaAbner.Model;

namespace VestaAbner.Controllers
{
    [Route("api/[controller]/{action}")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly DbContextt contaxt1;
        private readonly SignInManager<User> _signIn;
        private readonly RoleManager<IdentityRole> _RoleManger;
        private readonly IJWTAuthenticationManagerr _jWT;
        public UserController(UserManager<User> userManager, DbContextt contaxt,SignInManager<User> signInManager,RoleManager<IdentityRole> roleManager,IJWTAuthenticationManager iJWT)
        {
            _userManager = userManager;
            contaxt1 = contaxt;
            _signIn = signInManager;
            _RoleManger = roleManager;
            _jWT = iJWT;
        }

        public class AccessToken
        {
            public string Token { get; set; }
            public DateTime ExpiredAt { get; set; }

        }
        [HttpPost]
        //CRAETE A USER FOR US
        public async Task<AccessToken> Register([FromBody] RegisterUserDtu item)
        {
            if (!await _RoleManger.RoleExistsAsync("user"))
            {
                await _RoleManger.CreateAsync(new IdentityRole("user"));
            }

            
            User user = new User
            {
                UserName = item.UserName,
                firstname = item.firstName,
                lastName = item.lastName,
                Age = item.Age,
                Email = item.EmailAddress


            };

            var res = await _userManager.FindByEmailAsync(item.EmailAddress);
            var ddm= await _userManager.FindByNameAsync(item.UserName);

            if (res==null  &&  ddm ==null)
            {

               var result = await _userManager.CreateAsync(user, item.PassWord);
             
                if (result.Succeeded)
                {
                    var token = _jWT.Authenticate(user );
                    if (token == null)
                    {
                        return null;
                    }
                    var UsrFromDb = await _userManager.FindByNameAsync(item.UserName);
                    await _userManager.AddToRoleAsync(UsrFromDb, "user");
                    return new AccessToken() {Token= token,ExpiredAt = DateTime.Now.AddHours(3) };

                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

           
        }
        [HttpPost]
        ///for user login 
        public async Task<string> login ([FromBody] LoginUserDtu item)
        {
            if (ModelState.IsValid)
            {
                ////var userManeger = new UserManager<User>(new UserStore<User>(new DbContextt()));
                var uuser = await _userManager.FindByNameAsync(item.UserLogin);
                var user = await _signIn.CheckPasswordSignInAsync(uuser, item.PassWord, false);
                var token = _jWT.Authenticate(uuser);
                if (token == null)
                {
                    return null;
                }
                if ( user.Succeeded )
                {
                    return $"Login is Okey and youre token is {token}  ";
                   
                }
                else
                {
                    return null  ;
                }
                    
            }
            return null;
        }
        [HttpPost]
        public async Task<string> ChangTheRolUser([FromQuery] string userName,string RollName)
        {
            var FoubdUser = await _userManager.FindByNameAsync(userName);
            if (FoubdUser==null)
            {
                return null;
            }
            else
            {
                var FoundRoll = await _RoleManger.FindByNameAsync(RollName);
                if (FoubdUser == null)
                {
                    return null;
                }
                else
                {

                   var res= await _userManager.IsInRoleAsync(FoubdUser, FoundRoll.Name);
                    
                   
                    if (res)
                    {
                        return null;
                    }
                    else
                    {
                     var result= await _userManager.AddToRoleAsync(FoubdUser, FoundRoll.Name);
                        if (result.Succeeded)
                        {
                            var token = _jWT.Authenticate(FoubdUser);
                            if (token == null)
                            {
                                return null;
                            }
                            return $" changed is Okey  youre token is {token}  ";
                           
                        }
                        else
                        {
                            return "Result is Not seccessful";
                        }
                    }
                }
            }

        }
        [HttpPost]
        public async Task<string> DeleteRollForUser([FromQuery] string userName, string RollName)
        {
            var FoundUser =await _userManager.FindByNameAsync(userName);
            if (FoundUser==null)
            {
                return "This User Is not Exist";
            }
            else
            {
                var FoundRoll = await _RoleManger.FindByNameAsync(RollName);
                if (FoundUser == null)
                {
                    return "This Roll is not exist";
                }
                else
                {
                    var res = await _userManager.IsInRoleAsync(FoundUser , FoundRoll.Name);
                    if (res ==false)
                    {
                        return "This is Not Okey ";
                    }
                    else
                    {
                        var Result = await _userManager.RemoveFromRoleAsync(FoundUser, FoundRoll.Name);
                        if (Result.Succeeded)
                        {
                            var token = _jWT.Authenticate(FoundUser);
                            if (token == null)
                            {
                                return "Token is Not Okey ";
                            }
                            return $"Deleted youre token is {token}  ";


                        }
                        else
                        {
                            return "Delete Nashod ";
                        }
                    }

                }
            }

        }

        [HttpDelete]
        [AllowAnonymous]
        /// for deleting the user
        public async Task<string> Delete([FromQuery] string id )
        {
            var ExistUser = await _userManager.FindByNameAsync(id);

            if (ExistUser.Equals(null))
            {
                return null;
            }
            else
            {
               IdentityResult result = await _userManager.DeleteAsync(ExistUser);
                contaxt1.SaveChanges();
            if (result.Succeeded)
            {
                    var token = _jWT.Authenticate(ExistUser);
                    if (token == null)
                    {
                        return null;
                    }
                    return $"30k out, youre token is {token}  ";
                  
            }
            else
            {
                return "Afrin dabare talash kon ";
            }
            }
            //   IdentityResult result = await _userManager.RemoveLoginAsync(User.Identity.GetUserId(), new UserLoginInfo(loginprovider, providerKey));
        }
       // public async 
        [HttpPost]
        [Authorize(Roles ="user")]
        //for updatre our user 
        public async Task<string> UpDate([FromBody] UpdateUserDtu item,[FromQuery]string UserName)
        {
            var ExistUser = await _userManager.FindByNameAsync(UserName);
            ExistUser.Email = item.EmailAddress;
            ExistUser.firstname = item.firstName;
            ExistUser.lastName = item.lastName;
            ExistUser.Age = item.Age;

            var rs = await _userManager.UpdateAsync(ExistUser);
            if (rs == null)
            {
                return "Apdate is  not okey";
            }
            else
            {

                return $"apdate is okey  out,  ";
               
            }

        }
        
    }
    
}
