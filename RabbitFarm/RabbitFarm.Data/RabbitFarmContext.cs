namespace RabbitFarm.Data
{
    using System.Data.Entity;

    using Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class RabbitFarmContext : DbContext, IRabbitFarmDBContext
    {
        public const string ConnectionString =
        "Server=ibz4rymk74.database.windows.net;Database=Antalya;Persist Security Info=True;User ID=antalya;Password=Parola123;";

        //public const string ConnectionString =
        //    "RabbitFarmConn";

        public RabbitFarmContext()
            : base(ConnectionString)
        {
            // Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SupermarketSqlContext>());
        }

        public IDbSet<Acquisition> Acquisitions { get; set; }

        public IDbSet<Cage> Cages { get; set; }

        public IDbSet<CageChange> CageChanges { get; set; }

        public IDbSet<Farm> Farms { get; set; }

        public IDbSet<Feed> Feeds { get; set; }

        public IDbSet<Feeding> Feedings { get; set; }

        public IDbSet<FeedMix> FeedMixes { get; set; }

        public IDbSet<Litter> Litters { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public IDbSet<Rabbit> Rabbits { get; set; }

        public IDbSet<Realization> Realizations { get; set; }


        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}