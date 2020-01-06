using System;

namespace HomeBudgetManager.Common.Models
{
    public class BaseUnit
    {
        public enum TransactionTypes
        {
            None,
            Charge,
            Credit,
            InternalTransfer
        }

        public DateTime TransactionDate;
        public string TransactionName;
        public float Value;
        public TransactionTypes TransactionType;
        public Atribute Atribute;

        public BaseUnit(DateTime transactionDate, string transactionName, float value, TransactionTypes transactionType, Atribute atribute)
        {
            TransactionDate = transactionDate;
            TransactionName = transactionName;
            Value = value;
            TransactionType = transactionType;
            Atribute = atribute;
        }
    }
}
