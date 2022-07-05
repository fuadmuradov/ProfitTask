using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Profit.Core.IRepositories
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> exp);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> exp);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> exp);
        void Remove(TEntity entity);
        Task<int> SaveDbAsync();
        int SaveDb();
    }
}
