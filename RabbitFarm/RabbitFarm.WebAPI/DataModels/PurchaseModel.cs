namespace RabbitFarm.WebAPI.DataModels
{
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

        public FarmModel Farm { get; set; }
    }
}