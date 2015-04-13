using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RabbitFarm.Data;
using RabbitFarm.Models;
using RabbitFarm.WebAPI.Infrastructure;

namespace RabbitFarm.WebAPI.Controllers
{
    public class CageChangeController : RabbitFarmBaseApiController
    {


        public CageChangeController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.data.CageChanges.All());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var cageChange = this.data.CageChanges.Find(id);
            if (cageChange == null)
            {
                return BadRequest("No CageChange with this id!");
            }
            return Ok(cageChange);
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
            return Ok(newCageChange);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(CageChange obj)
        {
            this.data.CageChanges.Delete(obj);
            return Ok("CageChange deleted!");
        }
    }
}
