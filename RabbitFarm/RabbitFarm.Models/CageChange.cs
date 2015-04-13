namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CageChange
    {
        private ICollection<Cage> cages;

        public CageChange()
        {
            this.cages = new HashSet<Cage>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        public virtual ICollection<Cage> Cages
        {
            get { return this.cages; }
            set { this.cages = value; }
        }

        [Required]
        public int RabbitId { get; set; }

        public virtual Rabbit Rabbit { get; set; }

        [Required]
        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
