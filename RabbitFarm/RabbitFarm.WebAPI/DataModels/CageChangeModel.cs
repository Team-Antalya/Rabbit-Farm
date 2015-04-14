namespace RabbitFarm.WebAPI.DataModels
{
    using System;
    using System.Collections.Generic;

    public class CageChangeModel
    {
        public DateTime StartingDate { get; set; }

        public RabbitModel Rabbit { get; set; }

        public FarmModel Farm { get; set; }

        public ICollection<CageModel> Cages { get; set; }
    }
}