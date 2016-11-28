using System.Linq;
using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Api.Controllers.Base;
using cm.backend.infrastructure.Database.Content;

namespace cm.backend.infrastructure.Api.Controllers
{
    [Authorize]
    public class EvaluationSectionsController : CoreController<Data.EvaluationSection>
    {
        public override Response Get()
        {
            var currentMember = GetCurrentMember();

            var evaluationSectionsRepository = new Repository<Data.EvaluationSection>();
            var response = new Response();
            if (currentMember.IsTeacher)
            {
                // get all evaluations for the school
                var schoolId = currentMember.School.Id;
                response.Item = evaluationSectionsRepository.All().Where(x => x.Evaluation.Member.SchoolId == schoolId);
            }
            else
            {
                // get all evaluations for only this user
                var memberId = currentMember.Id;
                response.Item = evaluationSectionsRepository.All().Where(x => x.Evaluation.MemberId == memberId);
            }

            return response;
        }

        public override Response Post(Data.EvaluationSection item)
        {
            item.Evaluation = null;
            return base.Post(item);
        }
    }
}