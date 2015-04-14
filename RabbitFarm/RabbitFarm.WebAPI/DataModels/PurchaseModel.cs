namespace RabbitFarm.WebAPI.DataModels
{
    using System.ComponentModel.DataAnnotations;

    using RabbitFarm.Models;

    public class PurchaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Purchase Name is required")]
        [StringLength(3, ErrorMessage = "Purchase Name must be at least 3 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Purchase Category is required")]
        public PurchaseCategory PurchaseCategory { get; set; }

        [Required(ErrorMessage = "Purchase Unit is required")]
        public Unit Unit { get; set; }

        [Required(ErrorMessage = "Purchase Unit Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Unit Price must be positive number")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Purchase Amount is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Amount must be positive number")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Purchase Total Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Total Price must be positive number")]
        public decimal TotalPrice { get; set; }

        [StringLength(3, ErrorMessage = "Purchase Lot is required")]
        public string Lot { get; set; }

        [Required(ErrorMessage = "FarmId is required")]
        public int FarmId { get; set; }
    }
}