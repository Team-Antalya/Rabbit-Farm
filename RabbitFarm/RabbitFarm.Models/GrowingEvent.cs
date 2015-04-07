namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GrowingEvent
    {
        private ICollection<GrowingScenario> growingScenarios;

        public GrowingEvent()
        {
            this.growingScenarios = new HashSet<GrowingScenario>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public int DaysAfterBirth { get; set; }

        public int DaysAfterAncestorEvent { get; set; }

        [ForeignKey("Id")]
        public int AncestorEventId { get; set; }

        public virtual GrowingEvent AncestorEvent { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }

        public ICollection<GrowingScenario> GrowingScenarios
        {
            get { return this.growingScenarios; }
            set { this.growingScenarios = value; }
        }
    }
}
