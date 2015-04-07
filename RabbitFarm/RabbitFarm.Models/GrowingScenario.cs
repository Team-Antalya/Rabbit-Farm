namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GrowingScenario
    {
        private ICollection<GrowingEvent> growingEvents;
        private ICollection<RabbitScenario> rabbitScenarios;

        public GrowingScenario()
        {
            this.growingEvents = new HashSet<GrowingEvent>();
            this.rabbitScenarios = new HashSet<RabbitScenario>();
        }

        public int Id { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }

        public ICollection<GrowingEvent> GrowingEvents
        {
            get { return this.growingEvents; }
            set { this.growingEvents = value; }
        }

        public ICollection<RabbitScenario> RabbitScenarios
        {
            get { return this.rabbitScenarios; }
            set { this.rabbitScenarios = value; }
        }
    }
}
