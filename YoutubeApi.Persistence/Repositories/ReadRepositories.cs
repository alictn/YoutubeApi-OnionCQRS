using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using YoutubeApi.Application.Interfaces.Repositories;
using YoutubeApi.Domain.Common;

namespace YoutubeApi.Persistence.Repositories
{
    /* "where T : class=verilen 'T' parametresi bir class
     * "new()    : newlenebileceğini söylüyoruz 
     */
    public class ReadRepositories<T> : IReadRepositories<T> where T : class, IEntityBase, new()
    {
        private readonly DbContext _context;
        public ReadRepositories(DbContext dbContext)
        {
            this._context = dbContext;
        }

        private DbSet<T> Table { get => _context.Set<T>(); }


        public async Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,                          // Filtreleme şartı (örn:x=>x.IsActive)
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, // İlişkili tabloları dahil etme (örn:x=>x.Include(y => y.Category))
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,            // Sıralama (örn: x => x.OrderBy(y => y.Name))
            bool enableTracking = false                                           // EF Core takip etsin mi? Performans için genelde false
            )

        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();

            return await queryable.ToListAsync();
        }

        public async Task<IList<T>> GetAllByPagingAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);
            if (predicate is not null) queryable = queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();

            return await queryable.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<T> GetAsync(
            Expression<Func<T, bool>> predicate,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include is not null) queryable = include(queryable);

            //queryable.Where(predicate);

            return await queryable.FirstOrDefaultAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if (predicate is not null) Table.Where(predicate);

            return await Table.CountAsync();
        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking) Table.AsNoTracking();
            return Table.Where(predicate);
        }
    }
}
