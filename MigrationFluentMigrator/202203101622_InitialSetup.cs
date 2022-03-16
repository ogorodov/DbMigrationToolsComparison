using FluentMigrator;

namespace DbMigrationsComparison.MigrationFluentMigrator
{
[Migration(202203101622)]
public class InitialSetup : AutoReversingMigration
{
    public override void Up()
    {
        Create.Table("Companies")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Address").AsString(60).NotNullable()
            .WithColumn("Country").AsString(50).NotNullable();

        Create.Table("Employees")
            .WithColumn("Id").AsGuid().NotNullable().PrimaryKey()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Age").AsInt32().NotNullable()
            .WithColumn("Position").AsString(50).NotNullable()
            .WithColumn("CompanyId").AsGuid().NotNullable().ForeignKey("Companies", "Id");

        //Create.Index("IX_Employees_CompanyId").OnTable("Employees").OnColumn("CompanyId");
    }
}
}