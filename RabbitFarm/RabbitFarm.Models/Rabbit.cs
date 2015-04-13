namespace RabbitFarm.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Rabbit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Mark { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public RabbitStatus Status { get; set; }

        public int? LitterId { get; set; }

        public virtual Litter Litter { get; set; }

        public int AcquisitionId { get; set; }
        
        public virtual Acquisition Acquisition { get; set; }

        public Realization Realization { get; set; }

        [Required]
        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
