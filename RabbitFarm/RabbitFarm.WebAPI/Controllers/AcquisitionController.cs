using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RabbitFarm.Data;
using RabbitFarm.Models;
using RabbitFarm.WebAPI.DataModels;
using RabbitFarm.WebAPI.Infrastructure;

namespace RabbitFarm.WebAPI.Controllers
{
    public class AcquisitionController : RabbitFarmBaseApiController
    {
        public AcquisitionController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.data.Acquisitions.All());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var acquisition = this.data.Acquisitions.Find(id);
            if (acquisition == null)
            {
                return BadRequest("No acquisition with this id!");
            }
            return Ok(acquisition);
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
            return Ok(newAcquisition);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Acquisition obj)
        {
            this.data.Acquisitions.Delete(obj);
            return Ok("Acquisition deleted!");
        }
    }
}
