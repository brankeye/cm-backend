using System;
using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class EvaluationsController : CoreController<Data.Evaluation>
    {
        public override Response Post(Data.Evaluation item)
        {
            item.Date = item.Date.Date;

            var time = item.Time;
            item.Time = new DateTime(1, 1, 1, time.Hour, time.Minute, time.Second, DateTimeKind.Utc);

            item.Profile = null;

            return base.Post(item);
        }
    }
}