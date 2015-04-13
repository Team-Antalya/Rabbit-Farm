namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using RabbitFarm.Models;

    public class RealizationModel
    {
        public DateTime RealizationDate { get; set; }

        public RealizationChannel RealizationChannel { get; set; }

        public Rabbit Rabbit { get; set; }

        public double? LiveWeight { get; set; }

        public decimal? Price { get; set; }

        public Farm Farm { get; set; }

        /*public static Expression<Func<Realization, RealizationModel>> RealizationsToViewModel
        {
            get
            {
                return r => new RealizationModel
                {
                    RealizationDate = r.RealizationDate,
                    RealizationChannel = r.RealizationChannel,
                    Rabbit = r.Rabbit.Mark,
                    LiveWeight = r.LiveWeight,
                    Price = r.Price,
                    Farm = r.Farm.Name
                };
            }
        }*/
    }
}