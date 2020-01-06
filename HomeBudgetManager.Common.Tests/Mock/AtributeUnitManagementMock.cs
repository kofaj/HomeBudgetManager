using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Repository.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace HomeBudgetManager.Common.Tests.Mock
{
    public class AtributeUnitManagementMock : IUnitManager<Atribute>, IUnitManagerExtension<Atribute>
    {
        public static IList<Atribute> mockDb;

        public AtributeUnitManagementMock()
        {
            mockDb = new List<Atribute>();
        }

        public void Add(Atribute atribute)
        {
            mockDb.Add(atribute);
        }

        public void Edit(Atribute atribute)
        {
            var p = mockDb.First(f => f.AtributeId == atribute.AtributeId);

            mockDb.Remove(p);

            p.Name = atribute.Name;

            mockDb.Add(p);
        }

        public IList<Atribute> GetAllPositions()
        {
            return mockDb;
        }

        public IList<Atribute> GetPositions(int[] positionIds)
        {
            return mockDb.Where(w => positionIds.Any(a => a == w.AtributeId)).ToList();
        }

        public Atribute GetSinglePosition(string name)
        {
            return mockDb.FirstOrDefault(f => f.Name == name);
        }

        public bool IsAlreadySaved(string name)
        {
            return mockDb.Any(a => a.Name == name);
        }

        public void Remove(string atributeName)
        {
            var p = mockDb.FirstOrDefault(f => f.Name == atributeName);
            if (!p.Equals(default(Atribute)))
            {
                mockDb.Remove(p);
            }
        }
    }
}
