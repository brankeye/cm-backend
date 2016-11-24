using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class MembersController : CoreController<Data.Member>
    {
        public override Response Post(Data.Member item)
        {
            item.School = null;
            item.Profile = null;
            return base.Post(item);
        }
    }
}