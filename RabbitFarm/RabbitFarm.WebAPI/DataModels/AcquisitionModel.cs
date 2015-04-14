namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RabbitFarm.Models;

    public class AcquisitionModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Acquisition Date is required")]
        public DateTime AcquisitionDate { get; set; }

        [Required(ErrorMessage = "Acquisition Source is required")]
        public AcqusitionSource Source { get; set; }

        [Required(ErrorMessage = "Acquisition Cost is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Acquisition Cost must be positive number")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "RabbitId is required")]
        public int RabbitId { get; set; }

        [Required(ErrorMessage = "FarmId is required")]
        public int FarmId { get; set; }
    }
}