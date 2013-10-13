using Core.Common.Contracts;
using Core.Common.Contracts.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Repositories
{
    public class GenericDataRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {

        private DbContext _context;
        private DbSet<TEntity> _set;

        public GenericDataRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
            _set = context.Set<TEntity>();
        }

        public TEntity FindById(int id)
        {
            return _set.Find(id);
        }

        public void Remove(int id)
        {
            var entityToRemove = FindById(id);
            Remove(entityToRemove);
        }

        public void Remove(TEntity entity)
        {
            _set.Remove(entity);
        }

        public void Add(TEntity entity)
        {
            _set.Add(entity);
        }

        public IEnumerable<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _set.Where(predicate).ToArray();
        }
    }
}
