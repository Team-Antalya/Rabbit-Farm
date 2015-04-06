namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Litter
    {
        private ICollection<Rabbit> rabbits;

        public Litter()
        {
            this.rabbits = new HashSet<Rabbit>();
        }

        public int Id { get; set; }

        public DateTime BirthDate { get; set; }

        public int MotherId { get; set; }

        public virtual Rabbit Mother { get; set; }

        public int FatherId { get; set; }

        public virtual Rabbit Father { get; set; }

        public virtual ICollection<Rabbit> Rabbits
        {
            get { return this.rabbits; }
            set { this.rabbits = value; }
        }

        public Guid FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
