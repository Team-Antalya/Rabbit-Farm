namespace RabbitFarm.Data.Migrations
{
    using System;
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
            SeedPurchase(context);
            //SeedRabbit(context);
            //SeedCage(context);
            //SeedCageChange(context);
            //SeedFeeding(context);
            //SeedLitter(context);
            //SeedRealization(context);
        }

        private void SeedAcquisition(RabbitFarmContext context)
        {
            //seed acquisition Litter
            var acquisitionLitter1 = new Acquisition()
            {
                Id = 1,
                AcquisitionDate = new DateTime(2014, 3, 22),
                Cost = 40m,
                Source = AcqusitionSource.Litter,
                FarmId = 1
            };
            var acquisitionLitter2 = new Acquisition()
            {
                Id = 2,
                AcquisitionDate = new DateTime(2014, 4, 14),
                Cost = 40m,
                Source = AcqusitionSource.Litter,
                FarmId = 2
            };
            var acquisitionLitter3 = new Acquisition()
            {
                Id = 3,
                AcquisitionDate = new DateTime(2014, 12, 20),
                Cost = 60m,
                Source = AcqusitionSource.Litter,
                FarmId = 3
            };

            var acquisitionLitter4 = new Acquisition()
            {
                Id = 4,
                AcquisitionDate = new DateTime(2014, 12, 21),
                Cost = 60m,
                Source = AcqusitionSource.Litter,
                FarmId = 4
            };
            var acquisitionLitter5 = new Acquisition()
            {
                Id = 5,
                AcquisitionDate = new DateTime(2014, 12, 21),
                Cost = 60m,
                Source = AcqusitionSource.Litter,
                FarmId = 5
            };
            var acquisitionLitter6 = new Acquisition()
            {
                Id = 6,
                AcquisitionDate = new DateTime(2014, 12, 22),
                Cost = 60m,
                Source = AcqusitionSource.Litter,
                FarmId = 2
            };
            var acquisitionLitter7 = new Acquisition()
            {
                Id = 7,
                AcquisitionDate = new DateTime(2014, 12, 23),
                Cost = 70m,
                Source = AcqusitionSource.Litter,
                FarmId = 1
            };
            var acquisitionLitter8 = new Acquisition()
            {
                Id = 8,
                AcquisitionDate = new DateTime(2014, 10, 10),
                Cost = 40m,
                Source = AcqusitionSource.Litter,
                FarmId = 5
            };
            context.Acquisitions.AddOrUpdate(acquisitionLitter1);
            context.Acquisitions.AddOrUpdate(acquisitionLitter2);
            context.Acquisitions.AddOrUpdate(acquisitionLitter3);
            context.Acquisitions.AddOrUpdate(acquisitionLitter4);
            context.Acquisitions.AddOrUpdate(acquisitionLitter5);
            context.Acquisitions.AddOrUpdate(acquisitionLitter6);
            context.Acquisitions.AddOrUpdate(acquisitionLitter7);
            context.Acquisitions.AddOrUpdate(acquisitionLitter8);

            //seed acquisitions Outer farm
            var acquisitionOuterFarm1 = new Acquisition()
            {
                Id = 9,
                AcquisitionDate = new DateTime(2014, 2, 18),
                Cost = 20m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 1
            };
            var acquisitionOuterFarm2 = new Acquisition()
            {
                Id = 10,
                AcquisitionDate = new DateTime(2014, 1, 7),
                Cost = 15m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 2
            };
            var acquisitionOuterFarm3 = new Acquisition()
            {
                Id = 11,
                AcquisitionDate = new DateTime(2014, 9, 13),
                Cost = 20m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 3
            };
            var acquisitionOuterFarm4 = new Acquisition()
            {
                Id = 12,
                AcquisitionDate = new DateTime(2014, 9, 17),
                Cost = 20m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 4
            };
            var acquisitionOuterFarm5 = new Acquisition()
            {
                Id = 13,
                AcquisitionDate = new DateTime(2014, 7, 7),
                Cost = 10m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 5
            };
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm1);
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm2);
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm3);
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm4);
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm5);


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
            var farm1 = new Farm() { Id = 1, Name = "My Rabbit Farm" };
            var farm2 = new Farm() { Id = 2, Name = "Happy easter day" };
            var farm3 = new Farm() { Id = 3, Name = "Rabbit heaven" };
            var farm4 = new Farm() { Id = 4, Name = "Farm for rabbit" };
            var farm5 = new Farm() { Id = 5, Name = "Rabbitlandia" };

            context.Farms.AddOrUpdate(farm1);
            context.Farms.AddOrUpdate(farm2);
            context.Farms.AddOrUpdate(farm3);
            context.Farms.AddOrUpdate(farm4);
            context.Farms.AddOrUpdate(farm5);
            context.SaveChanges();
        }

        private void SeedFeeding(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedLitter(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }

        private void SeedPurchase(RabbitFarmContext context)
        {
            //seed corn feed
            var feedCorn1 = new Purchase()
            {
                Id = 1,
                Name = "Corn",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 1,
                Unit = Unit.Ton,
                UnitPrice = 365,
                TotalPrice = 365m,
                FarmId = 1
            };
            var feedCorn2 = new Purchase()
            {
                Id = 2,
                Name = "Corn",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 1.2,
                Unit = Unit.Ton,
                UnitPrice = 365,
                TotalPrice = 438m,
                FarmId = 2
            };
            var feedCorn3 = new Purchase()
            {
                Id = 3,
                Name = "Corn",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 1.5,
                Unit = Unit.Ton,
                UnitPrice = 365,
                TotalPrice = 547.5m,
                FarmId = 3
            };
            var feedCorn4 = new Purchase()
            {
                Id = 4,
                Name = "Corn",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 1.6,
                Unit = Unit.Ton,
                UnitPrice = 365,
                TotalPrice = 584m,
                FarmId = 4
            };
            context.Purchases.AddOrUpdate(feedCorn1);
            context.Purchases.AddOrUpdate(feedCorn2);
            context.Purchases.AddOrUpdate(feedCorn3);
            context.Purchases.AddOrUpdate(feedCorn4);

            //seed wheat feed
            var feedWheat1 = new Purchase()
            {
                Id = 5,
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 2.5,
                Unit = Unit.Ton,
                UnitPrice = 270,
                TotalPrice = 675m,
                FarmId = 1
            };
            var feedWheat2 = new Purchase()
            {
                Id = 6,
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 2.6,
                Unit = Unit.Ton,
                UnitPrice = 270,
                TotalPrice = 702m,
                FarmId = 2
            };
            var feedWheat3 = new Purchase()
            {
                Id = 7,
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 2.1,
                Unit = Unit.Ton,
                UnitPrice = 270,
                TotalPrice = 567m,
                FarmId = 3
            };
            var feedWheat4 = new Purchase()
            {
                Id = 8,
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 2,
                Unit = Unit.Ton,
                UnitPrice = 270,
                TotalPrice = 540m,
                FarmId = 4
            };
            var feedWheat5 = new Purchase()
            {
                Id = 9,
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 3.5,
                Unit = Unit.Ton,
                UnitPrice = 270,
                TotalPrice = 945m,
                FarmId = 5
            };
            context.Purchases.AddOrUpdate(feedWheat1);
            context.Purchases.AddOrUpdate(feedWheat2);
            context.Purchases.AddOrUpdate(feedWheat3);
            context.Purchases.AddOrUpdate(feedWheat4);
            context.Purchases.AddOrUpdate(feedWheat5);

            //seed mix feed
            var feedMix1 = new Purchase()
            {
                Id = 10,
                Name = "Mix-lucerne, vegetables, corn, seed, wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 100,
                Unit = Unit.Kg,
                UnitPrice = 7,
                TotalPrice = 700m,
                FarmId = 5
            };
            var feedMix2 = new Purchase()
            {
                Id = 11,
                Name = "Mix-algae, seed, vegetables, grain, fruit",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 50,
                Unit = Unit.Kg,
                UnitPrice = 8.5m,
                TotalPrice = 425m,
                FarmId = 5
            };
            var feedMix3 = new Purchase()
            {
                Id = 12,
                Name = "Mix- algae, grain, seed, herbs",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 100,
                Unit = Unit.Kg,
                UnitPrice = 7,
                TotalPrice = 700m,
                FarmId = 2
            };
            context.Purchases.AddOrUpdate(feedMix1);
            context.Purchases.AddOrUpdate(feedMix2);
            context.Purchases.AddOrUpdate(feedMix3);

            //seed Equipment 

            var toyEquipment1 = new Purchase()
            {
                Id = 13,
                Name = "Tunnel of willow twigs",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 20,
                UnitPrice = 7.90m,
                TotalPrice = 158m,
                FarmId = 1
            };
            var toyEquipment2 = new Purchase()
            {
                Id = 14,
                Name = "Tunnel of willow twigs",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 15,
                UnitPrice = 7.90m,
                TotalPrice = 118.5m,
                FarmId = 2
            };
            var toyEquipment3 = new Purchase()
            {
                Id = 15,
                Name = "Wooden hut",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 10,
                UnitPrice = 27.90m,
                TotalPrice = 270.90m,
                FarmId = 5
            };
            var drinkEquipment1 = new Purchase()
            {
                Id = 16,
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 40,
                UnitPrice = 4.90m,
                TotalPrice = 196m,
                FarmId = 1
            };
            var drinkEquipment2 = new Purchase()
            {
                Id = 17,
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 45,
                UnitPrice = 4.90m,
                TotalPrice = 220.5m,
                FarmId = 2
            };
            var drinkEquipment3 = new Purchase()
            {
                Id = 18,
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 60,
                UnitPrice = 4.90m,
                TotalPrice = 294m,
                FarmId = 3
            };
            var drinkEquipment4 = new Purchase()
            {
                Id = 19,
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 35,
                UnitPrice = 4.90m,
                TotalPrice = 171.5m,
                FarmId = 4
            };
            context.Purchases.AddOrUpdate(toyEquipment1);
            context.Purchases.AddOrUpdate(toyEquipment2);
            context.Purchases.AddOrUpdate(toyEquipment3);
            context.Purchases.AddOrUpdate(drinkEquipment1);
            context.Purchases.AddOrUpdate(drinkEquipment2);
            context.Purchases.AddOrUpdate(drinkEquipment3);
            context.Purchases.AddOrUpdate(drinkEquipment4);

            //seed medicine equipment

            var vaccinePestorin1 = new Purchase()
            {
                Id = 20,
                Name = "PESTORIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 70,
                UnitPrice = 2.40m,
                TotalPrice = 168m,
                FarmId = 1
            };
            var vaccinePestorin2 = new Purchase()
            {
                Id = 21,
                Name = "PESTORIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 55,
                UnitPrice = 2.40m,
                TotalPrice = 132m,
                FarmId = 2
            };
            var vaccineMyxoren1 = new Purchase()
            {
                Id = 22,
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 60,
                UnitPrice = 2.80m,
                TotalPrice = 168m,
                FarmId = 3
            };
            var vaccineMyxoren2 = new Purchase()
            {
                Id = 23,
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 65,
                UnitPrice = 2.80m,
                TotalPrice = 182m,
                FarmId = 4
            };
            var vaccineMyxoren3 = new Purchase()
            {
                Id = 24,
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 80,
                UnitPrice = 2.80m,
                TotalPrice = 224m,
                FarmId = 5
            };
            var vaccineErisin1 = new Purchase()
            {
                Id = 25,
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 20,
                UnitPrice = 5.50m,
                TotalPrice = 110m,
                FarmId = 3
            };
            var vaccineErisin2 = new Purchase()
            {
                Id = 26,
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 15,
                UnitPrice = 5.50m,
                TotalPrice = 82.5m,
                FarmId = 4
            };
            var vaccineErisin3 = new Purchase()
            {
                Id = 27,
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 30,
                UnitPrice = 5.50m,
                TotalPrice = 165m,
                FarmId = 5
            };
            var vaccineCanverm1 = new Purchase()
            {
                Id = 28,
                Name = "CANIVERM",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 15,
                UnitPrice = 6.10m,
                TotalPrice = 91.5m,
                FarmId = 1
            };
            var vaccineCanverm2 = new Purchase()
            {
                Id = 29,
                Name = "CANIVERM",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 20,
                UnitPrice = 6.10m,
                TotalPrice = 122m,
                FarmId = 2
            };
            context.Purchases.AddOrUpdate(vaccinePestorin1);
            context.Purchases.AddOrUpdate(vaccinePestorin2);
            context.Purchases.AddOrUpdate(vaccineMyxoren1);
            context.Purchases.AddOrUpdate(vaccineMyxoren2);
            context.Purchases.AddOrUpdate(vaccineMyxoren3);
            context.Purchases.AddOrUpdate(vaccineCanverm1);
            context.Purchases.AddOrUpdate(vaccineCanverm2);
            context.Purchases.AddOrUpdate(vaccineErisin1);
            context.Purchases.AddOrUpdate(vaccineErisin2);
            context.Purchases.AddOrUpdate(vaccineErisin3);

            context.SaveChanges();

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