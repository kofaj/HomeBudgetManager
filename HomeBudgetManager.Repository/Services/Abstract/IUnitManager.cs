using System;
using System.Collections.Generic;
using System.Text;

namespace HomeBudgetManager.Repository.Services.Abstract
{
    public interface IUnitManager<T>
    {
        void Add(T group);
        void Edit(T group);
        void Remove(string groupName);
        IList<T> GetAllPositions();
        T GetSinglePosition(string name);
        bool IsAlreadySaved(string name);
    }
}
