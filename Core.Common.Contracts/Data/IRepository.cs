
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Contracts.Data
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        T FindById(int id);
        void Remove(int id);
        void Remove(T entity);
        void Add(T entity);
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);

    }
}
