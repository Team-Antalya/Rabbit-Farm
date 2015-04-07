namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Realization
    {
        public int Id { get; set; }

        public DateTime RealizationDate { get; set; }

        public RealizationChannel RealizationChannel { get; set; }

        public int RabbitId { get; set; }

        public Rabbit Rabbit { get; set; }

        public double LiveWeight { get; set; }

        public decimal Price { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
