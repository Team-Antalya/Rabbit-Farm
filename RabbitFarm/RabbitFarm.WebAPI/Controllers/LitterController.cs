namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class LitterController : RabbitFarmBaseApiController<Litter, LitterModel>
    {
        public LitterController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpPut]
        public IHttpActionResult Update(int id, LitterModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var litterInDb = this.data.Litters.Find(id);
            if (litterInDb == null)
            {
                return BadRequest("No Litter with the given id found!");
            }
            var litter = Mapper.Map<Litter>(obj);
            litterInDb.BirthDate = litter.BirthDate;
            litterInDb.MotherId = litter.MotherId;
            litterInDb.FatherId = litter.FatherId;
            litterInDb.FarmId = litter.FarmId;
            this.data.SaveChanges();
            return Ok("Litter updated!");
        }
    }
}
