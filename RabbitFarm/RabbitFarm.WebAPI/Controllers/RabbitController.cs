namespace RabbitFarm.WebAPI.Controllers
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class RabbitController : RabbitFarmBaseApiController
    {
        public RabbitController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var rabbit = this.data.Rabbits.All().Include(a => a.Acquisition);
            var rabbitsViewModel = Mapper.Map<ICollection<RabbitModel>>(rabbit);

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

        [HttpPost]
        public IHttpActionResult Add(RabbitModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var rabbit = Mapper.Map<Rabbit>(obj);
            this.data.Rabbits.Add(rabbit);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var rabbitInDb = this.data.Rabbits.Find(id);
            if (rabbitInDb == null)
            {
                return BadRequest("No Rabbit with the given id found!");
            }
            this.data.Rabbits.Delete(rabbitInDb);
            this.data.SaveChanges();
            return Ok("Rabbit deleted!");
        }
    }
}