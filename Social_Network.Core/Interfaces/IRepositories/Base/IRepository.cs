using System.Linq;
using Social_Network.Core.Entities.Base;

namespace Social_Network.Core.Interfaces.IRepositories.Base
{
    /// <summary>
    /// Base interface repository
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public interface IRepository<T> where T : EntityBase
    {
        /// <summary>
        /// Gets query for all entities
        /// </summary>
        /// <returns>Query for all entities</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity">Entity for add</param>
        /// <returns>Saved entity</returns>
        T Add(T entity);

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity">Entity for delete</param>
        void Delete(T entity);

        /// <summary>
        /// Save changes
        /// </summary>
        void SaveChanges();
    }
}
