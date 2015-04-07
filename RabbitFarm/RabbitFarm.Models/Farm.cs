namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Farm
    {
        private ICollection<Cage> cages;
        private ICollection<Rabbit> rabbits;
        private ICollection<Litter> litters;
        private ICollection<Purchase> purchases;
        private ICollection<Feed> feeds;
        private ICollection<FeedMix> feedMixes;
        private ICollection<Feeding> feedings;

        public Farm()
        {
            this.Id = Guid.NewGuid();
            this.cages = new HashSet<Cage>();
            this.litters = new HashSet<Litter>();
            this.rabbits = new HashSet<Rabbit>();
            this.purchases = new HashSet<Purchase>();
            this.feeds = new HashSet<Feed>();
            this.feedMixes = new HashSet<FeedMix>();
            this.feedings = new HashSet<Feeding>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public object UserId { get; set; }

        public virtual ICollection<Cage> Cages
        {
            get { return this.cages; }
            set { this.cages = value; }
        }

        public virtual ICollection<Rabbit> Rabbits
        {
            get { return this.rabbits; }
            set { this.rabbits = value; }
        }

        public virtual ICollection<Litter> Litters
        {
            get { return this.litters; }
            set { this.litters = value; }
        }

        public virtual ICollection<Purchase> Purchases
        {
            get { return this.purchases; }
            set { this.purchases = value; }
        }

        public virtual ICollection<Feed> Feeds
        {
            get { return this.feeds; }
            set { this.feeds = value; }
        }

        public virtual ICollection<FeedMix> FeedMixes
        {
            get { return this.feedMixes; }
            set { this.feedMixes = value; }
        }

        public virtual ICollection<Feeding> Feedings
        {
            get { return this.feedings; }
            set { this.feedings = value; }
        }
    }
}
