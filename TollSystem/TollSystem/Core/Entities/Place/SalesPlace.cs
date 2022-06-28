using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class SalesPlace
    {
        public string Name { get; set; }
        public Credentials Credentials { get; set; }
        public int AvailableTags { get; set; }

        public SalesPlace()
        { }

        public SalesPlace(string name, Credentials credentials, int availableTags)
        {
            Name = name;
            Credentials = credentials;
            AvailableTags = availableTags;
        }
    }
}
