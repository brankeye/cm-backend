using System;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    public class EvaluationsController : CoreController<Data.Evaluation>
    {
        public override Response Post(Data.Evaluation item)
        {
            item.Date = item.Date.Date;

            var time = item.Time;
            item.Time = new DateTime(1, 1, 1, time.Hour, time.Minute, time.Second, DateTimeKind.Utc);

            return base.Post(item);
        }
    }
}