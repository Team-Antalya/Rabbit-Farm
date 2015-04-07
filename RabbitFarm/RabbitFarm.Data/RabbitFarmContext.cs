namespace RabbitFarm.Data
{
    using System.Data.Entity;

    using Models;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class RabbitFarmContext : DbContext
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

        public IDbSet<Acquisition> Acquisition { get; set; }

        public IDbSet<Cage> Cage { get; set; }

        public IDbSet<CageChange> CageChange { get; set; }

        public IDbSet<Farm> Farm { get; set; }

        public IDbSet<Feed> Feed { get; set; }

        public IDbSet<Feeding> Feeding { get; set; }

        public IDbSet<FeedMix> FeedMixes { get; set; }

        public IDbSet<Litter> Litter { get; set; }

        public IDbSet<Purchase> Purchase { get; set; }

        public IDbSet<Rabbit> Rabbit { get; set; }

        public IDbSet<Realization> Realization { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}