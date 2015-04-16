namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class CageController : RabbitFarmBaseApiController<Cage, CageModel>
    {
        public CageController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }
        
        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]CageModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var cageInDb = this.data.Cages.Find(id);
            if (cageInDb == null)
            {
                return BadRequest("No cage with given id found!");
            }
            var cage = Mapper.Map<Cage>(obj);
            cageInDb.Width= cage.Width;
            cageInDb.Height = cage.Height;
            cageInDb.Length = cage.Length;
            cageInDb.FarmId = cage.FarmId;
            this.data.SaveChanges();
            return Ok("Cage updated!");
        }
    }
}
