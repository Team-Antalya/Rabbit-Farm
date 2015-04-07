namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RabbitScenario
    {
        [Key, Column(Order = 0)]
        public int RabbitId { get; set; }

        public virtual Rabbit Rabbit { get; set; }

        [Key, Column(Order = 1)]
        public int GrowingScenarioId { get; set; }

        public GrowingScenario GrowingScenario { get; set; }

        public DateTime StartingDate { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
