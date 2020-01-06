using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetManager.Common.Services.BankManagerFactory
{
    public class MBank : IBankTransactionManager
    {
        private readonly string[] RawData;

        public MBank(string[] rawData)
        {
            RawData = rawData;
        }

        public IReadOnlyList<BaseUnit> ConvertToBaseUnit()
        {
            throw new NotImplementedException();
        }
    }
}
