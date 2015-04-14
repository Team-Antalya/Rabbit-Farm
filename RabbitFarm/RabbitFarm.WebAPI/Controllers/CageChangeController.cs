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

    public class CageChangeController : RabbitFarmBaseApiController
    {
        public CageChangeController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var cageChanges = this.data.CageChanges.All().Include(a => a.Farm).Include(a => a.Rabbit).Include(a => a.Cages);
            var cageChangesViewModel = Mapper.Map<ICollection<CageChangeModel>>(cageChanges);

            return Ok(cageChangesViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cageChange = this.data.CageChanges.Find(id);
            if (cageChange == null)
            {
                return BadRequest("No CageChange with this id!");
            }
            var cageChangeViewModel = Mapper.Map<CageChangeModel>(cageChange);
            return Ok(cageChangeViewModel);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(CageChange obj)
        {
            this.data.CageChanges.Update(obj);
            return Ok("CageChange updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(CageChange obj)
        {
            var newCageChange = this.data.CageChanges.Add(obj);
            var cageChangeViewModel = Mapper.Map<CageChangeModel>(newCageChange);
            return Ok(cageChangeViewModel);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(CageChange obj)
        {
            this.data.CageChanges.Delete(obj);
            return Ok("CageChange deleted!");
        }
    }
}
