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
            SeedPurchase(context);
            SeedAcquisition(context);
            SeedRabbit(context);
            SeedCage(context);
            SeedFeeding(context);
            SeedLitter(context);
            //SeedCageChange(context);
            //SeedRealization(context);
        }

        private void SeedFarm(RabbitFarmContext context)
        {
            var farm1 = new Farm() { Name = "My Rabbit Farm" };
            var farm2 = new Farm() { Name = "Happy easter day" };
            var farm3 = new Farm() { Name = "Rabbit heaven" };
            var farm4 = new Farm() { Name = "Farm for rabbit" };
            var farm5 = new Farm() { Name = "Rabbitlandia" };
            context.Farms.AddOrUpdate(farm1);
            context.Farms.AddOrUpdate(farm2);
            context.Farms.AddOrUpdate(farm3);
            context.Farms.AddOrUpdate(farm4);
            context.Farms.AddOrUpdate(farm5);
            context.SaveChanges();
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

        private void SeedAcquisition(RabbitFarmContext context)
        {
            //seed acquisition Litter
            var acquisitionLitter1 = new Acquisition()
            {
                Id = 1,
                AcquisitionDate = new DateTime(2014, 3, 22),
                Cost = 40m,
                Source = AcqusitionSource.Litter,
                FarmId = 2
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
                FarmId = 1
            };

            var acquisitionLitter4 = new Acquisition()
            {
                Id = 4,
                AcquisitionDate = new DateTime(2014, 12, 21),
                Cost = 60m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 5
            };
            var acquisitionLitter5 = new Acquisition()
            {
                Id = 5,
                AcquisitionDate = new DateTime(2014, 12, 21),
                Cost = 60m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 4
            };
            var acquisitionLitter6 = new Acquisition()
            {
                Id = 6,
                AcquisitionDate = new DateTime(2014, 12, 22),
                Cost = 60m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 3
            };
            var acquisitionLitter7 = new Acquisition()
            {
                Id = 7,
                AcquisitionDate = new DateTime(2014, 12, 23),
                Cost = 70m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 2
            };
            var acquisitionLitter8 = new Acquisition()
            {
                Id = 8,
                AcquisitionDate = new DateTime(2014, 10, 10),
                Cost = 40m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 1
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
                FarmId = 5
            };
            var acquisitionOuterFarm2 = new Acquisition()
            {
                Id = 10,
                AcquisitionDate = new DateTime(2014, 1, 7),
                Cost = 15m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 4
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
                FarmId = 1
            };
            var acquisitionOuterFarm5 = new Acquisition()
            {
                Id = 13,
                AcquisitionDate = new DateTime(2014, 7, 7),
                Cost = 10m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 2
            };

            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm1);
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm2);
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm3);
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm4);
            context.Acquisitions.AddOrUpdate(acquisitionOuterFarm5);


        }

        private void SeedRabbit(RabbitFarmContext context)
        {
            var rabbit1 = new Rabbit()
            {
                Id = 13,
                Mark = "10-12-35-43",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 13,
                FarmId = 2
            };
            var rabbit2 = new Rabbit()
            {
                Id = 12,
                Mark = "15-15-36-32",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 12,
                FarmId = 1
            };
            var rabbit3 = new Rabbit()
            {
                Id = 11,
                Mark = "11-24-65-23",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 11,
                FarmId = 3
            };
            var rabbit4 = new Rabbit()
            {
                Id = 10,
                Mark = "24-21-46-32",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 10,
                FarmId = 4
            };
            var rabbit5 = new Rabbit()
            {
                Id = 9,
                Mark = "32-23-12-43",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 9,
                FarmId = 5
            };
            var rabbit6 = new Rabbit()
            {
                Id = 8,
                Mark = "10-12-35-43",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 8,
                FarmId = 1
            };
            var rabbit7 = new Rabbit()
            {
                Id = 7,
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 7,
                FarmId = 2
            };
            var rabbit8 = new Rabbit()
            {
                Id = 6,
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 6,
                FarmId = 3
            };
            var rabbit9 = new Rabbit()
            {
                Id = 5,
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 5,
                FarmId = 5
            };
            var rabbit10 = new Rabbit()
            {
                Id = 4,
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 4,
                FarmId = 5
            };
            var rabbit11 = new Rabbit()
            {
                Id = 3,
                Mark = "21-42-53-21",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                LitterId = 1,
                FarmId = 1
            };
            var rabbit12 = new Rabbit()
            {
                Id = 2,
                Mark = "32-25-42-12",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 2,
                LitterId = 2,
                FarmId = 2
            };
            var rabbit13 = new Rabbit()
            {
                Id = 1,
                Mark = "32-25-42-12",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                LitterId = 2,
                AcquisitionId = 1,
                FarmId = 2
            };
            //var rabbit14 = new Rabbit()
            //{
            //    Mark = "32-25-42-12",
            //    Gender = Gender.Female,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit15 = new Rabbit()
            //{
            //    Mark = "12-21-21-22",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit16 = new Rabbit()
            //{
            //    Mark = "23-42-12-22",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit17 = new Rabbit()
            //{
            //    Mark = "23-44-44-21",
            //    Gender = Gender.Female,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit18 = new Rabbit()
            //{
            //    Mark = "42-43-21-45",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 4,
            //    FarmId = 4
            //};
            //var rabbit19 = new Rabbit()
            //{
            //    Mark = "41-15-74-25",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 4,
            //    FarmId = 4
            //};
            //var rabbit20 = new Rabbit()
            //{
            //    Mark = "46-21-84-21",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit21 = new Rabbit()
            //{
            //    Mark = "46-24-53-17",
            //    Gender = Gender.Female,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit22 = new Rabbit()
            //{
            //    Mark = "61-24-21-22",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 5,
            //    FarmId = 5
            //};
            //var rabbit23 = new Rabbit()
            //{
            //    Mark = "23-23-22-25",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 5,
            //    FarmId = 5
            //};
            //var rabbit24 = new Rabbit()
            //{
            //    Mark = "22-15-31-64",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit25 = new Rabbit()
            //{
            //    Mark = "54-23-21-46",
            //    Gender = Gender.Female,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit26 = new Rabbit()
            //{
            //    Mark = "43-32-12-22",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 6,
            //    FarmId = 2
            //};
            //var rabbit27 = new Rabbit()
            //{
            //    Mark = "43-25-64-32",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit28 = new Rabbit()
            //{
            //    Mark = "25-42-22-11",
            //    Gender = Gender.Female,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit29 = new Rabbit()
            //{
            //    Mark = "11-22-33-44",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 7,
            //    FarmId = 1
            //};
            //var rabbit30 = new Rabbit()
            //{
            //    Mark = "33-21-12-22",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit31 = new Rabbit()
            //{
            //    Mark = "43-54-24-62",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 3,
            //    FarmId = 1
            //};
            //var rabbit32 = new Rabbit()
            //{
            //    Mark = "35-21-11-86",
            //    Gender = Gender.Female,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 8,
            //    FarmId = 5
            //};
            //var rabbit33 = new Rabbit()
            //{
            //    Mark = "65-42-23-42",
            //    Gender = Gender.Male,
            //    Status = RabbitStatus.InFarm,
            //    AcquisitionId = 8,
            //    FarmId = 5
            //};


            context.Rabbits.AddOrUpdate(rabbit1);
            context.Rabbits.AddOrUpdate(rabbit2);
            context.Rabbits.AddOrUpdate(rabbit3);
            context.Rabbits.AddOrUpdate(rabbit4);
            context.Rabbits.AddOrUpdate(rabbit5);
            context.Rabbits.AddOrUpdate(rabbit6);
            context.Rabbits.AddOrUpdate(rabbit7);
            context.Rabbits.AddOrUpdate(rabbit8);
            context.Rabbits.AddOrUpdate(rabbit9);
            context.Rabbits.AddOrUpdate(rabbit10);
            context.Rabbits.AddOrUpdate(rabbit11);
            context.Rabbits.AddOrUpdate(rabbit12);
            context.Rabbits.AddOrUpdate(rabbit13);

            //context.Rabbits.AddOrUpdate(rabbit14);
            //context.Rabbits.AddOrUpdate(rabbit15);
            //context.Rabbits.AddOrUpdate(rabbit16);
            //context.Rabbits.AddOrUpdate(rabbit17);
            //context.Rabbits.AddOrUpdate(rabbit18);
            //context.Rabbits.AddOrUpdate(rabbit19);
            //context.Rabbits.AddOrUpdate(rabbit20);
            //context.Rabbits.AddOrUpdate(rabbit21);
            //context.Rabbits.AddOrUpdate(rabbit22);
            //context.Rabbits.AddOrUpdate(rabbit23);
            //context.Rabbits.AddOrUpdate(rabbit24);
            //context.Rabbits.AddOrUpdate(rabbit25);
            //context.Rabbits.AddOrUpdate(rabbit26);
            //context.Rabbits.AddOrUpdate(rabbit27);
            //context.Rabbits.AddOrUpdate(rabbit28);
            //context.Rabbits.AddOrUpdate(rabbit29);
            //context.Rabbits.AddOrUpdate(rabbit30);
            //context.Rabbits.AddOrUpdate(rabbit31);
            //context.Rabbits.AddOrUpdate(rabbit32);
            //context.Rabbits.AddOrUpdate(rabbit33);

        }

        private void SeedCage(RabbitFarmContext context)
        {
            var cage1 = new Cage()
            {
                Id = 1,
                Height = 200,
                Width = 200,
                Length = 200,
                FarmId = 1
            };
            var cage2 = new Cage()
            {
                Id = 2,
                Height = 160,
                Width = 180,
                Length = 160,
                FarmId = 2
            };
            var cage3 = new Cage()
            {
                Id = 3,
                Height = 150,
                Width = 150,
                Length = 150,
                FarmId = 3
            };
            var cage4 = new Cage()
            {
                Id = 4,
                Height = 350,
                Width = 160,
                Length = 210,
                FarmId = 4
            };
            var cage5 = new Cage()
            {
                Id = 5,
                Height = 300,
                Width = 200,
                Length = 100,
                FarmId = 5
            };
            var cage6 = new Cage()
            {
                Id = 6,
                Height = 200,
                Width = 200,
                Length = 200,
                FarmId = 1
            };
            var cage7 = new Cage()
            {
                Id = 7,
                Height = 160,
                Width = 180,
                Length = 160,
                FarmId = 2
            };
            var cage8 = new Cage()
            {
                Id = 8,
                Height = 150,
                Width = 150,
                Length = 150,
                FarmId = 3
            };
            var cage9 = new Cage()
            {
                Id = 9,
                Height = 350,
                Width = 160,
                Length = 210,
                FarmId = 4
            };
            var cage10 = new Cage()
            {
                Id = 10,
                Height = 300,
                Width = 200,
                Length = 100,
                FarmId = 5
            };

            context.Cages.AddOrUpdate(cage1);
            context.Cages.AddOrUpdate(cage2);
            context.Cages.AddOrUpdate(cage3);
            context.Cages.AddOrUpdate(cage4);
            context.Cages.AddOrUpdate(cage5);
            context.Cages.AddOrUpdate(cage6);
            context.Cages.AddOrUpdate(cage7);
            context.Cages.AddOrUpdate(cage8);
            context.Cages.AddOrUpdate(cage9);
            context.Cages.AddOrUpdate(cage10);
        }

        private void SeedFeeding(RabbitFarmContext context)
        {
            var feeding1 = new Feeding()
            {
                FeedingDate = new DateTime(2015, 2, 15),
                Amount = 100,
                PurchaseId = 2,
                CageId = 1,
                FarmId = 1
            };
            var feeding2 = new Feeding()
            {
                FeedingDate = new DateTime(2015, 2, 15),
                Amount = 100,
                PurchaseId = 2,
                CageId = 1,
                FarmId = 1
            };
            var feeding3 = new Feeding()
            {
                FeedingDate = new DateTime(2015, 2, 20),
                Amount = 200,
                PurchaseId = 5,
                CageId = 2,
                FarmId = 2
            };
            var feeding4 = new Feeding()
            {
                FeedingDate = new DateTime(2015, 2, 20),
                Amount = 200,
                PurchaseId = 10,
                CageId = 2,
                FarmId = 2
            };
            var feeding5 = new Feeding()
            {
                FeedingDate = new DateTime(2015, 1, 15),
                Amount = 150,
                PurchaseId = 1,
                CageId = 3,
                FarmId = 3
            };
            var feeding6 = new Feeding()
            {
                FeedingDate = new DateTime(2015, 1, 15),
                Amount = 150,
                PurchaseId = 5,
                CageId = 3,
                FarmId = 3
            };
            var feeding7 = new Feeding()
            {
                FeedingDate = new DateTime(2015, 1, 25),
                Amount = 180,
                PurchaseId = 1,
                CageId = 4,
                FarmId = 4
            };
            var feeding8 = new Feeding()
            {
                FeedingDate = new DateTime(2015, 1, 25),
                Amount = 180,
                PurchaseId = 10,
                CageId = 4,
                FarmId = 4
            };
            var feeding9 = new Feeding()
            {
                FeedingDate = new DateTime(2014, 12, 20),
                Amount = 250,
                PurchaseId = 5,
                CageId = 5,
                FarmId = 5
            };
            var feeding10 = new Feeding()
            {
                FeedingDate = new DateTime(2014, 12, 20),
                Amount = 250,
                PurchaseId = 10,
                CageId = 5,
                FarmId = 5
            };
            context.Feedings.AddOrUpdate(feeding1);
            context.Feedings.AddOrUpdate(feeding2);
            context.Feedings.AddOrUpdate(feeding3);
            context.Feedings.AddOrUpdate(feeding4);
            context.Feedings.AddOrUpdate(feeding5);
            context.Feedings.AddOrUpdate(feeding6);
            context.Feedings.AddOrUpdate(feeding7);
            context.Feedings.AddOrUpdate(feeding8);
            context.Feedings.AddOrUpdate(feeding9);
            context.Feedings.AddOrUpdate(feeding10);
        }

        private void SeedLitter(RabbitFarmContext context)
        {
            var litter1 = new Litter()
            {
                Id = 1,
                BirthDate = new DateTime(2014, 3, 22),
                MotherId = 8,
                FatherId = 12,
                FarmId = 1
            };
            var litter2 = new Litter()
            {
                Id = 2,
                BirthDate = new DateTime(2014, 4, 14),
                MotherId = 7,
                FatherId = 13,
                FarmId = 2
            };
            var litter3 = new Litter()
            {
                Id = 3,
                BirthDate = new DateTime(2014, 12, 20),
                MotherId = 6,
                FatherId = 11,
                FarmId = 3
            };

            var litter4 = new Litter()
            {
                Id = 4,
                BirthDate = new DateTime(2014, 12, 21),
                MotherId = 5,
                FatherId = 10,
                FarmId = 4
            };
            var litter5 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 21),
                MotherId = 4,
                FatherId = 9,
                FarmId = 5
            };
            //var litter6 = new Litter()
            //{
            //    BirthDate = new DateTime(2014, 12, 22),
            //    MotherId = 25,
            //    FatherId = 24,
            //    FarmId = 2
            //};
            //var litter7 = new Litter()
            //{
            //    BirthDate = new DateTime(2014, 12, 23),
            //    MotherId = 28,
            //    FatherId = 27,
            //    FarmId = 1
            //};
            //var litter8 = new Litter()
            //{
            //    BirthDate = new DateTime(2014, 10, 10),
            //    MotherId = 31,
            //    FatherId = 30,
            //    FarmId = 5
            //};

            context.Litters.AddOrUpdate(litter1);
            context.Litters.AddOrUpdate(litter2);
            context.Litters.AddOrUpdate(litter3);
            context.Litters.AddOrUpdate(litter4);
            context.Litters.AddOrUpdate(litter5);
            //context.Litters.AddOrUpdate(litter6);
            //context.Litters.AddOrUpdate(litter7);
            //context.Litters.AddOrUpdate(litter8);
        }

        private void SeedCageChange(RabbitFarmContext context)
        {
            var cageChanges1 = new CageChange()
            {
                Id = 1,
                StartingDate = new DateTime(2015, 1, 13),
                CageId = 7,
                RabbitId = 12,
                FarmId = 2
            };
            var cageChanges2 = new CageChange()
            {
                Id = 2,
                StartingDate = new DateTime(2015, 2, 9),
                CageId = 8,
                RabbitId = 12,
                FarmId = 1
            };
            var cageChanges3 = new CageChange()
            {
                Id = 3,
                StartingDate = new DateTime(2015, 1, 25),
                CageId = 4,
                RabbitId = 12,
                FarmId = 5
            };
            var cageChanges4 = new CageChange()
            {
                Id = 4,
                StartingDate = new DateTime(2015, 1, 17),
                CageId = 10,
                RabbitId = 12,
                FarmId = 4
            };
            var cageChanges5 = new CageChange()
            {
                Id = 5,
                StartingDate = new DateTime(2015, 2, 8),
                CageId = 11,
                RabbitId = 12,
                FarmId = 3
            };

            context.CageChanges.AddOrUpdate(cageChanges1);
            context.CageChanges.AddOrUpdate(cageChanges2);
            context.CageChanges.AddOrUpdate(cageChanges3);
            context.CageChanges.AddOrUpdate(cageChanges4);
            context.CageChanges.AddOrUpdate(cageChanges5);
			context.SaveChanges();
        }

        private void SeedRealization(RabbitFarmContext context)
        {
            //seed some Death realization
            var realizationDeath1 = new Realization()
            {
                Id = 1,
                RealizationDate = new DateTime(2014, 2, 10),
                RealizationChannel = RealizationChannel.Death,
                RabbitId = 1,
                LiveWeight = 2.3,
                FarmId = 2
            };
            var realizationDeath2 = new Realization()
            {
                Id = 7,
                RealizationDate = new DateTime(2014, 2, 15),
                RealizationChannel = RealizationChannel.Death,
                RabbitId = 7,
                LiveWeight = 2.1,
                FarmId = 2
            };
            context.Realizations.AddOrUpdate(realizationDeath1);
            context.Realizations.AddOrUpdate(realizationDeath2);

            //seed some Sold realization

            var realizationSold1 = new Realization()
            {

                Id = 2,
                RealizationDate = new DateTime(2014, 12, 23),
                RealizationChannel = RealizationChannel.Sold,
                RabbitId = 2,
                LiveWeight = 3.1,
                FarmId = 2
            };
            var realizationSold2 = new Realization()
            {

                Id = 5,
                RealizationDate = new DateTime(2014, 12, 22),
                RealizationChannel = RealizationChannel.Sold,
                RabbitId = 5,
                LiveWeight = 2.7,
                FarmId = 4
            };

            context.Realizations.AddOrUpdate(realizationSold1);
            context.Realizations.AddOrUpdate(realizationSold2);
            //seed slain realization
            var realizationsSlain = new Realization()
            {

                Id = 9,
                RealizationDate = new DateTime(2014, 8, 10),
                RealizationChannel = RealizationChannel.Slain,
                RabbitId = 9,
                LiveWeight = 3.4,
                FarmId = 5
            };
            context.Realizations.AddOrUpdate(realizationsSlain);

            context.SaveChanges();


        }
    }
    }
}