
namespace HomeBudgetManager.Common.Services.Abstracts
{
    public interface IUnitCommand<T>
    {
        void Add(T group);
        void Edit(T group);
        void Remove(string groupName);       
    }
}
