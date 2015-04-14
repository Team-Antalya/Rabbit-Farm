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

    public class CageController : RabbitFarmBaseApiController
    {
        public CageController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var cages = this.data.Cages.All().Include(a => a.Farm).Include(a => a.CageChanges);
            var cagesViewModel = Mapper.Map<ICollection<CageModel>>(cages);

            return Ok(cagesViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cage = this.data.Cages.Find(id);
            if (cage == null)
            {
                return BadRequest("No cage with this id!");
            }
            var cageViewModel = Mapper.Map<CageModel>(cage);
            return Ok(cageViewModel);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Cage obj)
        {
            this.data.Cages.Update(obj);
            return Ok("Cage updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Cage obj)
        {
            var newCage = this.data.Cages.Add(obj);
            var cageViewModel = Mapper.Map<CageModel>(newCage);
            return Ok(cageViewModel);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Cage obj)
        {
            this.data.Cages.Delete(obj);
            return Ok("Cage deleted!");
        }
    }
}
