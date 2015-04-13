namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class FarmController : RabbitFarmBaseApiController
    {
        public FarmController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {

        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var farms = this.data.Farms.All();
            var farmsModelView = Mapper.Map<FarmModel>(farms);

            return Ok(farmsModelView);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var farm = this.data.Farms.Find(id);
            if (farm == null)
            {
                return BadRequest("No acquisition with this id!");
            }
            return Ok(farm);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Farm obj)
        {
            this.data.Farms.Update(obj);
            return Ok("Farm updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Farm obj)
        {
            var newFarm = this.data.Farms.Add(obj);
            return Ok(newFarm);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Farm obj)
        {
            this.data.Farms.Delete(obj);
            return Ok("Farm deleted!");
        }
    }
}
