using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Common.Utilities;
using System;
using System.Collections.Generic;
using static HomeBudgetManager.Common.Models.BaseUnit;

namespace HomeBudgetManager.Common.Services.BankManagerFactory
{
    public class MilleniumBank : IBankTransactionManager
    {
        private readonly string[] RawData;

        public MilleniumBank(string[] rawData)
        {
            RawData = rawData;
        }

        public IList<BaseUnit> ConvertToBaseUnit(ref IList<Atribute> atr)
        {
            List<BaseUnit> result = new List<BaseUnit>();

            // to save time I'll hardcode properties from file (indexes)
            int transactionDate = 1;
            int transactionName = 6;
            int charge = 7;
            int credit = 8;

            // first line is a header and we can skip it
            for (int i = 1; i < RawData.Length; i++)
            {
                string[] transactionDetails = RawData[i].Split(',');
                DateTime dt = DateTime.Parse(transactionDetails[transactionDate].Substring(1, 10));
                TransactionTypes tt = transactionDetails[charge].Length > 3 ? TransactionTypes.Charge : TransactionTypes.Credit;
                string tName = transactionDetails[transactionName].Substring(1, transactionDetails[transactionName].Length - 2);
                float value = tt == TransactionTypes.Charge ? ConvertToFloat(transactionDetails[charge]) : ConvertToFloat(transactionDetails[credit]);
                Atribute a = ObjectFinder.GetFitAtribute(ref atr, tName);

                result.Add(new BaseUnit(dt, tName, value, tt, a));
            }

            return result;
        }

        private float ConvertToFloat(string v)
        {
            float.TryParse(v.Substring(1, v.Length - 2), out float result);

            return result;
        }
    }
}
