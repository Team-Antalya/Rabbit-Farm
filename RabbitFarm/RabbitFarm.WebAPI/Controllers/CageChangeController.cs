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

        [HttpPost]
        public IHttpActionResult Add(CageChangeModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var cageChange = Mapper.Map<CageChange>(obj);
            this.data.CageChanges.Add(cageChange);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var cageChange = this.data.CageChanges.Find(id);
            if (cageChange == null)
            {
                return BadRequest("No CageChange with the given id found!");
            }
            this.data.CageChanges.Delete(cageChange);
            this.data.SaveChanges();
            return Ok("CageChange deleted!");
        }
    }
}
