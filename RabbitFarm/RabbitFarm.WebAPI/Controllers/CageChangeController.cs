using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using RabbitFarm.Data;
using RabbitFarm.Models;
using RabbitFarm.WebAPI.DataModels;
using RabbitFarm.WebAPI.Infrastructure;
using System.Data.Entity;

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
            var cageChanges = this.data.CageChanges.All().Include(a => a.Farm).Include(a => a.Rabbit).Include(a => a.Cages);
            var cageChangesViewModel = Mapper.Map<CageChangeModel>(cageChanges);
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
