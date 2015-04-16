namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class RabbitController : RabbitFarmBaseApiController<Rabbit, RabbitModel>
    {
        public RabbitController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpPut]
        public IHttpActionResult Update(int id, RabbitModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var rabbitInDb = this.data.Rabbits.Find(id);
            if (rabbitInDb == null)
            {
                return BadRequest("No Rabbit with the given id found!");
            }
            var rabbit = Mapper.Map<Rabbit>(obj);
            rabbitInDb.Mark = rabbit.Mark;
            rabbitInDb.Gender = rabbit.Gender;
            rabbitInDb.Status = rabbit.Status;
            rabbitInDb.LitterId = rabbit.LitterId;
            rabbitInDb.AcquisitionId = rabbit.AcquisitionId;
            rabbitInDb.FarmId = rabbit.FarmId;
            this.data.SaveChanges();
            return Ok("Rabbit updated!");
        }
    }
}