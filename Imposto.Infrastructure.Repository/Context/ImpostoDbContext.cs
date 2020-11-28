using System.Data.Entity;

namespace Imposto.Infrastructure.Repository.Context
{
    public class ImpostoDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(ImpostoDbContext).Assembly);
        }
    }
}