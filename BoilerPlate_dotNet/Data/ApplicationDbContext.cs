using BoilerPlate_dotNet.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace BoilerPlate_dotNet.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Personne> Personne { get; set; }

        public DbSet<Competence> Competence{ get; set; }

        public DbSet<Evaluation> Evaluation { get; set; }
    }
}
