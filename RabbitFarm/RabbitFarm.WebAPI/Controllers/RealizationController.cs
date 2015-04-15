namespace RabbitFarm.WebAPI.Controllers
{
    using System.Data.Entity;
    using System.Collections.Generic;
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class RealizationController : RabbitFarmBaseApiController
    {
        public RealizationController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var realizations = this.data.Realizations.All().Include(a => a.Farm);
            var realizationsViewModel = Mapper.Map<ICollection<RealizationModel>>(realizations);

            return Ok(realizationsViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var realization = this.data.Realizations.Find(id);
            if (realization == null)
            {
                return BadRequest("No Realization with this id!");
            }

            var realizationViewModel = Mapper.Map<RealizationModel>(realization);

            return Ok(realizationViewModel);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, RealizationModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var realizationInDb = this.data.Realizations.Find(id);
            if (realizationInDb == null)
            {
                return BadRequest("No Realization with the given id found!");
            }
            var realization = Mapper.Map<Realization>(obj);
            realizationInDb.RealizationDate = realization.RealizationDate;
            realizationInDb.RealizationChannel = realization.RealizationChannel;
            realizationInDb.RabbitId = realization.RabbitId;
            realizationInDb.LiveWeight = realization.LiveWeight;
            realizationInDb.Price = realization.Price;
            realizationInDb.FarmId = realization.FarmId;
            this.data.SaveChanges();
            return Ok("Realization updated!");
        }

        [HttpPost]
        public IHttpActionResult Add(RealizationModel  obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var realization = Mapper.Map<Realization>(obj);
            this.data.Realizations.Add(realization);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var realizationInDb = this.data.Realizations.Find(id);
            if (realizationInDb == null)
            {
                return BadRequest("No Realization with the given id found!");
            }
            this.data.Realizations.Delete(realizationInDb);
            this.data.SaveChanges();
            return Ok("Realization deleted!");
        }
    }
}
