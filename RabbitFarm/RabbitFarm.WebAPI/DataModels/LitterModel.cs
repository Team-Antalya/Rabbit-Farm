namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;

    public class LitterModel
    {
        public DateTime BirthDate { get; set; }

        public RabbitModel Mother { get; set; }

        public RabbitModel Father { get; set; }

        public ICollection<RabbitModel> Rabbits { get; set; }

        public FarmModel Farm { get; set; }
    }
}