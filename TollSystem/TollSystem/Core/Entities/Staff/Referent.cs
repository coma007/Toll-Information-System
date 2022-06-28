using System;
using System.Collections.Generic;
using System.Text;

namespace TollSystem.Core.Entities
{
    class Referent : Staff
    {
        public TollStation TollStation { get; set; }

        public Referent()
        {

        }

        public Referent(TollStation tollStation)
        {
            TollStation = tollStation;
        }
    }
}
