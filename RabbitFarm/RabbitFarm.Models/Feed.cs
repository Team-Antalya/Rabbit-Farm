namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Feed
    {
        private ICollection<FeedMixes> ingredients;

        public Feed()
        {
            this.ingredients = new HashSet<FeedMixes>();
        }

        public int Id { get; set; }

        public string Lot { get; set; }

        public Unit Unit { get; set; }

        public virtual ICollection<FeedMixes> Ingredients
        {
            get { return this.ingredients; }
            set { this.ingredients = value; }
        }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }

    }
}
