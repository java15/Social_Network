using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using Social_Network.Core;
using Social_Network.Core.Entities.Base;
using Social_Network.Core.Interfaces.IRepositories.Base;


namespace Social_Network.Data.Repositoties.Base
{
    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="T">Type of entity</typeparam>
    public class Repository<T>: IRepository<T>  where T: EntityBase
    {
        /// <summary>
        /// Entity framework db context  
        /// </summary>
        protected readonly IDataContext _dataContext;

        /// <summary>
        /// Gets the current set
        /// </summary>
        /// <value>The current set</value>
        private DbSet<T> CurrentSet
        {
            get 
            {
                return this._dataContext.Set<T>();
            }
        }

        /// <summary>
        /// Initializes a new instance of the Repository class.
        /// </summary>
        /// <param name="context">Nhibernate session</param>
        public Repository(IDataContext context)
        {
            this._dataContext = context;
        }

        /// <summary>
        /// Get query for all entity
        /// </summary>
        /// <returns>Query for all entity</returns>
        public IQueryable<T> GetAll()
        {
            return this.CurrentSet.AsQueryable<T>();             
        }

        /// <summary>
        /// Add entity to database
        /// </summary>
        /// <param name="entity">Entity for add</param>
        /// <returns>Saved entity</returns>
        public T Add(T entity)
        { 
            this.CurrentSet.Add(entity);
            return entity;
        }

        /// <summary>
        /// Delete entity from database
        /// </summary>
        /// <param name="entity">Entity for delete</param>
        public void Delete(T entity)
        {
            this.CurrentSet.Remove(entity);
        }

        /// <summary>
        /// Save changes
        /// </summary>
        public void SaveChanges()
        {
            this._dataContext.SaveChange();
        }
    }
}
