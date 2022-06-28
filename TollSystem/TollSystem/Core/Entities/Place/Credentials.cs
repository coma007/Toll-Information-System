using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class Credentials
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public Credentials()
        {

        }
        
        public Credentials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }

}
