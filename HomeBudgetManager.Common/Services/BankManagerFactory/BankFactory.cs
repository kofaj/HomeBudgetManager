using HomeBudgetManager.Common.Services.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetManager.Common.Services.BankManagerFactory
{
    public abstract class BankFactory
    {
        public abstract IBankTransactionManager CreateBaseUnit(string[] rawData);
    }

    public class MilleniumBankFactory : BankFactory
    {
        public override IBankTransactionManager CreateBaseUnit(string[] rawData)
        {
            return new MilleniumBank(rawData);
        }
    }

    public class MbankFactory : BankFactory
    {
        public override IBankTransactionManager CreateBaseUnit(string[] rawData)
        {
            return new MBank(rawData);
        }
    }
}
