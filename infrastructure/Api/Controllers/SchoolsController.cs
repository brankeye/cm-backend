using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;
using cm.backend.infrastructure.Database.Content;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class SchoolsController : CoreController<Data.School>
    {
        public override Response Get()
        {
            var currentSchool = GetCurrentSchool();
            var response = new Response()
            {
                Item = currentSchool
            };
            return response;
        }

        [HttpGet]
        [Route("api/Schools/{schoolName}")]
        public virtual Response Get(string schoolName)
        {
            var schoolsRepository = new Repository<Data.School>();
            var response = schoolsRepository.Find(x => x.Name == schoolName);
            return response;
        }
    }
}