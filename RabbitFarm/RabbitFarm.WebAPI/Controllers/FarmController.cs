namespace RabbitFarm.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class FarmController : RabbitFarmBaseApiController
    {
        public FarmController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var farms = this.data.Farms.All();
            var farmsModelView = Mapper.Map<ICollection<FarmModel>>(farms);

            return Ok(farmsModelView);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var farm = this.data.Farms.Find(id);
            if (farm == null)
            {
                return BadRequest("No farm with this id!");
            }
            var farmModelView = Mapper.Map<FarmModel>(farm);
            return Ok(farmModelView);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, [FromBody]FarmModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var farmInDb = this.data.Farms.Find(id);
            var farm = Mapper.Map<Farm>(obj);
            farmInDb.Name = farm.Name;
            this.data.SaveChanges();
            return Ok("Farm updated!");
        }

        [HttpPost]
        public IHttpActionResult Add(FarmModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }
            var farm = Mapper.Map<Farm>(obj);
            this.data.Farms.Add(farm);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var farmInDb = this.data.Farms.Find(id);
            if (farmInDb == null)
            {
                return BadRequest("No farm with given id found!");
            }
            this.data.Farms.Delete(farmInDb);
            this.data.SaveChanges();
            return Ok("Farm deleted!");
        }
    }
}
