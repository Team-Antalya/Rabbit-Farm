namespace RabbitFarm.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Purchase
    {
        public Purchase()
        {
            this.TotalPrice = (decimal)this.Amount*this.UnitPrice;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public PurchaseCategory PurchaseCategory { get; set; }

        [Required]
        public Unit Unit { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal UnitPrice { get; set; }

        [Required]
        [Range(1, double.MaxValue)]
        public double Amount { get; set; }
        
        public decimal TotalPrice
        {
            get { return (decimal)this.Amount * this.UnitPrice; }
            private set { } 
        }

        public string Lot { get; set; }

        [Required]
        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
