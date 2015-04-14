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
        public virtual IHttpActionResult Update(Litter obj)
        {
            this.data.Litters.Update(obj);
            return Ok("Litter updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Litter obj)
        {
            var newLitter = this.data.Litters.Add(obj);
            var litterViewModel = Mapper.Map<LitterModel>(newLitter);
            return Ok(litterViewModel);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Litter obj)
        {
            this.data.Litters.Delete(obj);
            return Ok("Litter deleted!");
        }
    }
}
