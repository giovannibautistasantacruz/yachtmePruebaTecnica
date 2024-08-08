using PruebaYachtme.Models.Generics;
using System.Linq.Expressions;

namespace PruebaYachtme.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        PagedList<T> GetALLXPage(PagedParams paramsData, Expression<Func<T, bool>>? filter = null, string? includeProperties = null);

        Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null);

        Task Delete(T entity);

        Task Save();
    }
}
