// <copyright file="RepositoryBase.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CSales.Database.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public RepositoryBase(TContext context)
        {
            this.Context = context;
        }

        /// <summary>
        /// The context used in this repository.
        /// </summary>
        public virtual TContext Context { get; protected set; }

        /// <summary>
        /// When is override in a deriver type, returns all the elements in the entity set.
        /// </summary>
        /// <returns>
        /// An <see cref="IQueryable"/> for all the elements in the entity set
        /// </returns>
        public abstract IQueryable<TEntity> All();

        /// <summary>
        /// Filters a list of values based on a <see cref="IEnumerable{PropertyFilter}"/>.
        /// </summary>
        /// <param name="filters">
        /// A collection of filters.
        /// </param>
        /// <returns>
        /// An <see cref="IQueryable"/> that contains elements from the input sequence that satisfy the condition specified by predicate.
        

        /// <summary>
        /// Filters an entity set of values based on a predicate.
        /// </summary>
        /// <param name="predicate">
        /// An expression to test each element for a condition.
        /// </param>
        /// <returns>
        /// An <see cref="IQueryable"/> that contains elements from the input sequence that satisfy the condition specified by predicate.
        /// </returns>
        public virtual IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate)
        {
            return this.All().Where(predicate);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form.
        /// </summary>
        /// <param name="predicate">
        /// A sequence of values to project.
        /// </param>
        /// <typeparam name="TResult">
        /// The type of the elements of source.
        /// </typeparam>
        /// <returns>
        /// An <see cref="IQueryable"/> whose elements are the result of invoking a projection function on each element of source.
        /// </returns>
        public virtual IQueryable<TResult> Transform<TResult>(Expression<Func<TEntity, TResult>> predicate)
        {
            return this.All().Select(predicate);
        }

        /// <summary>
        /// Returns the first element of a sequence.
        /// </summary>
        /// <param name="predicate">
        /// An expression to return the first element of a condition.
        /// </param>
        /// <returns>
        /// The first element that satisfies the condition.
        /// </returns>
        public virtual TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Filter(predicate).First();
        }

        public virtual TEntity Find(params object[] keys)
        {
            return ((DbSet<TEntity>)this.All()).Find(keys);
        }

        public virtual Task<TEntity> FindAsync(params object[] keys)
        {
            return this.FindAsync(CancellationToken.None, keys);
        }

        public virtual Task<TEntity> FindAsync(CancellationToken token, params object[] keys)
        {
            return ((DbSet<TEntity>)this.All()).FindAsync(token, keys);
        }

        /// <summary>
        /// Returns the first element of a sequence.
        /// </summary>
        /// <param name="predicate">
        /// An expression to return the first element of a condition.
        /// </param>
        /// <returns>
        /// The first element that satisfies the condition.
        /// </returns>
        public virtual Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return this.Filter(predicate).FirstAsync();
        }

        /// <summary>
        /// Returns the first element based on property filter
        /// </summary>
        /// <param name="filters">
        /// A collection of filters.
        /// </param>
        /// <returns>
        /// The first element that satisfies the collection of filters.
        /// </returns
        /// <summary>
        /// Returns the first element based on property filter
        /// </summary>
        /// <param name="filters">
        /// A collection of filters.
        /// </param>
        /// <returns>
        /// The first element that satisfies the collection of filters.
        /// </returns>

        /// <summary>
        /// Creates a new instance of an entity for the type of this set, and the state is marked as added.
        /// </summary>
        /// <returns>
        /// A new entity instance
        /// </returns>
        public virtual TEntity Create()
        {
            IDbSet<TEntity> set = this.Context.Set<TEntity>();
            var entity = set.Create();
            this.Context.Entry(entity).State = EntityState.Added;
            return entity;
        }

        /// <summary>
        /// Marks the entity as added
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as added.
        /// </returns>
        public virtual TEntity Create(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Added;
            return entity;
        }

        /// <summary>
        /// Marks the entity as modified.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as modified.
        /// </returns>
        public virtual TEntity Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Modified;
            return entity;
        }

        /// <summary>
        /// Marks the entity as deleted.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The entity with its state marked as deleted.
        /// </returns>
        public virtual TEntity Delete(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            entry.State = EntityState.Deleted;
            return entity;
        }

        /// <summary>
        /// Copy values of new entity to old entity, new entity is marked as detached, and old entity is marked as modified.
        /// </summary>
        /// <param name="oldEntity">
        /// The old entity.
        /// </param>
        /// <param name="newEntity">
        /// The new entity.
        /// </param>
        /// <returns>
        /// The modified entity
        /// </returns>
        public virtual TEntity Update(TEntity oldEntity, TEntity newEntity)
        {
            var newEntry = this.Context.Entry(newEntity);
            newEntry.State = EntityState.Detached;

            var oldEntry = this.Context.Entry(oldEntity);
            oldEntry.State = EntityState.Modified;

            return this.MapNewValuesToOld(oldEntity, newEntity);
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns></returns>
        public virtual int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public virtual Task<int> SaveChangesAsync()
        {
            try
            {
                return this.Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
                //throw new DataConcurrencyException(ex.Message, ex);
            }
        }

        /// <summary>
        /// Returns the first element of the entity set with the specified condition, or a default value if the entity set contains no elements.
        /// </summary>
        /// <param name="filters">
        /// A collection of filters.
        /// </param>
        /// <returns>
        /// default value, if the source is empty; otherwise, the first element in source.
        /// </returns>

        /// <summary>
        /// Returns the first element of the entity set with the specified condition, or a default value if the entity set contains no elements.
        /// </summary>
        /// <param name="filters">
        /// A collection of filters.
        /// </param>
        /// <returns>
        /// default value, if the source is empty; otherwise, the first element in source.
        /// </returns>
        /// <summary>
        /// Returns the first element of the entity set with the specified condition, or a default value if the entity set contains no elements.
        /// </summary>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// default value, if the source is empty; otherwise, the first element in source.
        /// </returns>
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this.All().Where(predicate).FirstOrDefault();
        }

        /// <summary>
        /// Returns the first element of the entity set with the specified condition, or a default value if the entity set contains no elements.
        /// </summary>
        /// <param name="predicate">
        /// A function to test each element for a condition.
        /// </param>
        /// <returns>
        /// default value, if the source is empty; otherwise, the first element in source.
        /// </returns>
        public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return this.All().Where(predicate).FirstOrDefaultAsync();
        }

        public void SetOriginalValue<TValue>(TEntity entity, string propertyName, TValue value)
        {
            this.Context.Entry(entity).OriginalValues[propertyName] = value;
        }

        /// <summary>
        /// Set the new entity values, to old entity instance that is obtained from the database.
        /// </summary>
        /// <param name="oldEntity">
        /// The old entity.
        /// </param>
        /// <param name="newEntity">
        /// The new entity.
        /// </param>
        /// <returns>
        /// The old entity with its state marked as modified.
        /// </returns>
        protected abstract TEntity MapNewValuesToOld(TEntity oldEntity, TEntity newEntity);
    }
}
