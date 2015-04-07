namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Rabbit
    {
        public int Id { get; set; }

        public string Mark { get; set; }

        public Gender Gender { get; set; }

        public RabbitStatus Status { get; set; }

        public int AcqusitionId { get; set; }

        public virtual Acquisition Acquisition { get; set; }

        public int RealizationId { get; set; }

        public Realization Realization { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
