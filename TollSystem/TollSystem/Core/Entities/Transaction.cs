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
       // TODO dodati Transit

        public Transaction()
        { 
        }

        public Transaction(int price, Currency currency, int TransitId)
        {
            Price = price;
            Currency = currency;
        }
    }
}
