using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Common.Tests.Mock;
using HomeBudgetManager.Repository.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HomeBudgetManager.Common.Tests.ServiceTests
{
    public class AtributeServiceTests
    {
        [Fact]
        public void AddNewAtribute()
        {
            IUnitManager<Atribute> mock = new AtributeUnitManagementMock();
            IUnitCommand<Atribute> service = new AtributeService(mock);
            IUnitQuery<Atribute> queryService = new AtributeService(mock);

            int atributeId = 1;
            string tName = "new Atribute";
            Atribute g = new Atribute(atributeId,tName);
            service.Add(g);

            var result = queryService.GetAllPositions();

            Assert.NotEmpty(result);
            Assert.Equal(tName, result[0].Name);
        }

        [Fact]
        public void EditAtribute()
        {
            IUnitManager<Atribute> mock = new AtributeUnitManagementMock();
            IUnitCommand<Atribute> service = new AtributeService(mock);
            IUnitQuery<Atribute> queryService = new AtributeService(mock);
            
            Atribute g = new Atribute(1, "new Atribute");
            service.Add(g);

            var result = queryService.GetSinglePosition(g.Name);
            result.Name = "new atribute name";

            service.Edit(result);

            result = queryService.GetSinglePosition(result.Name);

            Assert.Equal("new atribute name", result.Name);
        }
    }
}
