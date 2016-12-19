using OpticalShop.Core.Domain;
using System;
using System.Linq;

namespace OpticalShop.Data
{
    /// <summary>
    /// Generic Repository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable where T : EntityBase
    {
        /// <summary>
        /// Get By primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T GetById(object id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity"></param>
        void Insert(T entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        void Update(T entity);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity"></param>
        void Delete(T entity);

        /// <summary>
        /// Represent table of entity
        /// </summary>
        IQueryable<T> Table { get; }
    }
}
