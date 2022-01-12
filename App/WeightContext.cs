using Microsoft.EntityFrameworkCore;

namespace App
{
    public class WeightContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectsV13; Integrated Security=True; Database=Weight_DB;");
        }
    }
}
