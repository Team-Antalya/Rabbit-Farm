namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class RealizationController : RabbitFarmBaseApiController<Realization, RealizationModel>
    {
        public RealizationController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpPut]
        public IHttpActionResult Update(int id, RealizationModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var realizationInDb = this.data.Realizations.Find(id);
            if (realizationInDb == null)
            {
                return BadRequest("No Realization with the given id found!");
            }
            var realization = Mapper.Map<Realization>(obj);
            realizationInDb.RealizationDate = realization.RealizationDate;
            realizationInDb.RealizationChannel = realization.RealizationChannel;
            realizationInDb.RabbitId = realization.RabbitId;
            realizationInDb.LiveWeight = realization.LiveWeight;
            realizationInDb.Price = realization.Price;
            realizationInDb.FarmId = realization.FarmId;
            this.data.SaveChanges();
            return Ok("Realization updated!");
        }
    }
}
