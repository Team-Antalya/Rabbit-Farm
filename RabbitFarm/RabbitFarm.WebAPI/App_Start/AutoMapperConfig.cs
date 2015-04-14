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
            Mapper.CreateMap<Acquisition, AcquisitionModel>().ReverseMap();
            Mapper.CreateMap<Cage, CageModel>();
            Mapper.CreateMap<Cage, CageModel>().ReverseMap();
            Mapper.CreateMap<CageChange, CageChangeModel>();
            Mapper.CreateMap<CageChange, CageChangeModel>().ReverseMap();
            Mapper.CreateMap<Farm, FarmModel>();
            Mapper.CreateMap<Farm, FarmModel>().ReverseMap();
            Mapper.CreateMap<Feeding, FeedingModel>();
            Mapper.CreateMap<Feeding, FeedingModel>().ReverseMap();
            Mapper.CreateMap<Litter, LitterModel>();
            Mapper.CreateMap<Litter, LitterModel>().ReverseMap();
            Mapper.CreateMap<Purchase, PurchaseModel>();
            Mapper.CreateMap<Purchase, PurchaseModel>().ReverseMap();
            Mapper.CreateMap<Rabbit, RabbitModel>();
            Mapper.CreateMap<Rabbit, RabbitModel>().ReverseMap();
            Mapper.CreateMap<Realization, RealizationModel>();
            Mapper.CreateMap<Realization, RealizationModel>().ReverseMap();
        }
    }
}
