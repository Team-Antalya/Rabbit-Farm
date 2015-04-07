namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Feed
    {
        private ICollection<FeedMix> ingredients;

        public Feed()
        {
            this.ingredients = new HashSet<FeedMix>();
        }

        public int Id { get; set; }

        public string Lot { get; set; }

        public Unit Unit { get; set; }

        public virtual ICollection<FeedMix> Ingredients
        {
            get { return this.ingredients; }
            set { this.ingredients = value; }
        }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }

    }
}
