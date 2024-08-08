using Microsoft.EntityFrameworkCore;
using PruebaAxen_CasaBolsa.Data;
using PruebaYachtme.Models.Generics;
using PruebaYachtme.Repository.IRepository;
using System.Linq.Expressions;
using System.Linq;

namespace PruebaYachtme.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }
        public async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await Save();
        }

        public async Task Delete(T entity)
        {
            dbSet.Remove(entity);
            await Save();
        }

        public async Task<T> Get(Expression<Func<T, bool>> filter = null, bool tracked = true, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)  // "Villa,OtroModelo"
            {
                foreach (var incluirProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)  // "Villa,OtroModelo"
            {
                foreach (var incluirProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }
            return await query.ToListAsync();
        }

        public PagedList<T> GetALLXPage(PagedParams paramsData, Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)  // "Villa,OtroModelo"
            {
                foreach (var incluirProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }
            return PagedList<T>.ToPagedList(query, paramsData.PageNumber, paramsData.PageSize);
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            dbSet.Update(entity);
            await Save();
        }
    }
}
