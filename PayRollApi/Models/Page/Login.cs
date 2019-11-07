using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayRollApi.Models.Page
{
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public string Token { get; set; }
    }
}
