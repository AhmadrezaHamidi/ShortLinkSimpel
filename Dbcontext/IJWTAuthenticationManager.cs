using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using VestaAbner.Dto;
using VestaAbner.Model;

namespace VestaAbner.Dbcontext
{
    public interface IJWTAuthenticationManagerr
    {

         string Authenticate(User Username);
    }
    public class IJWTAuthenticationManager : IJWTAuthenticationManagerr
    {
        private readonly string _tokenKey;
        public IJWTAuthenticationManager(string TokenKey)
        {
            _tokenKey = TokenKey;
        }

        public string Authenticate(User user)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(_tokenKey);
            var TokenDiscripetion = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.firstname + " " + user.lastName),
                    new Claim(ClaimTypes.Sid, user.Id),


                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(TokenDiscripetion);
            return TokenHandler.WriteToken(token);
        }

    }
}
