using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using RabbitFarm.Data;
using RabbitFarm.Models;
using RabbitFarm.WebAPI.DataModels;
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
            var feedings = this.data.Feedings.All();
            var feedingsModelView = Mapper.Map<FeedingModel>(feedings);

            return Ok(feedingsModelView);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var feeding = this.data.Feedings.Find(id);
            if (feeding == null)
            {
                return BadRequest("No Feeding with this id!");
            }
            var feedingModelView = Mapper.Map<FeedingModel>(feeding);
            return Ok(feedingModelView);
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
            var feedingModelView = Mapper.Map<FeedingModel>(newFeeding);
            return Ok(feedingModelView);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Feeding obj)
        {
            this.data.Feedings.Delete(obj);
            return Ok("Feeding deleted!");
        }
    }
}
