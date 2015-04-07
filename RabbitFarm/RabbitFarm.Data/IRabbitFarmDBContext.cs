namespace RabbitFarm.Data
{
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity;

    using Models;
    public interface IRabbitFarmDBContext
    {
        IDbSet<Acquisition> Acquisitions { get; set; }

        IDbSet<Cage> Cages { get; set; }

        IDbSet<CageChange> CageChanges { get; set; }

        IDbSet<Farm> Farms { get; set; }

        IDbSet<Feed> Feeds { get; set; }

        IDbSet<Feeding> Feedings { get; set; }

        IDbSet<FeedMix> FeedMixes { get; set; }

        IDbSet<Litter> Litters { get; set; }

        IDbSet<Purchase> Purchases { get; set; }

        IDbSet<Rabbit> Rabbits { get; set; }

        IDbSet<Realization> Realizations { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
