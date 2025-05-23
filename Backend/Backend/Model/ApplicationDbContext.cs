using Microsoft.EntityFrameworkCore;

namespace Backend.Model
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Person> Person { get; set; } = null!;
        public DbSet<Country> Countries { get; set; } = null!;

        public DbSet<Representative> Representative { get; set; } = null!;


        public DbSet<Forms> Forms { get; set; } = null!;

        

    }
}
