namespace RabbitFarm.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    using RabbitFarm.Models;

    public sealed class Configuration : DbMigrationsConfiguration<RabbitFarmContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(RabbitFarmContext context)
        {
            SeedUserWithFarms(context);

            SeedAcquisition(context);
            SeedRabbitsWithLitters(context);

            SeedPurchase(context);

            SeedCage(context);
            SeedCageChange(context);

            SeedFeeding(context);
            
           SeedRealization(context);
        }

        public void Seeder()
        {
            Seed(new RabbitFarmContext());
        }

        private void SeedUserWithFarms(RabbitFarmContext context)
        {
            //The UserStore is ASP Identity's data layer. Wrap context with the UserStore.
            UserStore<User> userStore = new UserStore<User>(context);

            //The UserManager is ASP Identity's implementation layer: contains the methods.
            //The constructor takes the UserStore: how the methods will interact with the database.
            UserManager<User> userManager = new UserManager<User>(userStore);

            //Add or Update the initial Users into the database as normal.
            context.Users.AddOrUpdate(
                x => x.Email,  //Using Email as the Unique Key: If a record exists with the same email, AddOrUpdate skips it.
                new User() { Email = "pesho@email.co.uk", UserName = "pesho", PasswordHash = new PasswordHasher().HashPassword("Som3Pass!") },
                new User() { Email = "gosho@email.co.uk", UserName = "gosho", PasswordHash = new PasswordHasher().HashPassword("MyPassword") },
                new User() { Email = "penka@dir.bg", UserName = "penka", PasswordHash = new PasswordHasher().HashPassword("PenkasPassword") },
                new User() { Email = "milka@abv.bg", UserName = "milka", PasswordHash = new PasswordHasher().HashPassword("MilkasPassword") }
            );

            //Save changes so the Id columns will auto-populate.
            context.SaveChanges();

            //ASP Identity User Id's are Guids stored as nvarchar(128), and exposed as strings.

            //Get the UserId only if the SecurityStamp is not set yet.
            string userId = context.Users.Where(x => x.Email == "pesho@email.co.uk" && string.IsNullOrEmpty(x.SecurityStamp)).Select(x => x.Id).FirstOrDefault();

            //If the userId is not null, then the SecurityStamp needs updating.
            if (!string.IsNullOrEmpty(userId)) userManager.UpdateSecurityStamp(userId);

            //Repeat for next user: good opportunity to make a helper method.
            userId = context.Users
                .Where(x => x.Email == "gosho@email.co.uk" && string.IsNullOrEmpty(x.SecurityStamp))
                .Select(x => x.Id)
                .FirstOrDefault();
            if (!string.IsNullOrEmpty(userId)) userManager.UpdateSecurityStamp(userId);

            userId = context.Users
                .Where(x => x.Email == "penka@dir.bg" && string.IsNullOrEmpty(x.SecurityStamp))
                .Select(x => x.Id)
                .FirstOrDefault();
            if (!string.IsNullOrEmpty(userId)) userManager.UpdateSecurityStamp(userId);

            userId = context.Users
                .Where(x => x.Email == "milka@abv.bg" && string.IsNullOrEmpty(x.SecurityStamp))
                .Select(x => x.Id)
                .FirstOrDefault();
            if (!string.IsNullOrEmpty(userId)) userManager.UpdateSecurityStamp(userId);

            //Continue on with Seed.

            var farm1 = new Farm()
            {
                Name = "My Rabbit Farm",
                Users = context.Users.Where(u => u.Email == "gosho@email.co.uk").ToList()
            };
            var farm2 = new Farm()
            {
                Name = "Happy easter day",
                Users = context.Users.Where(u => u.Email == "pesho@email.co.uk").ToList()
            };
            var farm3 = new Farm()
            {
                Name = "Rabbit heaven",
                Users = context.Users.Where(u => u.Email == "penka@dir.bg").ToList()
            };
            var farm4 = new Farm()
            {
                Name = "Farm for rabbit",
                Users = context.Users.Where(u => u.Email == "penka@dir.bg").ToList()
            };
            var farm5 = new Farm()
            {
                Name = "Rabbitlandia",
                Users = context.Users.Where(u => u.Email == "milka@abv.bg").ToList()
            };
            context.Farms.AddOrUpdate(farm1);
            context.Farms.AddOrUpdate(farm2);
            context.Farms.AddOrUpdate(farm3);
            context.Farms.AddOrUpdate(farm4);
            context.Farms.AddOrUpdate(farm5);
            context.SaveChanges();
        }

        //private void SeedFarm(RabbitFarmContext context)
        //{
        //    var farm1 = new Farm() { Name = "My Rabbit Farm", };
        //    var farm2 = new Farm() { Name = "Happy easter day" };
        //    var farm3 = new Farm() { Name = "Rabbit heaven" };
        //    var farm4 = new Farm() { Name = "Farm for rabbit" };
        //    var farm5 = new Farm() { Name = "Rabbitlandia" };
        //    context.Farms.AddOrUpdate(farm1);
        //    context.Farms.AddOrUpdate(farm2);
        //    context.Farms.AddOrUpdate(farm3);
        //    context.Farms.AddOrUpdate(farm4);
        //    context.Farms.AddOrUpdate(farm5);
        //    context.SaveChanges();
        //}

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
                FarmId = 1
            };
            var feedCorn2 = new Purchase()
            {
                Name = "Corn",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 1.2,
                Unit = Unit.Ton,
                UnitPrice = 365,
                FarmId = 2
            };
            var feedCorn3 = new Purchase()
            {
                Name = "Corn",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 1.5,
                Unit = Unit.Ton,
                UnitPrice = 365,
                FarmId = 3
            };
            var feedCorn4 = new Purchase()
            {
                Name = "Corn",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 1.6,
                Unit = Unit.Ton,
                UnitPrice = 365,
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
                FarmId = 1
            };
            var feedWheat2 = new Purchase()
            {
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 2.6,
                Unit = Unit.Ton,
                UnitPrice = 270,
                FarmId = 2
            };
            var feedWheat3 = new Purchase()
            {
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 2.1,
                Unit = Unit.Ton,
                UnitPrice = 270,
                FarmId = 3
            };
            var feedWheat4 = new Purchase()
            {
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 2,
                Unit = Unit.Ton,
                UnitPrice = 270,
                FarmId = 4
            };
            var feedWheat5 = new Purchase()
            {
                Name = "Wheat",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 3.5,
                Unit = Unit.Ton,
                UnitPrice = 270,
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
                FarmId = 5
            };
            var feedMix2 = new Purchase()
            {
                Name = "Mix-algae, seed, vegetables, grain, fruit",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 50,
                Unit = Unit.Kg,
                UnitPrice = 8.5m,
                FarmId = 5
            };
            var feedMix3 = new Purchase()
            {
                Name = "Mix- algae, grain, seed, herbs",
                PurchaseCategory = PurchaseCategory.Feed,
                Amount = 100,
                Unit = Unit.Kg,
                UnitPrice = 7,
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
                FarmId = 1
            };
            var toyEquipment2 = new Purchase()
            {
                Name = "Tunnel of willow twigs",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 15,
                UnitPrice = 7.90m,
                FarmId = 2
            };
            var toyEquipment3 = new Purchase()
            {
                Name = "Wooden hut",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 10,
                UnitPrice = 27.90m,
                FarmId = 5
            };
            var drinkEquipment1 = new Purchase()
            {
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 40,
                UnitPrice = 4.90m,
                FarmId = 1
            };
            var drinkEquipment2 = new Purchase()
            {
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 45,
                UnitPrice = 4.90m,
                FarmId = 2
            };
            var drinkEquipment3 = new Purchase()
            {
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 60,
                UnitPrice = 4.90m,
                FarmId = 3
            };
            var drinkEquipment4 = new Purchase()
            {
                Name = "Glass drinker",
                PurchaseCategory = PurchaseCategory.Equipment,
                Amount = 35,
                UnitPrice = 4.90m,
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
                FarmId = 1
            };
            var vaccinePestorin2 = new Purchase()
            {
                Name = "PESTORIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 55,
                UnitPrice = 2.40m,
                FarmId = 2
            };
            var vaccineMyxoren1 = new Purchase()
            {
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 60,
                UnitPrice = 2.80m,
                FarmId = 3
            };
            var vaccineMyxoren2 = new Purchase()
            {
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 65,
                UnitPrice = 2.80m,
                FarmId = 4
            };
            var vaccineMyxoren3 = new Purchase()
            {
                Name = "MYXOREN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 80,
                UnitPrice = 2.80m,
                FarmId = 5
            };
            var vaccineErisin1 = new Purchase()
            {
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 20,
                UnitPrice = 5.50m,
                FarmId = 3
            };
            var vaccineErisin2 = new Purchase()
            {
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 15,
                UnitPrice = 5.50m,
                FarmId = 4
            };
            var vaccineErisin3 = new Purchase()
            {
                Name = "ERISIN",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 30,
                UnitPrice = 5.50m,
                FarmId = 5
            };
            var vaccineCanverm1 = new Purchase()
            {
                Name = "CANIVERM",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 15,
                UnitPrice = 6.10m,
                FarmId = 1
            };
            var vaccineCanverm2 = new Purchase()
            {
                Name = "CANIVERM",
                PurchaseCategory = PurchaseCategory.Medicine,
                Amount = 20,
                UnitPrice = 6.10m,
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

            context.SaveChanges();
        }

        private void SeedRabbitsWithLitters(RabbitFarmContext context)
        {
            #region Rabbits
            var rabbit1 = new Rabbit()
            {
                Id = 1,
                Mark = "10-12-35-43",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 13,
                FarmId = 2
            };
            var rabbit2 = new Rabbit()
            {
                Id = 2,
                Mark = "15-15-36-32",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 12,
                FarmId = 1
            };
            var rabbit3 = new Rabbit()
            {
                Id = 3,
                Mark = "11-24-65-23",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 11,
                FarmId = 3
            };
            var rabbit4 = new Rabbit()
            {
                Id = 4,
                Mark = "24-21-46-32",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 10,
                FarmId = 4
            };
            var rabbit5 = new Rabbit()
            {
                Id = 5,
                Mark = "32-23-12-43",
                Gender = Gender.Male,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 9,
                FarmId = 5
            };
            var rabbit6 = new Rabbit()
            {
                Id = 6,
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
                Id = 8,
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 6,
                FarmId = 3
            };
            var rabbit9 = new Rabbit()
            {
                Id = 9,
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 5,
                FarmId = 5
            };
            var rabbit10 = new Rabbit()
            {
                Id = 10,
                Mark = "23-11-54-32",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 4,
                FarmId = 5
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

            context.SaveChanges();
            #endregion

            #region Litters
            var litter1 = new Litter()
            {
                BirthDate = new DateTime(2014, 3, 22),
                Mother = rabbit5,
                Father = rabbit6,
                FarmId = 1
            };
            var litter2 = new Litter()
            {
                BirthDate = new DateTime(2014, 4, 14),
                Mother = rabbit4,
                Father = rabbit7,
                FarmId = 2
            };
            var litter3 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 20),
                Mother = rabbit3,
                Father = rabbit8,
                FarmId = 3
            };

            var litter4 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 21),
                Mother = rabbit2,
                Father = rabbit9,
                FarmId = 4
            };
            var litter5 = new Litter()
            {
                BirthDate = new DateTime(2014, 12, 21),
                Mother = rabbit1,
                Father = rabbit10,
                FarmId = 5
            };


            context.Litters.AddOrUpdate(litter1);
            context.Litters.AddOrUpdate(litter2);
            context.Litters.AddOrUpdate(litter3);
            context.Litters.AddOrUpdate(litter4);
            context.Litters.AddOrUpdate(litter5);
            #endregion

            #region Rabbits With Litters
            var rabbit11 = new Rabbit()
            {
                Mark = "21-42-53-21",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 3,
                Litter = litter1,
                FarmId = 1
            };
            var rabbit12 = new Rabbit()
            {
                Mark = "32-25-42-12",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                AcquisitionId = 2,
                Litter = litter2,
                FarmId = 2
            };
            var rabbit13 = new Rabbit()
            {
                Mark = "32-25-42-12",
                Gender = Gender.Female,
                Status = RabbitStatus.InFarm,
                Litter = litter2,
                AcquisitionId = 1,
                FarmId = 2
            };

            
            context.Rabbits.AddOrUpdate(rabbit11);
            context.Rabbits.AddOrUpdate(rabbit12);
            context.Rabbits.AddOrUpdate(rabbit13);
            #endregion

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

            context.SaveChanges();
        }

        private void SeedCage(RabbitFarmContext context)
        {
            #region Cages
            Cage cage1 = new Cage()
            {
                Height = 200,
                Width = 200,
                Length = 200,
                FarmId = 1
            };
            Cage cage2 = new Cage()
            {
                Height = 160,
                Width = 180,
                Length = 160,
                FarmId = 2
            };
            Cage cage3 = new Cage()
            {
                Height = 150,
                Width = 150,
                Length = 150,
                FarmId = 3
            };
            Cage cage4 = new Cage()
            {
                Height = 350,
                Width = 160,
                Length = 210,
                FarmId = 4
            };
            Cage cage5 = new Cage()
            {
                Height = 300,
                Width = 200,
                Length = 100,
                FarmId = 5
            };
            Cage cage6 = new Cage()
            {
                Height = 200,
                Width = 200,
                Length = 200,
                FarmId = 1
            };
            Cage cage7 = new Cage()
            {
                Height = 160,
                Width = 180,
                Length = 160,
                FarmId = 2
            };
            Cage cage8 = new Cage()
            {
                Height = 150,
                Width = 150,
                Length = 150,
                FarmId = 3
            };
            Cage cage9 = new Cage()
            {
                Height = 350,
                Width = 160,
                Length = 210,
                FarmId = 4
            };
            Cage cage10 = new Cage()
            {
                Height = 300,
                Width = 200,
                Length = 100,
                FarmId = 5
            };
            #endregion


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

            context.SaveChanges();
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

            context.SaveChanges();
        }

        private void SeedCageChange(RabbitFarmContext context)
        {
            var cageChanges1 = new CageChange()
            {
                StartingDate = new DateTime(2015, 1, 13),
                RabbitId = 13,
                FarmId = 2
            };
            cageChanges1.Cages.Add(context.Cages.Find(1));

            var cageChanges2 = new CageChange()
            {
                StartingDate = new DateTime(2015, 2, 9),
                RabbitId = 12,
                FarmId = 1
            };
            cageChanges2.Cages.Add(context.Cages.Find(2));

            var cageChanges3 = new CageChange()
            {
                StartingDate = new DateTime(2015, 1, 25),
                RabbitId = 4,
                FarmId = 5
            };
            cageChanges3.Cages.Add(context.Cages.Find(3));

            var cageChanges4 = new CageChange()
            {
                StartingDate = new DateTime(2015, 1, 17),
                RabbitId = 10,
                FarmId = 4
            };
            cageChanges4.Cages.Add(context.Cages.Find(4));

            var cageChanges5 = new CageChange()
            {
                StartingDate = new DateTime(2015, 2, 8),
                RabbitId = 6,
                FarmId = 3
            };
            cageChanges5.Cages.Add(context.Cages.Find(5));

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
                FarmId = 1,
                Price = 0
            };
            var realizationDeath2 = new Realization()
            {
                Id = 2,
                RealizationDate = new DateTime(2014, 2, 15),
                RealizationChannel = RealizationChannel.Death,
                RabbitId = 7,
                LiveWeight = 2.1,
                FarmId = 2,
                Price = 0
            };
            context.Realizations.AddOrUpdate(realizationDeath1);
            context.Realizations.AddOrUpdate(realizationDeath2);

            //seed some Sold realization
            var realizationSold1 = new Realization()
            {
                Id = 3,
                RealizationDate = new DateTime(2014, 12, 23),
                RealizationChannel = RealizationChannel.Sold,
                RabbitId = 2,
                LiveWeight = 3.1,
                FarmId = 3,
                Price = 9.85m
            };
            var realizationSold2 = new Realization()
            {
                Id = 4,
                RealizationDate = new DateTime(2014, 12, 22),
                RealizationChannel = RealizationChannel.Sold,
                RabbitId = 5,
                LiveWeight = 2.7,
                FarmId = 4,
                Price = 9.29m
            };
            context.Realizations.AddOrUpdate(realizationSold1);
            context.Realizations.AddOrUpdate(realizationSold2);

            //seed slain realization
            var realizationsSlain = new Realization()
            {
                Id = 5,
                RealizationDate = new DateTime(2014, 8, 10),
                RealizationChannel = RealizationChannel.Slain,
                RabbitId = 9,
                LiveWeight = 3.4,
                FarmId = 5,
                Price = 0
            };
            context.Realizations.AddOrUpdate(realizationsSlain);

            context.SaveChanges();
        }
    }
}
