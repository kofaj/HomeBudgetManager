using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Repository.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetManager.Common.Services
{
    public class AtributeService : IUnitCommand<Atribute>, IUnitQuery<Atribute>, IUnitValidation
    {
        private readonly IUnitManager<Atribute> _repo;

        public AtributeService(IUnitManager<Atribute> repo)
        {
            _repo = repo;
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
