namespace RabbitFarm.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Rabbit
    {
        public int Id { get; set; }

        public string Mark { get; set; }

        public Gender Gender { get; set; }

        public int CageId { get; set; }

        public virtual Cage Cage { get; set; }

        public object FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
