using System;
using System.Linq;

namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.WebAPI.Infrastructure;

    public class RabbitFarmBaseApiController<T> : ApiController where T : class 
    {
        protected RabbitFarmData data;
        protected IUserProvider userProvider;       

        public RabbitFarmBaseApiController(RabbitFarmData data, IUserProvider userProvider)
        {
            this.data = data;
            this.userProvider = userProvider;
        }
        [HttpGet]
        public virtual IHttpActionResult All()
        {
            return Ok(this.data.GetRepository<T>().All());
        }

        [HttpGet]
        public virtual IHttpActionResult Get(int id)
        {
            var entity = this.data.GetRepository<T>().Find(id);
            if (entity == null)
            {
                return BadRequest("No element with the requested id!");
            }
            return Ok(this.data.GetRepository<T>().Find(id));
        }

        [HttpPut]
        public virtual IHttpActionResult Update(T obj)
        {
            this.data.GetRepository<T>().Update(obj);
            return Ok("Object updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(T obj)
        {
            var newObj = this.data.GetRepository<T>().Add(obj);
            return Ok(newObj);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(T obj)
        {
            this.data.GetRepository<T>().Delete(obj);
            return Ok("Object deleted!");
        }
    }
}