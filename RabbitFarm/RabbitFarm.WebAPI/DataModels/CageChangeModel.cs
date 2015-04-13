using System.Collections.Generic;

namespace RabbitFarm.WebAPI.DataModels
{
    using System;

    using RabbitFarm.Models;

    public class CageChangeModel
    {
        public DateTime StartingDate { get; set; }

        public Rabbit Rabbit { get; set; }

        public Farm Farm { get; set; }

        public ICollection<Cage> Cages { get; set; }

        /*public static Expression<Func<CageChange, CageChangeModel>> CageChangesToViewModel
        {
            get
            {
                return a => new CageChangeModel
                {
                    StartingDate = a.StartingDate,
                    Rabbit = a.Rabbit.Mark,
                    Farm = a.Farm.Name
                };
            }
        }*/
    }
}