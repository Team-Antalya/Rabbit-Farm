﻿namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Linq.Expressions;
    using RabbitFarm.Models;

    public class AcquisitionModel
    {
        public DateTime AcquisitionDate { get; set; }

        public AcqusitionSource Source { get; set; }

        public string Rabbit { get; set; }

        public decimal Cost { get; set; }

        public string Farm { get; set; }

        public static Expression<Func<Acquisition, AcquisitionModel>> AcquisitionToViewModel
        {
            get
            {
                return a => new AcquisitionModel
                {
                    AcquisitionDate = a.AcquisitionDate,
                    Source = a.Source,
                    Rabbit = a.Rabbit.Mark,
                    Cost = a.Cost,
                    Farm = a.Farm.Name
                };
            }
        }
    }
}