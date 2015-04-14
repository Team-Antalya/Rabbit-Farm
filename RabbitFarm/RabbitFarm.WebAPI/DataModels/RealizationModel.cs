namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RabbitFarm.Models;

    public class RealizationModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Realization Date is required")]
        public DateTime RealizationDate { get; set; }

        [Required(ErrorMessage = "Realization Channel is required")]
        public RealizationChannel RealizationChannel { get; set; }

        [Required(ErrorMessage = "RabbitId is required")]
        public int RabbitId { get; set; }

        public RabbitModel Rabbit { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Realization Live Weight must be positive number")]
        public double? LiveWeight { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Realization Price must be positive number")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "FarmId is required")]
        public int FarmId { get; set; }
    }
}