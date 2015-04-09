namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;

    public class CageChange
    {
        private ICollection<Cage> cages;

        public CageChange()
        {
            this.cages = new HashSet<Cage>();
        }

        public int Id { get; set; }

        public DateTime StartingDate { get; set; }

        public virtual ICollection<Cage> Cages
        {
            get { return this.cages; }
            set { this.cages = value; }
        }

        //public int CageId { get; set; }

        //public virtual Cage Cage { get; set; }

        public int RabbitId { get; set; }

        public virtual Rabbit Rabbit { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
