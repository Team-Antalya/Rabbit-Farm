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
    public class RealizationController : RabbitFarmBaseApiController
    {
        public RealizationController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.data.Realizations.All());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var realization = this.data.Realizations.Find(id);
            if (realization == null)
            {
                return BadRequest("No Realization with this id!");
            }
            return Ok(realization);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Realization obj)
        {
            this.data.Realizations.Update(obj);
            return Ok("Realization updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Realization obj)
        {
            var newRealization = this.data.Realizations.Add(obj);
            return Ok(newRealization);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Realization obj)
        {
            this.data.Realizations.Delete(obj);
            return Ok("Realization deleted!");
        }
    }
}
