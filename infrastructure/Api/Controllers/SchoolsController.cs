using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class SchoolsController : CoreController<Data.School>
    {
        [HttpGet]
        [Route("api/Schools/{schoolName}")]
        public virtual Response Get(string schoolName)
        {
            var response = Repository.Find(x => x.Name == schoolName);
            return response;
        }
    }
}