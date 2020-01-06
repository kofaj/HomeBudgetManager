
namespace HomeBudgetManager.Common.Models
{
    public struct Atribute
    {
        public int AtributeId;
        public string Name;
        
        public Atribute(int atributeId, string name)
        {
            AtributeId = atributeId;
            Name = name;
        }
    }
}
