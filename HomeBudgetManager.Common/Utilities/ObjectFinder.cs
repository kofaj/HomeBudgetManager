using HomeBudgetManager.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeBudgetManager.Common.Utilities
{
    public static class ObjectFinder
    {
        public static Atribute GetFitAtribute(ref IList<Atribute> atr, string name)
        {
            if (!atr.Any())
                return default;

            var result = atr.FirstOrDefault(f => name.ToUpper().Contains(f.Name.ToUpper()));

            return result;
        }
    }
}
