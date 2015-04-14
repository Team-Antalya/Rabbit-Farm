namespace RabbitFarm.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class FeedingController : RabbitFarmBaseApiController
    {
        public FeedingController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var feedings = this.data.Feedings.All();
            var feedingsModelView = Mapper.Map<ICollection<FeedingModel>>(feedings);

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
        public IHttpActionResult Update(int id, FeedingModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var feedingInDb = this.data.Feedings.Find(id);
            if (feedingInDb == null)
            {
                return BadRequest("No Feeding with the given id found!");
            }
            var feeding = Mapper.Map<Feeding>(obj);
            feedingInDb.FeedingDate = feeding.FeedingDate;
            feedingInDb.Amount = feeding.Amount;
            feedingInDb.CageId = feeding.CageId;
            feedingInDb.FarmId = feeding.FarmId;
            feedingInDb.PurchaseId = feeding.PurchaseId;
            this.data.SaveChanges();
            return Ok("Feeding updated!");
        }

        [HttpPost]
        public IHttpActionResult Add(FeedingModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var feeding = Mapper.Map<Feeding>(obj);
            this.data.Feedings.Add(feeding);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var feedingInDb = this.data.Feedings.Find(id);
            if (feedingInDb == null)
            {
                return BadRequest("No Feeding with the given id found!");
            }
            this.data.Feedings.Delete(feedingInDb);
            this.data.SaveChanges();
            return Ok("Feeding deleted!");
        }
    }
}
