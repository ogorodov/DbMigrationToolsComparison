//using FluentMigrator;

//namespace DbMigrationsComparison.MigrationFluentMigrator
//{
//    [Migration(202203112004)]
//    public class Remove_property_SomeOtherProperty_From_Company_table : Migration
//    {
//        public override void Down()
//        {
//            Create.Column("SomeOtherProperty").OnTable("Companies").AsString(50).NotNullable();
//        }

//        public override void Up()
//        {
//            Delete.Column("SomeOtherProperty").FromTable("Companies");
//        }
//    }
//}
