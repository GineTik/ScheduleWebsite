using System.Linq.Expressions;

namespace ScheduleWebSite.Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        List<T> GetList();
        List<T> GetList(Expression<Func<T, bool>> predicate);
        T GetItem(Guid id);
        T AddItem(T item);
        void UpdateItem(T item);
    }
}
