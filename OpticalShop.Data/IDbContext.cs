using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace OpticalShop.Data
{
    /// <summary>
    /// Database context interface
    /// </summary>
    public interface IDbContext
    {
        /// <summary>
        /// Entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        /// <summary>
        /// Use method when commit the data into database
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        /// <summary>
        /// Release all resources
        /// </summary>
        void Dispose();
    }
}
