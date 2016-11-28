using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;
using cm.backend.infrastructure.Database.Content;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class ProfilesController : CoreController<Data.Profile>
    {
        public override Response Get()
        {
            var membersRepository = new Repository<Data.Member>();
            var currentSchool = GetCurrentSchool();
            var schoolId = currentSchool.Id;
            var profiles = membersRepository.All().Where(x => x.SchoolId == schoolId).Select(x => x.Profile);
            var response = new Response
            {
                Item = profiles
            };
            return response;
        }

        public override Response Post(Data.Profile item)
        {
            item.StartDate = item.StartDate.UtcDateTime.Date;
            return base.Post(item);
        }
    }
}