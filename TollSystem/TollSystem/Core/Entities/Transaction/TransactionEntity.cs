using System;
using System.Collections.Generic;
using System.Text;
using TollSystem.Core.Enumerations;
using TollSystem.Infrastructure.Models;

namespace TollSystem.Core.Entities
{
    public class TransactionEntity
    {
        public int Id;
        public int Price { get; set; }
        public Currency Currency { get; set; }
        public TransitEntity Transit { get; set; }


        public TransactionEntity()
        { 
        }

        public TransactionEntity(int id, int price, Currency currency, TransitEntity transit)
        {
            Id = id;
            Price = price;
            Currency = currency;
            Transit = transit;
        }

        public TransactionEntity(Transaction transaction)
        {
            Id = (int)transaction.Id;
            Price = (int)transaction.Price;
            Currency = (Currency) Enum.Parse(typeof(Currency), transaction.Currency, true);
            Transit = null;
        }
    }
}
