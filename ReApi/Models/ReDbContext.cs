

namespace ReApi.Models
{
    public class ReDbContext : DbContext
    {
        public ReDbContext(DbContextOptions<ReDbContext> dbContextOptions) : base (dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Messages>().ToTable("Messagess");
        }

        public DbSet<Meal> Meals { get; set; }
        public DbSet<Catigory> Catigorys { get; set; }
        public DbSet<Messages> Messagess { get; set; }
        
    }
}
