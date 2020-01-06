using HomeBudgetManager.Common.Models;
using System.Collections.Generic;

namespace HomeBudgetManager.Common.Services.Abstracts
{
    public interface IBankTransactionManager
    {
        IList<BaseUnit> ConvertToBaseUnit(ref IList<Atribute> atributes);
    }
}