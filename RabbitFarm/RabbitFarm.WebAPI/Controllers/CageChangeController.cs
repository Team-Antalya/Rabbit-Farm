namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;
    
    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class CageChangeController : RabbitFarmBaseApiController<CageChange, CageChangeModel>
    {
        public CageChangeController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CageChangeModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var cageChangeInDb = this.data.CageChanges.Find(id);
            if (cageChangeInDb == null)
            {
                return BadRequest("No CageChange with the given id found!");
            }
            var cageChange = Mapper.Map<CageChange>(obj);
            cageChangeInDb.StartingDate = cageChange.StartingDate;
            cageChangeInDb.RabbitId = cageChange.RabbitId;
            cageChangeInDb.FarmId = cageChange.FarmId;
            this.data.SaveChanges();
            return Ok("CageChange updated!");
        }
    }
}
