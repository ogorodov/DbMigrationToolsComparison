using DbMigrationsComparison.DalEf.Entities;
using Microsoft.EntityFrameworkCore;

namespace DbMigrationsComparison.DalEf
{
    public class MyDbContext : DbContext
    {
        private readonly string _connectionString;

        public MyDbContext() : base()
        {
            _connectionString = "Data Source = NotExistedDb.sqlite3";
        }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        { 
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(_connectionString != null)
                optionsBuilder.UseSqlite(_connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}
