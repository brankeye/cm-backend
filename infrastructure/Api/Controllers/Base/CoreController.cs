using System.Web.Http;
using cm.backend.domain.Data.Interfaces;
using cm.backend.domain.Data.Objects;
using cm.backend.infrastructure.Database.Content;

namespace cm.backend.infrastructure.Api.Controllers.Base
{
    public class CoreController<TModel> : ApiController
        where TModel : class, IEntity
    {
        protected Repository<TModel> Repository => new Repository<TModel>();

        [HttpGet]
        public virtual Response Get()
        {
            var response = new Response
            {
                Item = Repository.All()
            };
            return response;
        }

        [HttpGet]
        public virtual Response Get(int id)
        {
            var response = Repository.FindById(id);
            return response;
        }

        [HttpPost]
        public virtual Response Post([FromBody] TModel item)
        {
            var response = new Response();

            if (ModelState.IsValid)
            {
                response = Repository.InsertOrUpdate(item);
            }

            return response;
        }

        [HttpDelete]
        public virtual Response Delete(int id)
        {
            var response = Repository.Delete(id);
            return response;
        }
    }
}