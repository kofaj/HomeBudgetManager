using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Common.Services.BankManagerFactory;
using System.Collections.Generic;

namespace HomeBudgetManager.Common.Services
{
    public enum BankType
    {
        None,
        Millenium,
        MBank
    }

    public class BankTransactionManager
    {
        private readonly IDictionary<BankType, BankFactory> _factories;

        public IBankTransactionManager ExecuteCreation(BankType bType,string[] rawData) => _factories[bType].CreateBaseUnit(rawData);

        public BankTransactionManager()
        {
            _factories = new Dictionary<BankType, BankFactory>
            {
                { BankType.MBank, new MbankFactory()},
                { BankType.Millenium, new MilleniumBankFactory()}
            };
        }
    }
}
