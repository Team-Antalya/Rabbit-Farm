namespace RabbitFarm.Data.Migrations
{
    using RabbitFarm.Models;
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<RabbitFarmContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RabbitFarmContext context)
        {
            SeedFarm(context);
            SeedAcquisition(context);
            //SeedRabbit(context);
            //SeedCage(context);
            //SeedCageChange(context);
            //SeedFeed(context);
            //SeedFeeding(context);
            //SeedFeedMixes(context);
            //SeedLitter(context);
            //SeedPurchase(context);
            //SeedRealization(context);
        }

        private void SeedAcquisition(RabbitFarmContext context)
        {
            context.Acquisitions.AddOrUpdate(new Acquisition()
            {
            });
        }

        private void SeedCage(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedCageChange(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedFarm(RabbitFarmContext context)
        {
            context.Farms.AddOrUpdate(new Farm()
            {
                Name = "My Rabbit Farm"
            });
        }

        private void SeedFeed(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedFeeding(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedFeedMixes(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedLitter(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedPurchase(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedRabbit(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedRealization(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}