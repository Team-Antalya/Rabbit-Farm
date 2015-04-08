namespace RabbitFarm.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public PurchaseCategory PurchaseCategory { get; set; }

        public Unit Unit { get; set; }

        public decimal UnitPrice { get; set; }

        public double Amount { get; set; }

        public decimal TotalPrice { get; set; }

        public string Lot { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
