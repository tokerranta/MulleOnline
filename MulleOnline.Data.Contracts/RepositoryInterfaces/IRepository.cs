using Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MulleOnline.Data.Contracts.RepositoryInterfaces
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
