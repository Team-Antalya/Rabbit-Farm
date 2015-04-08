using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RabbitFarm.Models
{
    public class Rabbit
    {
        public int Id { get; set; }

        public string Mark { get; set; }

        public Gender Gender { get; set; }

        public RabbitStatus Status { get; set; }
        public int AcquisitionId { get; set; }

        public virtual Acquisition Acquisition { get; set; }

        public virtual Realization Realization { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
