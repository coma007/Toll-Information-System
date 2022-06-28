using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;

namespace TollSystem.Core.Entities
{
    class TransactionEntity
    {
        public int Price { get; set; }
        public Currency Currency { get; set; }
        public TransitEntity Transit { get; set; }


        public TransactionEntity()
        { 
        }

        public TransactionEntity(int price, Currency currency, TransitEntity transit)
        {
            Price = price;
            Currency = currency;
            Transit = transit;
        }
    }
}
