namespace RabbitFarm.WebAPI.DataModels
{
    using System;

    using RabbitFarm.Models;

    public class RabbitModel
    {
        public string Mark { get; set; }

        public Gender Gender { get; set; }

        public RabbitStatus Status { get; set; }

        public int Litter { get; set; }

        public DateTime Acquisition { get; set; }

        public decimal? Realization { get; set; }

        public Farm Farm { get; set; }

        /*public static Expression<Func<Rabbit, RabbitModel>> RabbitsToViewModel
        {
            get
            {
                return r => new RabbitModel
                {
                    Mark = r.Mark,
                    Gender = r.Gender,
                    Status = r.Status,
                    Litter = r.Litter.Rabbits.Count,
                    Acquisition = r.Acquisition.AcquisitionDate,
                    Realization = r.Realization.Price,
                    Farm = r.Farm.Name
                };
            }
        }*/
    }
}