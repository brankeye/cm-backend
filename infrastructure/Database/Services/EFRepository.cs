using System;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using cm.backend.domain.Data.Enums;
using cm.backend.domain.Data.Interfaces;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Database.Interfaces;

namespace cm.backend.infrastructure.Database.Services
{
    public abstract class EFRepository<TContext, TModel> : IRepository<TModel>
        where TContext : DbContext, new()
        where TModel : class, IEntity
    {
        public TContext Context { get; set; } = new TContext();

        public IQueryable<TModel> All()
        {
            var query = Context.Set<TModel>().AsQueryable();
            return query;
        }

        public IQueryable<TModel> AllIncluding(params Expression<Func<TModel, object>>[] includeProperties)
        {
            var query = Context.Set<TModel>().AsQueryable();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty)).AsQueryable();
            return query;
        }

        public IQueryable<TModel> Find(Expression<Func<TModel, bool>> predicate)
        {
            var query = Context.Set<TModel>().Where(predicate);
            return query;
        }

        public Response FindById(int id)
        {
            var response = new Response();

            var query = Context.Set<TModel>().Find(id);
            if (query != null)
            {
                response.Message = "Found";
                response.ResultCode = ResultCodes.RecordFound;
            }
            else
            {
                response.ResultCode = ResultCodes.RecordNotFound;
                response.Message = ResultCodes.RecordNotFound + ": could not find record matching id of " + id + ".";
            }

            response.Item = query;
            return response;
        }

        public Response InsertOrUpdate(TModel item)
        {
            var response = new Response();
            var isAdding = true;

            if (item.Id > 0)
            {
                Context.Entry(item).State = EntityState.Modified;
                isAdding = false;
            }
            else
            {
                Context.Set<TModel>().Add(item);
            }

            var saveResponse = Save();
            if (saveResponse.ResultCode == ResultCodes.SaveSuccessful)
            {
                if (isAdding)
                {
                    response.Message = ResultCodes.InsertSuccessful.ToString();
                    response.ResultCode = ResultCodes.InsertSuccessful;
                }
                else
                {
                    response.Message = ResultCodes.UpdateSuccessful.ToString();
                    response.ResultCode = ResultCodes.UpdateSuccessful;
                }

                response.Item = Context.Entry(item);
            }
            else
            {
                response.Message = ResultCodes.SaveFailed.ToString() + ": " + saveResponse.Message;
                response.ResultCode = saveResponse.ResultCode;
                response.Item = saveResponse.Item;
            }

            return response;
        }

        public Response Delete(int id)
        {
            var response = new Response();
            var entity = Context.Set<TModel>().Find(id);

            if (entity != null)
            {
                response.Item = entity;

                if (Context.Entry(entity).State == EntityState.Detached)
                {
                    Context.Set<TModel>().Attach(entity);
                }

                Context.Set<TModel>().Remove(entity);
                var saved = Save();
                response.ResultCode = saved.ResultCode;
                response.Message = saved.Message;
            }
            else
            {
                response.ResultCode = ResultCodes.RecordNotFound;
                response.Message = ResultCodes.RecordNotFound + ": could not find record matching id of " + id + ".";
            }
            
            return response;
        }

        public Response Save()
        {
            var result = new Response
            {
                ResultCode = ResultCodes.SaveSuccessful
            };

            try
            {
                var response = Context.SaveChanges();
                result.Item = response;
            }
            catch (Exception ex)
            {
                result.ResultCode = ResultCodes.SaveFailed;
                result.Message = ex.Message;
                result.Item = ex;
            }

            return result;
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
