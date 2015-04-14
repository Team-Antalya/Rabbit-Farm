namespace RabbitFarm.WebAPI.DataModels
{
    using System;

    using RabbitFarm.Models;

    public class AcquisitionModel
    {
        public DateTime AcquisitionDate { get; set; }

        public AcqusitionSource Source { get; set; }

        public int RabbitId { get; set; }

        public decimal Cost { get; set; }

        public FarmModel Farm { get; set; }
    }
}