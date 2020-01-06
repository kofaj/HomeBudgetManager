using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Common.Services.BankManagerFactory;
using System;
using System.Collections.Generic;
using System.IO;
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
            IReadOnlyList<BaseUnit> bUnit = result.ConvertToBaseUnit();
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
