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
    public class LitterController : RabbitFarmBaseApiController
    {
        public LitterController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.data.Litters.All());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var litter = this.data.Litters.Find(id);
            if (litter == null)
            {
                return BadRequest("No Litter with this id!");
            }
            return Ok(litter);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Litter obj)
        {
            this.data.Litters.Update(obj);
            return Ok("Litter updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Litter obj)
        {
            var newLitter = this.data.Litters.Add(obj);
            return Ok(newLitter);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Litter obj)
        {
            this.data.Litters.Delete(obj);
            return Ok("Litter deleted!");
        }
    }
}
