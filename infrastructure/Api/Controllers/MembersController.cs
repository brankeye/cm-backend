using System.Linq;
using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;
using cm.backend.infrastructure.Database.Content;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class MembersController : CoreController<Data.Member>
    {
        public override Response Get()
        {
            var membersRepository = new Repository<Data.Member>();
            var currentSchool = GetCurrentSchool();
            var schoolId = currentSchool.Id;
            var response = new Response
            {
                Item = membersRepository.All().Where(x => x.SchoolId == schoolId)
            };

            return response;
        }

        public override Response Post(Data.Member item)
        {
            item.School = null;
            item.Profile = null;
            return base.Post(item);
        }
    }
}