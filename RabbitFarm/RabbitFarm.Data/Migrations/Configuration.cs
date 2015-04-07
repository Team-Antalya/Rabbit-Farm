namespace RabbitFarm.Data.Migrations
{
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
            SeedAcquisition(context);
            SeedCage(context);
            SeedCageChange(context);
            SeedFarm(context);
            SeedFeed(context);
            SeedFeeding(context);
            SeedFeedMixes(context);
            SeedLitter(context);
            SeedPurchase(context);
            SeedRabbit(context);
            SeedRealization(context);
        }

        private void SeedAcquisition(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
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