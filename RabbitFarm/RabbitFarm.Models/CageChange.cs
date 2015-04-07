namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CageChange
    {
        public int Id { get; set; }

        public DateTime StartingDate { get; set; }

        public int CageId { get; set; }

        public virtual Cage Cage { get; set; }

        public int RabbitId { get; set; }

        public virtual Rabbit Rabbit { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
