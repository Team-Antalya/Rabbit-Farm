namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;
    
    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class RabbitController : RabbitFarmBaseApiController
    {
        public RabbitController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var rabbit = this.data.Rabbits.All();
            var rabbitsViewModel = Mapper.Map<RabbitModel>(rabbit);

            return Ok(rabbitsViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var rabbit = this.data.Rabbits.Find(id);
            if (rabbit == null)
            {
                return BadRequest("No Rabbit with this id!");
            }

            var rabbitViewModel = Mapper.Map<RabbitModel>(rabbit);
            return Ok(rabbitViewModel);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Rabbit obj)
        {
            this.data.Rabbits.Update(obj);
            return Ok("Rabbit updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Rabbit obj)
        {
            var newRabbit = this.data.Rabbits.Add(obj);
            var newRabbitViewModel = Mapper.Map<RabbitModel>(newRabbit);

            return Ok(newRabbitViewModel);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Rabbit obj)
        {
            this.data.Rabbits.Delete(obj);
            return Ok("Rabbit deleted!");
        }
    }
}
