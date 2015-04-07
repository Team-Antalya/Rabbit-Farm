namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Feeding
    {
        public int Id { get; set; }

        public DateTime FeedingDate { get; set; }

        public int CageId { get; set; }

        public virtual Cage Cage { get; set; }

        public int FeedId { get; set; }

        public double Amount { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
