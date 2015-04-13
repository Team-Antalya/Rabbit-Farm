using AutoMapper;
using RabbitFarm.Models;
using RabbitFarm.WebAPI.DataModels;

namespace RabbitFarm.WebAPI.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<Acquisition, AcquisitionModel>();
            Mapper.CreateMap<Cage, CageModel>();
            Mapper.CreateMap<CageChange, CageChangeModel>();
            Mapper.CreateMap<Farm, FarmModel>();
            Mapper.CreateMap<Feeding, FeedingModel>();
            Mapper.CreateMap<Litter, LitterModel>();
            Mapper.CreateMap<Purchase, PurchaseModel>();
            Mapper.CreateMap<Rabbit, RabbitModel>();
            Mapper.CreateMap<Realization, RealizationModel>();
        }
    }
}