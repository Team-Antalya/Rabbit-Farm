namespace RabbitFarm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Acquisition
    {
        [Key, ForeignKey("Rabbit")]
        public int Id { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public virtual Rabbit Rabbit { get; set; }

        public AcqusitionSource Source { get; set; }

        public decimal Cost { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
