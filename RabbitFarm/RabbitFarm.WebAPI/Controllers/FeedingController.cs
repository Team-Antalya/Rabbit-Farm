using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RabbitFarm.Data;
using RabbitFarm.Models;
using RabbitFarm.WebAPI.Infrastructure;

namespace RabbitFarm.WebAPI.Controllers
{
    public class FeedingController : RabbitFarmBaseApiController
    {
        public FeedingController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {

        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.data.Feedings.All());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var feeding = this.data.Feedings.Find(id);
            if (feeding == null)
            {
                return BadRequest("No Feeding with this id!");
            }
            return Ok(feeding);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Feeding obj)
        {
            this.data.Feedings.Update(obj);
            return Ok("Feeding updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Feeding obj)
        {
            var newFeeding = this.data.Feedings.Add(obj);
            return Ok(newFeeding);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Feeding obj)
        {
            this.data.Feedings.Delete(obj);
            return Ok("Feeding deleted!");
        }
    }
}
