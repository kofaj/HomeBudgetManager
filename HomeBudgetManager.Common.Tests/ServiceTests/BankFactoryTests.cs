using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Common.Services.BankManagerFactory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace HomeBudgetManager.Common.Tests.ServiceTests
{
    public class BankFactoryTests
    {
        internal enum TestBankType
        {
            None,
            Millenium,
            MBank
        }

        [Fact]
        public void ReadMilleniumSampleFile()
        {
            string[] rawData = GetTransactionBankFile(TestBankType.Millenium);

            Assert.NotEmpty(rawData);
        }

        [Fact]
        public void ReadMBankSampleFile()
        {
            string[] rawData = GetTransactionBankFile(TestBankType.MBank);

            Assert.NotEmpty(rawData);
        }

        [Fact]
        public void GetMilleniumTransactionAndReturnBaseUnits()
        {
            string[] rawData = GetTransactionBankFile(TestBankType.Millenium);

            BankTransactionManager service = new BankTransactionManager();
            var result = service.ExecuteCreation(BankType.Millenium, rawData);
            IList<BaseUnit> bUnit = result.ConvertToBaseUnit();

            Assert.NotNull(bUnit);

            // charge
            Assert.False(string.IsNullOrEmpty(bUnit[1].TransactionDate.ToShortDateString()));
            Assert.False(string.IsNullOrEmpty(bUnit[1].TransactionName));
            Assert.NotEqual(0, bUnit[1].Value);
            Assert.Equal(BaseUnit.TransactionTypes.Charge, bUnit[1].TransactionType);

            // credit
            Assert.False(string.IsNullOrEmpty(bUnit[2].TransactionDate.ToShortDateString()));
            Assert.False(string.IsNullOrEmpty(bUnit[2].TransactionName));
            Assert.NotEqual(default, bUnit[2].Value);
            Assert.Equal(BaseUnit.TransactionTypes.Credit, bUnit[2].TransactionType);

        }

        [Fact]
        public void GetMBankTransactionAndReturnBaseUnits()
        {
            string[] rawData = GetTransactionBankFile(TestBankType.MBank);

            BankTransactionManager service = new BankTransactionManager();
            var result = service.ExecuteCreation(BankType.MBank, rawData);
            IList<BaseUnit> bUnit = result.ConvertToBaseUnit();

            Assert.NotNull(bUnit);

            // charge
            Assert.False(string.IsNullOrEmpty(bUnit[1].TransactionDate.ToShortDateString()));
            Assert.False(string.IsNullOrEmpty(bUnit[1].TransactionName));
            Assert.NotEqual(0, bUnit[1].Value);
            Assert.Equal(BaseUnit.TransactionTypes.Charge, bUnit[1].TransactionType);

            // credit
            BaseUnit credit = bUnit.First(f => f.Value > 0); 

            Assert.False(string.IsNullOrEmpty(credit.TransactionDate.ToShortDateString()));
            Assert.False(string.IsNullOrEmpty(credit.TransactionName));
            Assert.NotEqual(0, credit.Value);
            Assert.Equal(BaseUnit.TransactionTypes.Credit, credit.TransactionType);

        }


        private string[] GetTransactionBankFile(TestBankType millenium)
        {
            string filePath = Directory.GetCurrentDirectory();

            switch (millenium)
            {
                case TestBankType.Millenium:
                    filePath += @"\Resources\MilleniumSample.csv";
                    break;
                case TestBankType.MBank:
                    filePath += @"\Resources\MBankSample.csv";
                    break;
                case TestBankType.None:
                default:
                    throw new Exception("Wrong Bank type");
            }

            string[] result = File.ReadAllLines(filePath);

            return result;
        }
    }
}
