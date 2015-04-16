namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class FarmController : RabbitFarmBaseApiController<Farm, FarmModel>
    {
        public FarmController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]FarmModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var farmInDb = this.data.Farms.Find(id);
            if (farmInDb == null)
            {
                return BadRequest("No farm with given id found!");
            }
            var farm = Mapper.Map<Farm>(obj);
            farmInDb.Name = farm.Name;
            this.data.SaveChanges();
            return Ok("Farm updated!");
        }
    }
}
