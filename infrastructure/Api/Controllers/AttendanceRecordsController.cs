using System.Linq;
using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;
using cm.backend.infrastructure.Database.Content;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class AttendanceRecordsController : CoreController<Data.AttendanceRecord>
    {
        public override Response Get()
        {
            var attendanceRecordsRepository = new Repository<Data.AttendanceRecord>();
            var currentSchool = GetCurrentSchool();
            var response = new Response
            {
                Item = attendanceRecordsRepository.All().Where(x => x.Class.SchoolId == currentSchool.Id)
            };

            return response;
        }

        public override Response Post(Data.AttendanceRecord item)
        {
            item.Date = item.Date.UtcDateTime.Date;
            item.Class = null;
            item.Profile = null;
            return base.Post(item);
        }
    }
}