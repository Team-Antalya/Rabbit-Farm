﻿namespace RabbitFarm.Data.Repositories
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> set;


        public Repository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
            return entity;
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public T Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
            return entity;
        }

        public void Detach(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Detached);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }


        public T Find(object id)
        {
            return this.set.Find(id);
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return this.set.Where(predicate);
        }

        public void Update(object id)
        {
            var entity = this.Find(id);
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public T Delete(object Id)
        {
            var entity = this.Find(Id);
            this.ChangeEntityState(entity, EntityState.Deleted);
            return entity;
        }
    }
}
