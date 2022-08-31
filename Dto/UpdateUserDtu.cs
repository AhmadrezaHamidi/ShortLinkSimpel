using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VestaAbner.Dto
{
    public class UpdateUserDtu
    {
        public string EmailAddress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int Age { get; set; }
       //// public string Password { get; set; }
    }
}
