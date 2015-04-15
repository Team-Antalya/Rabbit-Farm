namespace RabbitFarm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Acquisition
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime AcquisitionDate { get; set; }

        [Required]
        public AcqusitionSource Source { get; set; }

        [Required]
        public int RabbitId { get; set; }

        [Required]
        public virtual Rabbit Rabbit { get; set; }

        [Range(0.0, double.MaxValue)]
        public decimal Cost { get; set; }

        [Required]
        public int FarmId { get; set; }

        [Required]
        public virtual Farm Farm { get; set; }
    }
}
