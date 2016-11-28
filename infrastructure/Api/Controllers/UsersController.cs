using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class UsersController : CoreController<Data.User>
    {
        public override Response Get()
        {
            var currentUser = GetCurrentUser();
            var response = new Response()
            {
                Item = currentUser
            };
            return response;
        }

        public override Response Post(Data.User item)
        {
            item.Profile = null;
            return base.Post(item);
        }
    }
}