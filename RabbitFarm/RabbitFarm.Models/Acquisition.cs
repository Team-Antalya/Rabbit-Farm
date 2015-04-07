namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Acquisition
    {
        public int Id { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public int RabbitId { get; set; }

        public virtual Rabbit Rabbit { get; set; }

        public AcqusitionSource Source { get; set; }

        public decimal Price { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
