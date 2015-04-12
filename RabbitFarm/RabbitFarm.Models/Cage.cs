namespace RabbitFarm.Models
{
    using System.Collections.Generic;

    public class Cage
    {
        private ICollection<Feeding> feedings;
        private ICollection<CageChange> cageChanges;

        public Cage()
        {
            this.feedings = new HashSet<Feeding>();
            this.cageChanges = new HashSet<CageChange>();
        }

        public int Id { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }

        public virtual ICollection<CageChange> CageChanges
        {
            get { return this.cageChanges; }
            set { this.cageChanges = value; }
        }

        public virtual ICollection<Feeding> Feedings
        {
            get { return this.feedings; }
            set { this.feedings = value; }
        }
    }
}
