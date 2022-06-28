using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class Transaction
    {
        public int Price { get; set; }
        public Currency Currency { get; set; }
        public Transit Transit { get; set; }


        public Transaction()
        { 
        }

        public Transaction(int price, Currency currency, Transit transit)
        {
            Price = price;
            Currency = currency;
            Transit = transit;
        }
    }
}
