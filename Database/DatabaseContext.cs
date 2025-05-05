using CloneCode.Entity;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace CloneCode.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("public");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);


            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>(); // UserSecrets 활성화

            var configuration = builder.Build();
            var connectionString = configuration["ConnectionString"];


            optionsBuilder.UseNpgsql(
                connectionString)
                .UseCamelCaseNamingConvention();
        }
    }
}
