namespace RabbitFarm.WebAPI.DataModels
{
    using System.Collections.Generic;

    using RabbitFarm.Models;

    public class CageModel
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public Farm Farm { get; set; }

        public ICollection<CageChange> CageChanges;

        /*public static Expression<Func<Cage, CageModel>> CagesToViewModel
        {
            get
            {
                return a => new CageModel
                {
                    Width = a.Width,
                    Height = a.Height,
                    Length = a.Length,
                    Farm = a.Farm.Name
                };
            }
        }*/
    }
}