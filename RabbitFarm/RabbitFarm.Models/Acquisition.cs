namespace RabbitFarm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Acquisition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime AcquisitionDate { get; set; }

        [Required]
        public AcqusitionSource Source { get; set; }

        public int RabbitId { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal Cost { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
