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
    public class PurchaseController : RabbitFarmBaseApiController
    {
        public PurchaseController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return Ok(this.data.Purchases.All());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var purchase = this.data.Purchases.Find(id);
            if (purchase == null)
            {
                return BadRequest("No Purchase with this id!");
            }
            return Ok(purchase);
        }

        [HttpPut]
        public virtual IHttpActionResult Update(Purchase obj)
        {
            this.data.Purchases.Update(obj);
            return Ok("Purchase updated!");
        }

        [HttpPost]
        public virtual IHttpActionResult Add(Purchase obj)
        {
            var newPurchase = this.data.Purchases.Add(obj);
            return Ok(newPurchase);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Purchase obj)
        {
            this.data.Purchases.Delete(obj);
            return Ok("Purchase deleted!");
        }
    }
}
