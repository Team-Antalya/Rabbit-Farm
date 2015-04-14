namespace RabbitFarm.WebAPI.DataModels
{
    using RabbitFarm.Models;

    public class RabbitModel
    {
        public string Mark { get; set; }

        public Gender Gender { get; set; }

        public RabbitStatus Status { get; set; }

        public int Litter { get; set; }

        public AcquisitionModel Acquisition { get; set; }

        public decimal? Realization { get; set; }

        public FarmModel Farm { get; set; }
    }
}