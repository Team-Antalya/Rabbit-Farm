namespace RabbitFarm.WebAPI.Controllers
{
    using System.Web.Http;

    using RabbitFarm.Data;
    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;
    using RabbitFarm.WebAPI.Infrastructure;

    using AutoMapper;

    public class PurchaseController : RabbitFarmBaseApiController<Purchase, PurchaseModel>
    {
        public PurchaseController(IRabbitFarmData data, IUserProvider userProvider) :
            base(data, userProvider)
        {
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
    }
}