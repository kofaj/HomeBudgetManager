using HomeBudgetManager.Repository.Services.Abstract;
using HomeBudgetManager.Common.Models;
using System.Collections.Generic;
using System.Linq;
using HomeBudgetManager.Common.Services.Abstracts;

namespace HomeBudgetManager.Common.Tests.Mock
{
    public class GroupUnitManagerMock : IUnitManager<Group>
    {
        public static IList<Group> mockDb;

        public GroupUnitManagerMock()
        {
            mockDb = new List<Group>();
        }

        public void Add(Group group)
        {
            mockDb.Add(group);
        }

        public void Edit(Group group)
        {
            var p = mockDb.First(f => f.GroupId == group.GroupId);

            mockDb.Remove(p);

            p.Name = group.Name;
            p.Atributes = group.Atributes;

            mockDb.Add(p);
        }

        public IList<Group> GetAllPositions()
        {
            return mockDb;
        }

        public Group GetSinglePosition(string name)
        {
            return mockDb.FirstOrDefault(f => f.Name == name);
        }

        public bool IsAlreadySaved(string name)
        {
            return mockDb.Any(a => a.Name == name);
        }

        public void Remove(string groupName)
        {
            var p = mockDb.FirstOrDefault(f => f.Name == groupName);
            if(!p.Equals(default(Group)) )
            {
                mockDb.Remove(p);
            }
        }
    }
}
