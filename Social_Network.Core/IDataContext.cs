using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Social_Network.Core
{
    public interface IDataContext
    {
        /// <summary>
        /// Gets the database
        /// </summary>
        Database Database { get;}

        /// <summary>
        /// Gets the cofiguration
        /// </summary>
        /// <value>The configuratin</value>
        DbContextConfiguration Configuration { get; }

        /// <summary>
        /// Gets the change tracker
        /// </summary>
        /// <value>The change tracker</value>
        DbChangeTracker ChangeTracker { get; }

        /// <summary>
        /// Saved changes
        /// </summary>
        /// <returns>Rows affacted</returns>
        int SaveChange();

        /// <summary>
        /// Entries the specified entity
        /// </summary>
        /// <typeparam name="T">The type of entity</typeparam>
        /// <param name="entry">The entity</param>
        /// <returns>The entry of entity</returns>
        DbEntityEntry<T> Entry<T>(T entry) where T : class;

        /// <summary>
        /// Sets this instance 
        /// </summary>
        /// <typeparam name="T">The type of entity</typeparam>
        /// <returns>The db set of T</returns>
        DbSet<T> Set<T>() where T : class;
    }
}
