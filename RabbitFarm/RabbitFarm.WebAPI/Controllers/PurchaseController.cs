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
    public class PurchaseController : RabbitFarmBaseApiController
    {
        public PurchaseController(IUserProvider userProvider) :
            base(new RabbitFarmData(new RabbitFarmContext()), userProvider)
        {
            
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var purchases = this.data.Purchases.All().Include(a => a.Farm);
            var purchasesViewModel = Mapper.Map<PurchaseModel>(purchases);
            return Ok(purchasesViewModel);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var purchase = this.data.Purchases.Find(id);
            if (purchase == null)
            {
                return BadRequest("No Purchase with this id!");
            }
            var purchaseViewModel = Mapper.Map<PurchaseModel>(purchase);
            return Ok(purchaseViewModel);
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
            var purchaseViewModel = Mapper.Map<PurchaseModel>(newPurchase);
            return Ok(purchaseViewModel);
        }

        [HttpDelete]
        public virtual IHttpActionResult Delete(Purchase obj)
        {
            this.data.Purchases.Delete(obj);
            return Ok("Purchase deleted!");
        }
    }
}
