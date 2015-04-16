namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FeedingModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Feeding Date is required")]
        public DateTime FeedingDate { get; set; }

        [Required(ErrorMessage = "Feeding Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Feeding Amount must be positive number")]
        public double Amount { get; set; }

        [Required]
        public int CageId { get; set; }

        [Required]
        public int PurchaseId { get; set; }

        [Required]
        public int FarmId { get; set; }
    }
}