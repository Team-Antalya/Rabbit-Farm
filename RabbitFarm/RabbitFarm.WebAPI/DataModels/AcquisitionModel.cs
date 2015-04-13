using System;
using System.Linq.Expressions;
using Microsoft.Ajax.Utilities;
using RabbitFarm.Models;

namespace RabbitFarm.WebAPI.DataModels
{
    public class AcquisitionModel
    {
        public int Id { get; set; }

        public DateTime AcquisitionDate { get; set; }

        public static Expression<Func<Acquisition, AcquisitionModel>> AcquisitionToViewModel
        {
            get
            {
                return a => new AcquisitionModel
                {
                    Id = a.Id,
                    AcquisitionDate = a.AcquisitionDate
                };
            }
        }
    }
}