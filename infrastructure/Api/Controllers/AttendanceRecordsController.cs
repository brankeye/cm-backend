using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    public class AttendanceRecordsController : CoreController<Data.AttendanceRecord>
    {
        public override Response Post(Data.AttendanceRecord item)
        {
            item.Date = item.Date.Date;
            return base.Post(item);
        }
    }
}