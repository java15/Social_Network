using System.Data;
using Migrator.Framework;


namespace Social_Network.Data.Migrations.Migrations
{
    [Migration(1)]

    public class M0001_CreateUserTable : Migration
    {
        public override void Up()
        {
            Database.AddTable(
                "Users",
                new Column("Id", DbType.Int64, ColumnProperty.PrimaryKeyWithIdentity),
                new Column("Login", DbType.String, 30, ColumnProperty.NotNull),
                new Column("Password", DbType.String, 30, ColumnProperty.NotNull));
        }

        public override void Down()
        {
            Database.RemoveTable("Users");
        }
    }
}
 