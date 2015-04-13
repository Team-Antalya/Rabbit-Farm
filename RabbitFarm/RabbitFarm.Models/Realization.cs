namespace RabbitFarm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Realization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime RealizationDate { get; set; }

        [Required]
        public RealizationChannel RealizationChannel { get; set; }

        [Required]
        public int RabbitId { get; set; }

        public virtual Rabbit Rabbit { get; set; }

        [Range(0, double.MaxValue)]
        public double? LiveWeight { get; set; }

        [Range(0, double.MaxValue)]
        public decimal? Price { get; set; }

        [Required]
        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
