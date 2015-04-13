using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using RabbitFarm.Models;

namespace RabbitFarm.WebAPI.DataModels
{
    public class CageModel
    {
        public double Width { get; set; }

        public double Height { get; set; }

        public double Length { get; set; }

        public string Farm { get; set; }

        public ICollection<CageChange> CageChanges;

        public static Expression<Func<Cage, CageModel>> CagesToViewModel
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
        }
    }
}