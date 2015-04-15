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

    public class PurchaseController : RabbitFarmBaseApiController
    {
        public PurchaseController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var purchases = this.data.Purchases.All().Include(a => a.Farm);
            var purchasesViewModel = Mapper.Map<ICollection<PurchaseModel>>(purchases);
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
        public IHttpActionResult Update(int id, PurchaseModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            var purchaseInDb = this.data.Purchases.Find(id);
            if (purchaseInDb == null)
            {
                return BadRequest("No Purchase with the given id found!");
            }
            var purchase = Mapper.Map<Purchase>(obj);
            purchaseInDb.Name = purchase.Name;
            purchaseInDb.PurchaseCategory = purchase.PurchaseCategory;
            purchaseInDb.Unit = purchase.Unit;
            purchaseInDb.UnitPrice = purchase.UnitPrice;
            purchaseInDb.Amount = purchase.Amount;
            purchaseInDb.Lot = purchase.Lot;
            purchaseInDb.FarmId = purchase.FarmId;
            this.data.SaveChanges();
            return Ok("Purchase updated!");
        }

        [HttpPost]
        public IHttpActionResult Add(PurchaseModel obj)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }
            var purchase = Mapper.Map<Purchase>(obj);
            this.data.Purchases.Add(purchase);
            this.data.SaveChanges();
            return Ok(obj);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var purchaseInDb = this.data.Purchases.Find(id);
            if (purchaseInDb == null)
            {
                return BadRequest("No Purchase with the given id found!");
            }
            this.data.Purchases.Delete(purchaseInDb);
            this.data.SaveChanges();
            return Ok("Purchase deleted!");
        }
    }
}