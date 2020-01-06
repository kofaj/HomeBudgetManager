using System.Collections.Generic;

namespace HomeBudgetManager.Common.Services.Abstracts
{
    public interface IUnitQuery<T>
    {
        IList<T> GetAllPositions();
        T GetSinglePosition(string name);
    }
}
