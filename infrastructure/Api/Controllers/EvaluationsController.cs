using System;
using System.Linq;
using System.Web;
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
        /*
        public override Response Get()
        {
            var username = RequestContext.Principal.Identity.GetUserName();
            var users = new Repository<Data.User>();
            var currentUser = users.Find(x => x.Username == username).Item;
            var user = (Data.User) currentUser;
            var response = new Response
            {
                Item = Repository.All().FirstOrDefault(x => x.ProfileId == user.ProfileId)
            };
            return response;
        }
        */

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