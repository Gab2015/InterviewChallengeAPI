using Microsoft.EntityFrameworkCore;

namespace BuberBreakfast.Models.Persistence
{
    public class BuberBreakfastDbContext:DbContext
    {
        public BuberBreakfastDbContext(DbContextOptions<BuberBreakfastDbContext> options):base(options)
        {
        }
        public DbSet<Breakfast> breakfasts { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberBreakfastDbContext).Assembly);
        }
    }
}
