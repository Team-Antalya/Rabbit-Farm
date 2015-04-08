namespace RabbitFarm.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Feeding
    {
        public int Id { get; set; }

        public DateTime FeedingDate { get; set; }

        public int CageId { get; set; }

        public virtual Cage Cage { get; set; }

        public int PurchaseId { get; set; }

        public virtual Purchase Feed { get; set; }

        public double Amount { get; set; }

        public int FarmId { get; set; }

        public virtual Farm Farm { get; set; }
    }
}
