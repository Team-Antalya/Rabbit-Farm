namespace RabbitFarm.WebAPI.DataModels
{
    using System.Collections.Generic;

    public class CageModel
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public FarmModel Farm { get; set; }

        public ICollection<CageChangeModel> CageChanges;
    }
}