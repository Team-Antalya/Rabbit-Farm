namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class FeedingController : RabbitFarmBaseApiController<Feeding, FeedingModel>
    {
        public FeedingController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
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
    }
}
