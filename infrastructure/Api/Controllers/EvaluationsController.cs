using System;
using System.Linq;
using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;
using cm.backend.infrastructure.Database.Content;
using Microsoft.AspNet.Identity;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class EvaluationsController : CoreController<Data.Evaluation>
    {
        public override Response Get()
        {
            var currentMember = GetCurrentMember();

            var evaluationsRepository = new Repository<Data.Evaluation>();
            var response = new Response();
            if (currentMember.IsTeacher)
            {
                // get all evaluations for the school
                var schoolId = currentMember.School.Id;
                response.Item = evaluationsRepository.All().Where(x => x.Member.SchoolId == schoolId);
            }
            else
            {
                // get all evaluations for only this user
                var memberId = currentMember.Id;
                response.Item = evaluationsRepository.All().Where(x => x.MemberId == memberId);
            }

            return response;
        }

        public override Response Post(Data.Evaluation item)
        {
            item.Date = item.Date.UtcDateTime.Date;

            var time = item.Time;
            item.Time = new DateTimeOffset(1, 1, 1, time.Hour, time.Minute, time.Second, TimeSpan.Zero);

            item.Member = null;

            return base.Post(item);
        }
    }
}