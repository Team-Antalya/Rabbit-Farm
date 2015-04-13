namespace RabbitFarm.WebAPI.DataModels
{
    using System;

    using RabbitFarm.Models;

    public class FeedingModel
    {
        public DateTime FeedingDate { get; set; }

        public double Amount { get; set; }

        public Farm Farm { get; set; }

        /*public static Expression<Func<Feeding, FeedingModel>> PurchasesToViewModel
        {
            get
            {
                return f => new FeedingModel
                {
                    FeedingDate = f.FeedingDate,
                    Amount = f.Amount,
                    Farm = f.Farm.Name,
                };
            }
        }*/
    }
}