namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Cage
    {
        private ICollection<Rabbit> rabbits;
        private ICollection<Feeding> feedings;

        public Cage()
        {
            this.rabbits = new HashSet<Rabbit>();
            this.feedings = new HashSet<Feeding>();
        }

        public int Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }

        public virtual ICollection<Rabbit> Rabbits
        {
            get { return this.rabbits; }
            set { this.rabbits = value; }
        }

        public virtual ICollection<Feeding> Feedings
        {
            get { return this.feedings; }
            set { this.feedings = value; }
        }
    }
}
