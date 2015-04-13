using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RabbitFarm.Data;
using RabbitFarm.Models;
using RabbitFarm.WebAPI.DataModels;
using RabbitFarm.WebAPI.Infrastructure;

namespace RabbitFarm.WebAPI.Controllers
{
    public class CageController : RabbitFarmBaseApiController
    {
        public CageController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.data.Cages.All());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cage = this.data.Cages.Find(id);
            if (cage == null)
            {
                return BadRequest("No cage with this id!");
            }
            return Ok(cage);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Cage obj)
        {
            this.data.Cages.Update(obj);
            return Ok("Cage updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Cage obj)
        {
            var newCage = this.data.Cages.Add(obj);
            return Ok(newCage);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Cage obj)
        {
            this.data.Cages.Delete(obj);
            return Ok("Cage deleted!");
        }
    }
}
