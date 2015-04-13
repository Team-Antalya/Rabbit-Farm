namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Linq.Expressions;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using RabbitFarm.Models;

    public class FarmModel
    {
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<Cage> Cages { get; set; }

        public virtual ICollection<Rabbit> Rabbits { get; set; }

        public virtual ICollection<Litter> Litters { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public virtual ICollection<Feeding> Feedings { get; set; }

        public static Expression<Func<Farm, FarmModel>> PurchasesToViewModel
        {
            get
            {
                return f => new FarmModel
                {

                };
            }
        }
    }
}