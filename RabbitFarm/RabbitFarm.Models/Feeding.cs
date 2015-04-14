namespace RabbitFarm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Feeding
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime FeedingDate { get; set; }

        [Required]
        public int CageId { get; set; }

        public virtual Cage Cage { get; set; }

        [Required]
        public int PurchaseId { get; set; }

        public virtual Purchase Purchase { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
