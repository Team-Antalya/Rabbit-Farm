namespace RabbitFarm.Data
{
    using Repositories;
    using Models;
    public interface IRabbitFarmData
    {
        IRepository<Acquisition> Acquisitions { get; }

        IRepository<Cage> Cages { get; }

        IRepository<CageChange> CageChanges { get; }

        IRepository<Farm> Farms { get; }

        IRepository<Feeding> Feedings { get; }

        IRepository<Litter> Litters { get; }

        IRepository<Purchase> Purchases { get; }

        IRepository<Rabbit> Rabbits { get; }

        IRepository<Realization> Realizations { get; }

        int SaveChanges();
    }
}
