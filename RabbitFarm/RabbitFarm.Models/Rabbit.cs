namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
