namespace RabbitFarm.WebAPI
{
    using System.Collections.Generic;

    using RabbitFarm.Models;
    using RabbitFarm.WebAPI.DataModels;

    using AutoMapper;

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
