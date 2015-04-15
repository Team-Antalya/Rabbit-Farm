namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Litter
    {
        private ICollection<Rabbit> rabbits;

        public Litter()
        {
            this.rabbits = new HashSet<Rabbit>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public int? MotherId { get; set; }

        public int? FatherId { get; set; }

        public virtual ICollection<Rabbit> Rabbits
        {
            get { return this.rabbits; }
            set { this.rabbits = value; }
        }

        [Required]
        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
