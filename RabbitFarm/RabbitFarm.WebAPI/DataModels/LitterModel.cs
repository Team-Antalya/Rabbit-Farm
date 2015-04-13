namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Linq.Expressions;
    using RabbitFarm.Models;

    public class LitterModel
    {
        public DateTime BirthDate { get; set; }

        public string Mother { get; set; }

        public string Father { get; set; }

        public int Rabbits { get; set; }

        public string Farm { get; set; }

        public static Expression<Func<Litter, LitterModel>> PurchasesToViewModel
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
        }
    }
}