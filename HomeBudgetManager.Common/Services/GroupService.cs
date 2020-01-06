using HomeBudgetManager.Common.Models;
using HomeBudgetManager.Common.Services.Abstracts;
using HomeBudgetManager.Repository.Services.Abstract;
using System.Collections.Generic;

namespace HomeBudgetManager.Common.Services
{
    public class GroupService : IUnitCommand<Group>, IUnitQuery<Group>, IUnitValidation
    {
        private readonly IUnitManager<Group> _repo;

        public GroupService(IUnitManager<Group> repo)
        {
            _repo = repo;
        }

        public void Add(Group group)
        {
            _repo.Add(group);
        }

        public void Edit(Group group)
        {
            _repo.Edit(group);
        }

        public IList<Group> GetAllPositions()
        {
            return _repo.GetAllPositions();
        }

        public Group GetSinglePosition(string name)
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
