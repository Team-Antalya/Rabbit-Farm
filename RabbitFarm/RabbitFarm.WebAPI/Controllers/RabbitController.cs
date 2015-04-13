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
    public class RabbitController : RabbitFarmBaseApiController
    {
        public RabbitController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.data.Rabbits.All());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var rabbit = this.data.Rabbits.Find(id);
            if (rabbit == null)
            {
                return BadRequest("No Rabbit with this id!");
            }
            return Ok(rabbit);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Rabbit obj)
        {
            this.data.Rabbits.Update(obj);
            return Ok("Rabbit updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Rabbit obj)
        {
            var newRabbit = this.data.Rabbits.Add(obj);
            return Ok(newRabbit);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Rabbit obj)
        {
            this.data.Rabbits.Delete(obj);
            return Ok("Rabbit deleted!");
        }
    }
}
