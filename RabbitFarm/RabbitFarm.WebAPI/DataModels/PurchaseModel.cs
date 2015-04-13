namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Linq.Expressions;
    using RabbitFarm.Models;

    public class PurchaseModel
    {

        public string Name { get; set; }

        public PurchaseCategory PurchaseCategory { get; set; }

        public Unit Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public double Amount { get; set; }

        public decimal TotalPrice { get; set; }

        public string Lot { get; set; }

        public string Farm { get; set; }

        public static Expression<Func<Purchase, PurchaseModel>> PurchasesToViewModel
        {
            get
            {
                return p => new PurchaseModel
                {
                    Name = p.Name,
                    PurchaseCategory = p.PurchaseCategory,
                    Unit = p.Unit,
                    UnitPrice = p.UnitPrice,
                    Amount = p.Amount,
                    TotalPrice = p.TotalPrice,
                    Lot = p.Lot,
                    Farm = p.Farm.Name
                };
            }
        }
    }
}