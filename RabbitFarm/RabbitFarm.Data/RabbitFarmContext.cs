﻿using System.Collections.Generic;

namespace RabbitFarm.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Microsoft.AspNet.Identity.EntityFramework;

    using RabbitFarm.Models;

    public class RabbitFarmContext : IdentityDbContext<User>
    {
        public const string ConnectionStringSQL = "Server=.;Database=RabbitFarm;Integrated Security=True;";
        public const string ConnectionStringAzure = "Server=ibz4rymk74.database.windows.net;Database=RabbitFarm;Persist Security Info=True;User ID=antalya;Password=Parola123;";
        public const string ConnectionStringLocalDB = "Server=(localdb)\v11.0;Database=RabbitFarm;Integrated Security=True;";

        // DefaultConnection
        // RabbitFarmConn
        public RabbitFarmContext()
            : base(ConnectionStringSQL, throwIfV1Schema: false)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<RabbitFarmContext>());
        }

        public static RabbitFarmContext Create()
        {
            return new RabbitFarmContext();
        }

        public IDbSet<Acquisition> Acquisitions { get; set; }

        public IDbSet<Cage> Cages { get; set; }

        public IDbSet<CageChange> CageChanges { get; set; }

        public IDbSet<Farm> Farms { get; set; }

        public IDbSet<Feeding> Feedings { get; set; }

        public IDbSet<Litter> Litters { get; set; }

        public IDbSet<Purchase> Purchases { get; set; }

        public IDbSet<Rabbit> Rabbits { get; set; }

        public IDbSet<Realization> Realizations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Acquisition>()
                .HasRequired(x => x.Rabbit)
                .WithRequiredDependent(x => x.Acquisition)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Realization>()
                .HasRequired(x => x.Rabbit)
                .WithRequiredDependent(x => x.Realization)
                .WillCascadeOnDelete(true);
        }
    }
}
