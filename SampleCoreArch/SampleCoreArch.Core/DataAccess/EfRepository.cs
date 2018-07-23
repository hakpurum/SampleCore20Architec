using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SampleCoreArch.Core.Interfaces;

namespace SampleCoreArch.Core.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <seealso cref="SampleCoreArch.Core.Interfaces.IEntityRepository{TEntity}" />
    public class EfRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class, IEntity, new()
    {
        /// <summary>
        /// The context
        /// </summary>
        protected DbContext Context;
        /// <summary>
        /// The dbset
        /// </summary>
        protected DbSet<TEntity> Dbset;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EfRepository(DbContext context)
        {
            Context = context;
            Dbset = Context.Set<TEntity>();
        }

        /// <summary>
        /// Gets the find by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TEntity GetFindById(int id)
        {
            return Dbset.Find(id);
        }

        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public virtual TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return Dbset.FirstOrDefault(filter);
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                ? Dbset
                : Dbset.Where(filter);
        }

        /// <summary>
        /// Gets the list paging.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="total">The total.</param>
        /// <param name="index">The index.</param>
        /// <param name="size">The size.</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetListPaging(Expression<Func<TEntity, bool>> filter, out int total, int index, int size)
        {
            var skipCount = index * size;
            var resetSet = filter != null ? Dbset.Where(filter).AsQueryable() : Dbset.AsQueryable();

            resetSet = skipCount == 0 ? resetSet.Take(size) : resetSet.Skip(skipCount).Take(size);

            total = resetSet.Count();

            return resetSet;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            return Dbset.Add(entity).Entity;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var updateEntity = Context.Entry(entity);
            updateEntity.State = EntityState.Modified;
            return updateEntity.Entity;
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Dbset.Attach(entity);
            Dbset.Remove(entity);
        }

        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="listEntity">The list entity.</param>
        /// <exception cref="ArgumentNullException">listEntity</exception>
        public virtual void AddRange(IEnumerable<TEntity> listEntity)
        {
            if (listEntity == null)
                throw new ArgumentNullException("listEntity");
            foreach (var entity in listEntity)
            {
                Dbset.Add(entity);
            }
        }

        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public virtual void Delete(Expression<Func<TEntity, bool>> filter)
        {
            var entity = Get(filter);
            if (entity == null) return;
            var entry = Context.Entry(entity);
            if (entry.State == EntityState.Detached)
                Dbset.Attach(entity);
            Dbset.Remove(entity);
        }

        /// <summary>
        /// Deletes all.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public virtual void DeleteAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null) return;
            var getDeleteList = GetList(filter);
            foreach (var item in getDeleteList)
            {
                Delete(item);
            }
        }

        /// <summary>
        /// UnitOfWork kullanılmak istenmediğinde SaveChange işlemi manuel olarak tetiklenir.
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void CustomSaveChanges()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            Context?.Dispose();
            GC.SuppressFinalize(this);
        }

       
    }
}