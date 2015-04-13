using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using RabbitFarm.Models;

namespace RabbitFarm.WebAPI.DataModels
{
    public class CageChangeModel
    {
        public DateTime StartingDate { get; set; }

        public string Rabbit { get; set; }

        public string Farm { get; set; }

        public static Expression<Func<CageChange, CageChangeModel>> CageChangesToViewModel
        {
            get
            {
                return a => new CageChangeModel
                {
                    StartingDate = a.StartingDate,
                    Rabbit = a.Rabbit.Mark,
                    Farm = a.Farm.Name
                };
            }
        }
    }
}