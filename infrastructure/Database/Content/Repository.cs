using cm.backend.domain.Data.Interfaces;
using cm.backend.infrastructure.Database.Services;

namespace cm.backend.infrastructure.Database.Content
{
    public class Repository<TModel> : EFRepository<infrastructure.Database.Domain.Context, TModel>
        where TModel : class, IEntity
    { }
}
