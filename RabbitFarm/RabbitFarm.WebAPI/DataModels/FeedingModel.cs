namespace RabbitFarm.WebAPI.DataModels
{
    using System;

    public class FeedingModel
    {
        public DateTime FeedingDate { get; set; }

        public double Amount { get; set; }
    }
}