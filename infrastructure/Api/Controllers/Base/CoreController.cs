using System.Web.Http;
using cm.backend.domain.Data.Database;
using cm.backend.domain.Data.Interfaces;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Database.Content;
using Microsoft.AspNet.Identity;

namespace cm.backend.infrastructure.Api.Controllers.Base
{
    public class CoreController<TModel> : ApiController
        where TModel : class, IEntity
    {
        protected virtual Data.User GetCurrentUser()
        {
            var username = RequestContext.Principal.Identity.GetUserName();
            var usersRepository = new Repository<Data.User>();
            var currentUser = usersRepository.FindItem(x => x.Username == username);
            return currentUser;
        }

        protected virtual Data.Member GetCurrentMember()
        {
            var membersRepository = new Repository<Data.Member>();
            var currentUser = GetCurrentUser();
            var currentMember = membersRepository.FindItem(x => x.ProfileId == currentUser.ProfileId);
            return currentMember;
        }

        protected virtual Data.School GetCurrentSchool()
        {
            var currentMember = GetCurrentMember();
            return currentMember.School;
        }

        [HttpGet]
        public virtual Response Get()
        {
            var repository = new Repository<TModel>();
            var response = new Response
            {
                Item = repository.All()
            };
            return response;
        }

        [HttpGet]
        public virtual Response Get(int id)
        {
            var repository = new Repository<TModel>();
            var response = repository.FindById(id);
            return response;
        }

        [HttpPost]
        public virtual Response Post([FromBody] TModel item)
        {
            var response = new Response();
            var repository = new Repository<TModel>();
            if (ModelState.IsValid)
            {
                response = repository.InsertOrUpdate(item);
            }

            return response;
        }

        [HttpDelete]
        public virtual Response Delete(int id)
        {
            var repository = new Repository<TModel>();
            var response = repository.Delete(id);
            return response;
        }
    }
}