using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class ProfilesController : CoreController<Data.Profile>
    {
        public override Response Post(Data.Profile item)
        {
            item.StartDate = item.StartDate.UtcDateTime.Date;
            return base.Post(item);
        }
    }
}