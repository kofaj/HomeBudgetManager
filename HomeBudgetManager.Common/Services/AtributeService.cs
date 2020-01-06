using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Repository.Services.Abstract;
using System.Collections.Generic;

namespace HomeBudgetManager.Common.Services
{
    public class AtributeService : IUnitCommand<Atribute>, IUnitQuery<Atribute>, IUnitValidation, IUnitQueryExtension<Atribute>
    {
        private readonly IUnitManager<Atribute> _repo;
        private readonly IUnitManagerExtension<Atribute> _extendedRepo;

        public AtributeService(IUnitManager<Atribute> repo, IUnitManagerExtension<Atribute> extendedRepo)
        {
            _repo = repo;
            _extendedRepo = extendedRepo;
        }

        public void Add(Atribute group)
        {
            _repo.Add(group);
        }

        public void Edit(Atribute group)
        {
            _repo.Edit(group);
        }

        public IList<Atribute> GetAllPositions()
        {
            return _repo.GetAllPositions();
        }

        public IList<Atribute> GetPositions(int[] positionIds)
        {
            return _extendedRepo.GetPositions(positionIds);
        }

        public Atribute GetSinglePosition(string name)
        {
            return _repo.GetSinglePosition(name);
        }

        public bool IsNameAlreadyExists(string uIGroupName)
        {
            return _repo.IsAlreadySaved(uIGroupName);
        }

        public void Remove(string groupId)
        {
            _repo.Remove(groupId);
        }
    }
}
