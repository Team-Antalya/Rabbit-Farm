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
        public RealizationController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var realizations = this.data.Realizations.All().Include(a => a.Farm).Include(a => a.Rabbit);
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
        public virtual IHttpActionResult Update(Realization obj)
        {
            this.data.Realizations.Update(obj);
            return Ok("Realization updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Realization obj)
        {
            var newRealization = this.data.Realizations.Add(obj);
            var newRealizationViewModel = Mapper.Map<RealizationModel>(newRealization);

            return Ok(newRealizationViewModel);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Realization obj)
        {
            this.data.Realizations.Delete(obj);
            return Ok("Realization deleted!");
        }
    }
}
