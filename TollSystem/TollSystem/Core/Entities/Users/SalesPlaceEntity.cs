using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class SalesPlaceEntity
    {
        public string Name { get; set; }
        public Credentials Credentials { get; set; }
        public int AvailableTags { get; set; }

        public SalesPlaceEntity()
        { }

        public SalesPlaceEntity(string name, Credentials credentials, int availableTags)
        {
            Name = name;
            Credentials = credentials;
            AvailableTags = availableTags;
        }
    }
}
