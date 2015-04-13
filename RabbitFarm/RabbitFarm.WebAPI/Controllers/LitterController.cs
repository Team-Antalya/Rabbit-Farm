using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using RabbitFarm.Data;
using RabbitFarm.Models;
using RabbitFarm.WebAPI.DataModels;
using RabbitFarm.WebAPI.Infrastructure;
using System.Data.Entity;

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
            var litters = this.data.Litters.All().Include(a => a.Farm);
            var littersViewModel = Mapper.Map<LitterModel>(litters);
            return Ok(littersViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var litter = this.data.Litters.Find(id);
            if (litter == null)
            {
                return BadRequest("No Litter with this id!");
            }
            var litterViewModel = Mapper.Map<LitterModel>(litter);
            return Ok(litterViewModel);
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
            var litterViewModel = Mapper.Map<LitterModel>(newLitter);
            return Ok(litterViewModel);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Litter obj)
        {
            this.data.Litters.Delete(obj);
            return Ok("Litter deleted!");
        }
    }
}
