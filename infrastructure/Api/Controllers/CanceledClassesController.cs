using System.Linq;
using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;
using cm.backend.infrastructure.Database.Content;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class CanceledClassesController : CoreController<Data.CanceledClass>
    {
        public override Response Get()
        {
            var canceledClassesRepository = new Repository<Data.CanceledClass>();
            var currentSchool = GetCurrentSchool();
            var schoolId = currentSchool.Id;
            var response = new Response
            {
                Item = canceledClassesRepository.All().Where(x => x.Class.SchoolId == schoolId)
            };

            return response;
        }

        public override Response Post(Data.CanceledClass item)
        {
            item.Date = item.Date.UtcDateTime.Date;
            item.Class = null;
            return base.Post(item);
        }
    }
}