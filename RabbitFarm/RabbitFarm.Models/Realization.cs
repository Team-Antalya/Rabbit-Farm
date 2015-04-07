namespace RabbitFarm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Realization
    {
        [Key, ForeignKey("Rabbit")]
        public int Id { get; set; }

        public DateTime RealizationDate { get; set; }

        public RealizationChannel RealizationChannel { get; set; }

        public Rabbit Rabbit { get; set; }

        public double? LiveWeight { get; set; }

        public decimal? Price { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
