namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using RabbitFarm.Models;

    public class RealizationModel
    {
        public DateTime RealizationDate { get; set; }

        public RealizationChannel RealizationChannel { get; set; }

        public RabbitModel Rabbit { get; set; }

        public double? LiveWeight { get; set; }

        public decimal? Price { get; set; }

        public FarmModel Farm { get; set; }
    }
}