using DbMigrationsComparison.DalEf;
using DbMigrationsComparison.DalEf.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DbMigrationsComparison.EntryPointFluentMigrator
{
    public static class Programm
    {
        const string ConnectionString = "Data Source = DataEntityFramework.sqlite3";

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
            services.AddDbContext<MyDbContext>(o => o.UseSqlite(ConnectionString));
        }

        static void MigrateDb(ServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MyDbContext>();
            db.Database.Migrate();
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