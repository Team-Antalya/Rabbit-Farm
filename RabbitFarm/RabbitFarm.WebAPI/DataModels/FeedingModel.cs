﻿namespace RabbitFarm.WebAPI.DataModels
{
    using System;

    public class FeedingModel
    {
        public DateTime FeedingDate { get; set; }

        public double Amount { get; set; }

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