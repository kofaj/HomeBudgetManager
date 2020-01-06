using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using static HomeBudgetManager.Common.Models.BaseUnit;

namespace HomeBudgetManager.Common.Services.BankManagerFactory
{
    public class MBank : IBankTransactionManager
    {
        private readonly string[] RawData;

        public MBank(string[] rawData)
        {
            RawData = rawData;
        }

        public IList<BaseUnit> ConvertToBaseUnit()
        {
            var result = new List<BaseUnit>();

            int transactionDate = 0;
            int transactionName = 1;
            int tValue = 4;

            // to save time I'll hardcode properties from file (indexes)

            for (int i = 28; i < RawData.Length; i++)
            {
                string[] transactionDetails = RawData[i].Split(";");

                DateTime dt = DateTime.Parse(transactionDetails[transactionDate]);
                TransactionTypes tt = transactionDetails[tValue].StartsWith('-') ? TransactionTypes.Charge : TransactionTypes.Credit;
                string tName = transactionDetails[transactionName].Substring(1, transactionDetails[transactionName].Length - 2).Trim();
                float value = ConvertToFloat(transactionDetails[tValue]);

                result.Add(new BaseUnit(dt, tName, value, tt, new Atribute()));
            }

            return result;
        }

        private float ConvertToFloat(string v)
        {
            v = v.Replace(',', '.').Replace(" ","");

            float.TryParse(v.Substring(0, v.Length - 3), out float result);

            return result;
        }
    }
}
