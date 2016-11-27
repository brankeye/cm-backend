using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class AttendanceRecordsController : CoreController<Data.AttendanceRecord>
    {
        public override Response Post(Data.AttendanceRecord item)
        {
            item.Date = item.Date.UtcDateTime.Date;
            item.Class = null;
            item.Profile = null;
            return base.Post(item);
        }
    }
}