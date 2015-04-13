namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;

    using RabbitFarm.Models;

    public class LitterModel
    {
        public DateTime BirthDate { get; set; }

        public Rabbit Mother { get; set; }

        public Rabbit Father { get; set; }

        public ICollection<Rabbit> Rabbits { get; set; }

        public Farm Farm { get; set; }

        /*public static Expression<Func<Litter, LitterModel>> PurchasesToViewModel
        {
            get
            {
                return l => new LitterModel
                {
                    BirthDate = l.BirthDate,
                    Mother = l.Mother.Mark,
                    Father = l.Father.Mark,
                    Rabbits = l.Rabbits.Count,
                    Farm = l.Farm.Name,
                };
            }
        }*/
    }
}