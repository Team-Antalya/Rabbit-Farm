using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RabbitFarm.Data;
using RabbitFarm.WebAPI.DataModels;
using RabbitFarm.WebAPI.Infrastructure;

namespace RabbitFarm.WebAPI.Controllers
{
    public class CageController : RabbitFarmBaseApiController
    {
        public CageController() :
            base(new RabbitFarmData(new RabbitFarmContext()), new AspNetUserProvider())
        {
            
        }
        public IHttpActionResult GetAll()
        {
            return Ok(this.data.Cages.All().Select(CageModel.CagesToViewModel));
        }
    }
}
