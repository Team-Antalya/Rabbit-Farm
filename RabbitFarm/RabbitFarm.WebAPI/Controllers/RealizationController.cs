namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
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
            var realizations = this.data.Realizations.All();
            var realizationsViewModel = Mapper.Map<Realization>(realizations);

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

            var realizationViewModel = Mapper.Map<Realization>(realization);

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
            var newRealizationViewModel = Mapper.Map<Realization>(newRealization);

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
