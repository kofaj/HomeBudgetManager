using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetManager.Common.Models
{
    public class BaseUnit
    {
        public enum TransactionTypes
        {
            Charge,
            Credit,
            InternalTransfer
        }

        public DateTime TransactionDate { get; set; }
        public string TransactionName { get; set; }
        public float Value { get; set; }
        public TransactionTypes TransactionType { get; set; }
        public Atribute Atribute { get; set; }
    }
}
