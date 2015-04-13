namespace RabbitFarm.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cage
    {
        private ICollection<Feeding> feedings;
        private ICollection<CageChange> cageChanges;

        public Cage()
        {
            this.feedings = new HashSet<Feeding>();
            this.cageChanges = new HashSet<CageChange>();
        }

        [Key]
        public int Id { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Width { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Height { get; set; }

        [Range(0.0, double.MaxValue)]
        public double Length { get; set; }

        [Required]
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
