using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Repository.Services.Abstract;
using HomeBudgetManager.Common.Tests.Mock;
using System.Collections.Generic;
using Xunit;

namespace HomeBudgetManager.Common.Tests.ServiceTests
{
    public class GroupServiceTests
    {
        [Fact]
        public void AddNewGroup()
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
            service.Add(g);

            var result = queryService.GetAllPositions();

            Assert.NotEmpty(result);
            Assert.Equal(tName, result[0].Name);
            Assert.Equal(atributes[0].Name, result[0].Atributes[0].Name);
            Assert.Equal(atributes[1].Name, result[0].Atributes[1].Name);
        }

        [Fact]
        public void EditGroup()
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
            service.Add(g);

            var result = queryService.GetSinglePosition(g.Name);
            
            result.Name = "new test name";
            service.Edit(result);

            var result2 = queryService.GetSinglePosition(result.Name);

            Assert.NotEqual(default, result);
            Assert.Equal(result2, result);
        }

        [Fact]
        public void RemoveGroup()
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
            service.Add(g);
            var collection = queryService.GetAllPositions();

            Assert.NotEmpty(collection);

            service.Remove(g.Name);
            collection = queryService.GetAllPositions();

            Assert.Empty(collection);
        }

        [Fact]
        public void GetAllGroupPositions()
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
