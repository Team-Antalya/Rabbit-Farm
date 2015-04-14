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

    public class LitterController : RabbitFarmBaseApiController
    {
        public LitterController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var litters = this.data.Litters.All().Include(a => a.Farm).Include(a => a.Rabbits);
            var littersViewModel = Mapper.Map<ICollection<LitterModel>>(litters);

            return Ok(littersViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var litter = this.data.Litters.Find(id);
            if (litter == null)
            {
                return BadRequest("No Litter with this id!");
            }
            var litterViewModel = Mapper.Map<LitterModel>(litter);
            return Ok(litterViewModel);
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

        [HttpPost]
        public IHttpActionResult Add(LitterModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var litter = Mapper.Map<Litter>(obj);
            this.data.Litters.Add(litter);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(int id)
        {
            var litterInDb = this.data.Litters.Find(id);
            if (litterInDb == null)
            {
                return BadRequest("No Litter with the given id found!");
            }
            this.data.Litters.Delete(litterInDb);
            this.data.SaveChanges();
            return Ok("Litter deleted!");
        }
    }
}
