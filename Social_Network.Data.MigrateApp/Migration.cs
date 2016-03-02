using System;
using Social_Network.Data.Migrations.Migrations;


namespace Social_Network.Data.MigrateApp
{
    public class Migration
    {
        private const string _sqlServer = "SqlServer";

        public void MigrateToLast(string[] connectionString)
        {
            foreach (string connString in connectionString)
            {
                var migrator = new Migrator.Migrator(_sqlServer, connString, typeof(M0001_CreateUserTable).Assembly);
                migrator.MigrateToLastVersion();                
            }
        }

        public void MigtateTo(string[] connectionString, int version)
        {
            foreach (string connString in connectionString)
            {
                var migrator = new Migrator.Migrator(_sqlServer, connString, typeof(M0001_CreateUserTable).Assembly);
                migrator.MigrateTo(version);
            }
        }
    }
}
