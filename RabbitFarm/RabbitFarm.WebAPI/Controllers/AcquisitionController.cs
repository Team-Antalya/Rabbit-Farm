using System.Linq;

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

    public class AcquisitionController : RabbitFarmBaseApiController
    {
        public AcquisitionController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var acquisitions = this.data.Acquisitions.All().Include(a => a.Farm);
            var acquisitionsViewModel = Mapper.Map<ICollection<AcquisitionModel>>(acquisitions);

            return Ok(acquisitionsViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var acquisition = this.data.Acquisitions.Find(id);
            if (acquisition == null)
            {
                return BadRequest("No acquisition with this id!");
            }
            var acquisitionViewModel = Mapper.Map<AcquisitionModel>(acquisition);
            return Ok(acquisitionViewModel);
        }

        [HttpPut]
        public IHttpActionResult Update(AcquisitionModel obj)
        {
            var acquisition = Mapper.Map<Acquisition>(obj);
            this.data.Acquisitions.Update(acquisition);
            this.data.SaveChanges();
            return Ok("Acquisition updated!");
        }

        [HttpPost]
        public IHttpActionResult Add(AcquisitionModel obj)
        {
            var acquisition = Mapper.Map<Acquisition>(obj);
            this.data.Acquisitions.Add(acquisition);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Delete(Acquisition obj)
        {
            this.data.Acquisitions.Delete(obj);
            return Ok("Acquisition deleted!");
        }
    }
}
