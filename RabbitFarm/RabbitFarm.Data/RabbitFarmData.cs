namespace RabbitFarm.Data
{
    using System;
    using System.Collections.Generic;

    using Models;
    using Repositories;

    public class RabbitFarmData : IRabbitFarmData
    {
        private IRabbitFarmDBContext context;
        private IDictionary<Type, object> repositories;

        public RabbitFarmData()
            : this(new RabbitFarmContext())
        {

        }

        public RabbitFarmData(IRabbitFarmDBContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Acquisition> Acquisitions
        {
            get
            {
                return this.GetRepository<Acquisition>();
            }
        }

        public IRepository<Cage> Cages
        {
            get
            {
                return this.GetRepository<Cage>();
            }
        }

        public IRepository<CageChange> CageChanges
        {
            get
            {
                return this.GetRepository<CageChange>();
            }
        }

        public IRepository<Farm> Farms
        {
            get
            {
                return this.GetRepository<Farm>();
            }
        }

        public IRepository<Feeding> Feedings
        {
            get
            {
                return this.GetRepository<Feeding>();
            }
        }

        public IRepository<Litter> Litters
        {
            get
            {
                return this.GetRepository<Litter>();
            }
        }

        public IRepository<Purchase> Purchases
        {
            get
            {
                return this.GetRepository<Purchase>();
            }
        }

        public IRepository<Rabbit> Rabbits
        {
            get
            {
                return this.GetRepository<Rabbit>();
            }
        }

        public IRepository<Realization> Realizations
        {
            get
            {
                return this.GetRepository<Realization>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}