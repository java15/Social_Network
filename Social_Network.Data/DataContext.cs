using System.Data.Entity;
using Social_Network.Core;
using Social_Network.Core.Entities;

namespace Social_Network.Data
{
    public class DataContext : DbContext,IDataContext
    {
        public DataContext()
            : base("SocialNetwork")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users").HasKey(q => q.Id);
        }

        public int SaveChange()
        {
            throw new System.NotImplementedException();
        }
    }
}
