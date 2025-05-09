using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using CarGo.Persistence.Context;

namespace CarGo.Persistence
{
    public class CarGoContextFactory : IDesignTimeDbContextFactory<CarGoContext>
    {
        public CarGoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarGoContext>();

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=CarGodb;Username=postgres;Password=1234");

            return new CarGoContext(optionsBuilder.Options);
        }
    }
}
