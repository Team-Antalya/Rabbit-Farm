namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using RabbitFarm.Models;

    public class AcquisitionModel
    {
        public int Id { get; set; } 

        [Required]
        public DateTime AcquisitionDate { get; set; }

        [Required]
        public AcqusitionSource Source { get; set; }

        [Required]
        public int RabbitId { get; set; }

        public decimal Cost { get; set; }

        [Required]
        public int FarmId { get; set; }
    }
}