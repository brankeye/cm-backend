using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class EvaluationSectionsController : CoreController<Data.EvaluationSection>
    {
        public override Response Post(Data.EvaluationSection item)
        {
            item.Evaluation = null;
            return base.Post(item);
        }
    }
}