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
            SeedRabbit(context);
            //SeedCage(context);
            //SeedCageChange(context);
            //SeedFeeding(context);
            SeedLitter(context);
            SeedPurchase(context);
            //SeedRealization(context);
        }

        private void SeedAcquisition(RabbitFarmContext context)
        {
            //seed acquisition Litter
            var acquisitionLitter1 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 3, 22),
                Cost = 40m,
                Source = AcqusitionSource.Litter,
                FarmId = 1
            };
            var acquisitionLitter2 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 4, 14),
                Cost = 40m,
                Source = AcqusitionSource.Litter,
                FarmId = 2
            };
            var acquisitionLitter3 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 12, 20),
                Cost = 60m,
                Source = AcqusitionSource.Litter,
                FarmId = 3
            };

            var acquisitionLitter4 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 12, 21),
                Cost = 60m,
                Source = AcqusitionSource.Litter,
                FarmId = 4
            };
            var acquisitionLitter5 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 12, 21),
                Cost = 60m,
                Source = AcqusitionSource.Litter,
                FarmId = 5
            };
            var acquisitionLitter6 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 12, 22),
                Cost = 60m,
                Source = AcqusitionSource.Litter,
                FarmId = 2
            };
            var acquisitionLitter7 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 12, 23),
                Cost = 70m,
                Source = AcqusitionSource.Litter,
                FarmId = 1
            };
            var acquisitionLitter8 = new Acquisition()
            {
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
                AcquisitionDate = new DateTime(2014, 2, 18),
                Cost = 20m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 1
            };
            var acquisitionOuterFarm2 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 1, 7),
                Cost = 15m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 2
            };
            var acquisitionOuterFarm3 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 9, 13),
                Cost = 20m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 3
            };
            var acquisitionOuterFarm4 = new Acquisition()
            {
                AcquisitionDate = new DateTime(2014, 9, 17),
                Cost = 20m,
                Source = AcqusitionSource.OuterFarm,
                FarmId = 4
            };
            var acquisitionOuterFarm5 = new Acquisition()
            {
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

        private void SeedFeeding(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }
        private void SeedRabbit(RabbitFarmContext context)
        {
            var rabbit1 = new Rabbit()
            {
                Mark = "10-12-35-43",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 2
            };
            var rabbit2 = new Rabbit()
            {
                Mark = "15-15-36-32",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 2,
                FarmId = 1
            };
            var rabbit3 = new Rabbit()
            {
                Mark = "11-24-65-23",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 2,
                FarmId = 3
            };
            var rabbit4 = new Rabbit()
            {
                Mark = "24-21-46-32",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 2,
                FarmId = 2
            };
            var rabbit5 = new Rabbit()
            {
                Mark = "32-23-12-43",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 2
            };
            var rabbit6 = new Rabbit()
            {
                Mark = "10-12-35-43",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 1,
                FarmId = 1
            };
            var rabbit7 = new Rabbit()
            {
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 2,
                FarmId = 1
            };
            var rabbit8 = new Rabbit()
            {
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 2
            };
            var rabbit9 = new Rabbit()
            {
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 2
            };
            var rabbit10 = new Rabbit()
            {
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 2,
                FarmId = 2
            };
            var rabbit11 = new Rabbit()
            {
                Mark = "21-42-53-21",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 1,
                FarmId = 1
            };
            var rabbit12 = new Rabbit()
            {
                Mark = "32-25-42-12",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 1,
                FarmId = 1
            };
            var rabbit13 = new Rabbit()
            {
                Mark = "32-25-42-12",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit14 = new Rabbit()
            {
                Mark = "32-25-42-12",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit15 = new Rabbit()
            {
                Mark = "12-21-21-22",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit16 = new Rabbit()
            {
                Mark = "23-42-12-22",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit17 = new Rabbit()
            {
                Mark = "23-44-44-21",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit18 = new Rabbit()
            {
                Mark = "42-43-21-45",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 4,
                FarmId = 4
            };
            var rabbit19 = new Rabbit()
            {
                Mark = "41-15-74-25",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 4,
                FarmId = 4
            };
            var rabbit20 = new Rabbit()
            {
                Mark = "46-21-84-21",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit21 = new Rabbit()
            {
                Mark = "46-24-53-17",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit22 = new Rabbit()
            {
                Mark = "61-24-21-22",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 5,
                FarmId = 5
            };
            var rabbit23 = new Rabbit()
            {
                Mark = "23-23-22-25",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 5,
                FarmId = 5
            };
            var rabbit24 = new Rabbit()
            {
                Mark = "22-15-31-64",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit25 = new Rabbit()
            {
                Mark = "54-23-21-46",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit26 = new Rabbit()
            {
                Mark = "43-32-12-22",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 6,
                FarmId = 2
            };
            var rabbit27 = new Rabbit()
            {
                Mark = "43-25-64-32",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit28 = new Rabbit()
            {
                Mark = "25-42-22-11",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit29 = new Rabbit()
            {
                Mark = "11-22-33-44",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 7,
                FarmId = 1
            };
            var rabbit30 = new Rabbit()
            {
                Mark = "33-21-12-22",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit31 = new Rabbit()
            {
                Mark = "43-54-24-62",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                FarmId = 1
            };
            var rabbit32 = new Rabbit()
            {
                Mark = "35-21-11-86",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 8,
                FarmId = 5
            };
            var rabbit33 = new Rabbit()
            {
                Mark = "65-42-23-42",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 8,
                FarmId = 5
            };


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
            context.Rabbits.AddOrUpdate(rabbit14);
            context.Rabbits.AddOrUpdate(rabbit15);
            context.Rabbits.AddOrUpdate(rabbit16);
            context.Rabbits.AddOrUpdate(rabbit17);
            context.Rabbits.AddOrUpdate(rabbit18);
            context.Rabbits.AddOrUpdate(rabbit19);
            context.Rabbits.AddOrUpdate(rabbit20);
            context.Rabbits.AddOrUpdate(rabbit21);
            context.Rabbits.AddOrUpdate(rabbit22);
            context.Rabbits.AddOrUpdate(rabbit23);
            context.Rabbits.AddOrUpdate(rabbit24);
            context.Rabbits.AddOrUpdate(rabbit25);
            context.Rabbits.AddOrUpdate(rabbit26);
            context.Rabbits.AddOrUpdate(rabbit27);
            context.Rabbits.AddOrUpdate(rabbit28);
            context.Rabbits.AddOrUpdate(rabbit29);
            context.Rabbits.AddOrUpdate(rabbit30);
            context.Rabbits.AddOrUpdate(rabbit31);
            context.Rabbits.AddOrUpdate(rabbit32);
            context.Rabbits.AddOrUpdate(rabbit33);

        }

        private void SeedLitter(RabbitFarmContext context)
        {
            var litter1 = new Litter()
            {
                BirthDate = new DateTime(2014, 3, 22),
                MotherId = 7,
                FatherId = 1,
                Rabbits = { context.Rabbits.Find(6), context.Rabbits.Find(11), context.Rabbits.Find(12) },
                FarmId = 1
            };
            var litter2 = new Litter()
            {
                BirthDate = new DateTime(2014, 4, 14),
                MotherId = 8,
                FatherId = 2,
                Rabbits = { context.Rabbits.Find(3), context.Rabbits.Find(4), context.Rabbits.Find(10) },
                FarmId = 2
            };
            var litter3 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 20),
                MotherId = 9,
                FatherId = 5,
                Rabbits = { context.Rabbits.Find(13), context.Rabbits.Find(14), context.Rabbits.Find(15) },
                FarmId = 3
            };
            var litter4 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 21),
                MotherId = 17,
                FatherId = 16,
                Rabbits = { context.Rabbits.Find(18), context.Rabbits.Find(19) },
                FarmId = 4
            };
            var litter5 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 21),
                MotherId = 21,
                FatherId = 20,
                Rabbits = { context.Rabbits.Find(22), context.Rabbits.Find(23) },
                FarmId = 5
            };
            var litter6 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 22),
                MotherId = 25,
                FatherId = 24,
                Rabbits = { context.Rabbits.Find(26) },
                FarmId = 2
            };
            var litter7 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 23),
                MotherId = 28,
                FatherId = 27,
                Rabbits = { context.Rabbits.Find(29)) },
                FarmId = 1
            };
            var litter8 = new Litter()
            {
                BirthDate = new DateTime(2014, 10, 10),
                MotherId = 31,
                FatherId = 30,
                Rabbits = { context.Rabbits.Find(32), context.Rabbits.Find(33)},
                FarmId = 5
            };

            context.Litters.AddOrUpdate(litter1);
            context.Litters.AddOrUpdate(litter2);
            context.Litters.AddOrUpdate(litter3);
            context.Litters.AddOrUpdate(litter4);
            context.Litters.AddOrUpdate(litter5);
            context.Litters.AddOrUpdate(litter6);
            context.Litters.AddOrUpdate(litter7);
            context.Litters.AddOrUpdate(litter8);
        }

        private void SeedPurchase(RabbitFarmContext context)
        {
            //seed corn feed
            var feedCorn1 = new Purchase()
            {
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
                Name = "Tunnel of willow twigs",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 20,
                UnitPrice = 7.90m,
                TotalPrice = 158m,
                FarmId = 1
            };
            var toyEquipment2 = new Purchase()
            {
                Name = "Tunnel of willow twigs",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 15,
                UnitPrice = 7.90m,
                TotalPrice = 118.5m,
                FarmId = 2
            };
            var toyEquipment3 = new Purchase()
            {
                Name = "Wooden hut",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 10,
                UnitPrice = 27.90m,
                TotalPrice = 270.90m,
                FarmId = 5
            };
            var drinkEquipment1 = new Purchase()
            {
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 40,
                UnitPrice = 4.90m,
                TotalPrice = 196m,
                FarmId = 1
            };
            var drinkEquipment2 = new Purchase()
            {
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 45,
                UnitPrice = 4.90m,
                TotalPrice = 220.5m,
                FarmId = 2
            };
            var drinkEquipment3 = new Purchase()
            {
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 60,
                UnitPrice = 4.90m,
                TotalPrice = 294m,
                FarmId = 3
            };
            var drinkEquipment4 = new Purchase()
            {
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
                Name = "PESTORIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 70,
                UnitPrice = 2.40m,
                TotalPrice = 168m,
                FarmId = 1
            };
            var vaccinePestorin2 = new Purchase()
            {
                Name = "PESTORIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 55,
                UnitPrice = 2.40m,
                TotalPrice = 132m,
                FarmId = 2
            };
            var vaccineMyxoren1 = new Purchase()
            {
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 60,
                UnitPrice = 2.80m,
                TotalPrice = 168m,
                FarmId = 3
            };
            var vaccineMyxoren2 = new Purchase()
            {
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 65,
                UnitPrice = 2.80m,
                TotalPrice = 182m,
                FarmId = 4
            }; var vaccineMyxoren3 = new Purchase()
            {
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 80,
                UnitPrice = 2.80m,
                TotalPrice = 224m,
                FarmId = 5
            };
            var vaccineErisin1 = new Purchase()
            {
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 20,
                UnitPrice = 5.50m,
                TotalPrice = 110m,
                FarmId = 3
            };
            var vaccineErisin2 = new Purchase()
            {
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 15,
                UnitPrice = 5.50m,
                TotalPrice = 82.5m,
                FarmId = 4
            };
            var vaccineErisin3 = new Purchase()
            {
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 30,
                UnitPrice = 5.50m,
                TotalPrice = 165m,
                FarmId = 5
            };
            var vaccineCanverm1 = new Purchase()
            {
                Name = "CANIVERM",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 15,
                UnitPrice = 6.10m,
                TotalPrice = 91.5m,
                FarmId = 1
            };
            var vaccineCanverm2 = new Purchase()
            {
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

        private void SeedRealization(RabbitFarmContext context)
        {
            throw new System.NotImplementedException();
        }
    }
}