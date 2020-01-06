using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Common.Tests.Mock;
using HomeBudgetManager.Repository.Services.Abstract;
using System.Collections.Generic;
using Xunit;

namespace HomeBudgetManager.Common.Tests.ServiceTests
{
    public class AtributeServiceTests
    {
        [Fact]
        public void AddNewAtribute()
        {
            IUnitManager<Atribute> mock = new AtributeUnitManagementMock();
            IUnitManagerExtension<Atribute> mockExt = new AtributeUnitManagementMock();
            IUnitCommand<Atribute> service = new AtributeService(mock, mockExt);
            IUnitQuery<Atribute> queryService = new AtributeService(mock, mockExt);

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
            IUnitManagerExtension<Atribute> mockExt = new AtributeUnitManagementMock();
            IUnitCommand<Atribute> service = new AtributeService(mock, mockExt);
            IUnitQuery<Atribute> queryService = new AtributeService(mock, mockExt);

            Atribute g = new Atribute(1, "new Atribute");
            service.Add(g);

            var result = queryService.GetSinglePosition(g.Name);
            result.Name = "new atribute name";

            service.Edit(result);

            result = queryService.GetSinglePosition(result.Name);

            Assert.Equal("new atribute name", result.Name);
        }

        [Fact]
        public void RemoveAtribute()
        {
            IUnitManager<Atribute> mock = new AtributeUnitManagementMock();
            IUnitManagerExtension<Atribute> mockExt = new AtributeUnitManagementMock();
            IUnitCommand<Atribute> service = new AtributeService(mock, mockExt);
            IUnitQuery<Atribute> queryService = new AtributeService(mock, mockExt);

            int atributeId = 1;
            string tName = "new Atribute";
            Atribute g = new Atribute(atributeId, tName);
            service.Add(g);

            var result = queryService.GetAllPositions();

            Assert.NotEmpty(result);

            service.Remove(g.Name);
            result = queryService.GetAllPositions();

            Assert.Empty(result);
        }

        [Fact]
        public void GetAllAtributePositions()
        {
            IUnitManager<Group> mock = new GroupUnitManagerMock();
            IUnitCommand<Group> service = new GroupService(mock);
            IUnitQuery<Group> queryService = new GroupService(mock);

            int groupId = 1;
            string tName = "new Group";
            IList<Atribute> atributes = new List<Atribute>()
            {
                {new Atribute(1, "Atribute 1") },
                {new Atribute(2, "Atribute 2") },
            };

            Group g = new Group(groupId, tName, atributes);

            int groupId2 = 2;
            string tName2 = "new Group2";
            IList<Atribute> atributes2 = new List<Atribute>()
            {
                {new Atribute(3,"Atribute 3") },
                {new Atribute(4,"Atribute 4") },
            };
            Group g2 = new Group(groupId2, tName2, atributes2);
            service.Add(g);
            service.Add(g2);

            var collection = queryService.GetAllPositions();

            Assert.NotEmpty(collection);
            Assert.Equal(2, collection.Count);
        }

        [Fact]
        public void AddDoubledGroup_returns_true()
        {
            IUnitManager<Group> mock = new GroupUnitManagerMock();
            IUnitCommand<Group> service = new GroupService(mock);
            IUnitValidation serviceValidation = new GroupService(mock);

            int groupId = 1;
            string tName = "new Group";
            IList<Atribute> atributes = new List<Atribute>()
            {
                {new Atribute(1, "Atribute 1") },
                {new Atribute(2, "Atribute 2") },
            };

            Group g = new Group(groupId, tName, atributes);

            service.Add(g);

            bool result = serviceValidation.IsNameAlreadyExists(g.Name);

            Assert.True(result);
        }
    }
}
