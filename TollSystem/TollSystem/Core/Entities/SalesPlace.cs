using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class SalesPlace
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AvailableTags { get; set; }

        public SalesPlace()
        { }

        public SalesPlace(string name, string username, string password, int availableTags)
        {
            Name = name;
            Username = username;
            Password = password;
            AvailableTags = availableTags;
        }
    }
}
