namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FeedMix
    {
        public int Id { get; set; }

        public int PurchaseId { get; set; }

        public virtual Purchase Purchase { get; set; }

        public double Amount { get; set; }

        public int FeedId { get; set; }

        public Feed Feed { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
