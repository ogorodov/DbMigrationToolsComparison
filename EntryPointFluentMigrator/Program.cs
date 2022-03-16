using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using FluentMigrator.Runner;
using DbMigrationsComparison.DalEf;
using DbMigrationsComparison.MigrationFluentMigrator;
using DbMigrationsComparison.DalEf.Entities;

namespace DbMigrationsComparison.EntryPointFluentMigrator
{
    public static class Programm
    {
        const string ConnectionString = "Data Source = DataFluentMigrator.sqlite3";

        public static void Main()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            MigrateDb(serviceProvider);
            InsertTestData(serviceProvider.GetRequiredService<MyDbContext>());

            Console.WriteLine("Бд создана");
        }

        static void ConfigureServices(IServiceCollection services)
        {
            // EntityFramework
            services.AddDbContext<MyDbContext>(o => o.UseSqlite(ConnectionString));

            // FluentMigrator
            services
                .AddFluentMigratorCore()
                .ConfigureRunner(c => c.AddSQLite()
                    .WithGlobalConnectionString(ConnectionString)
                    .ScanIn(typeof(InitialSetup).Assembly).For.Migrations());
        }

        static void MigrateDb(ServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            migrationService.MigrateUp();
        }

        static void InsertTestData(MyDbContext dbContext)
        {
            var company = new Company { Name = "ООО \"В гостях у сказки\"", Address = "Гиблая топь", Country = "Тридевятое царство" };
            var employee = new Employee { Name = "баба Яга", Age = 380, Company = company, Position = "Директрисса" };

            dbContext.Companies.Add(company);
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
        }
    }
}
    




