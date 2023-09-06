using Microsoft.EntityFrameworkCore;
using BoilerPlate.Models;

namespace BoilerPlate.Data
{
    public class BoilerPlateContext : DbContext
    {
        public BoilerPlateContext(DbContextOptions<BoilerPlateContext> options)
            : base(options)
        {
        }

        public DbSet<Shape> Shape { get; set; } = default!;

        public DbSet<People> People { get; set; } = default!;

    }
}
