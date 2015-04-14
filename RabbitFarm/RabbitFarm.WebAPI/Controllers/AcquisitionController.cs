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
        public virtual IHttpActionResult Update(Acquisition obj)
        {
            this.data.Acquisitions.Update(obj);
            return Ok("Acquisition updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Acquisition obj)
        {
            var newAcquisition = this.data.Acquisitions.Add(obj);
            var acquisitionViewModel = Mapper.Map<AcquisitionModel>(newAcquisition);
            return Ok(acquisitionViewModel);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Acquisition obj)
        {
            this.data.Acquisitions.Delete(obj);
            return Ok("Acquisition deleted!");
        }
    }
}
