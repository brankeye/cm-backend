using System.Linq;
using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;
using cm.backend.infrastructure.Database.Content;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class UsersController : CoreController<Data.User>
    {
        public override Response Get()
        {
            var usersRepository = new Repository<Data.User>();
            var currentUser = GetCurrentUser();
            var response = new Response()
            {
                Item = usersRepository.All().Where(x => x.Id == currentUser.Id)
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