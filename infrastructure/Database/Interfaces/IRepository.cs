using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using cm.backend.domain.Data.Objects;

namespace cm.backend.infrastructure.Database.Interfaces
{
    public interface IRepository<TModel>
        where TModel : class
    {
        IQueryable<TModel> All();

        IQueryable<TModel> AllIncluding(params Expression<Func<TModel, object>>[] includeProperties);

        IQueryable<TModel> Find(Expression<Func<TModel, bool>> predicate);

        Response FindById(int id);

        Response InsertOrUpdate(TModel item);

        Response Delete(int id);

        Response Save();

        void Dispose();
    }
}
