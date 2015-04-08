namespace RabbitFarm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Acquisition
    {

        public int Id { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public AcqusitionSource Source { get; set; }

        public Rabbit Rabbit { get; set; }

        public decimal Cost { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
