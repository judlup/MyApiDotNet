using Microsoft.EntityFrameworkCore;
using MyAPI.Models.Domain;

namespace MyAPI.Data
{
    public class MyAPIDBContext : DbContext
    {
        public MyAPIDBContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Seed data for Difficulty
            modelBuilder.Entity<Difficulty>().HasData(
                new Difficulty { Id = Guid.Parse("ec689ad5-2d6f-4011-a005-6af5b39ecd83"), Name = "Easy" },
                new Difficulty { Id = Guid.Parse("b2b42162-1c2a-4da1-9978-d5df0f3551e9"), Name = "Moderate" },
                new Difficulty { Id = Guid.Parse("25ff9e69-0b60-4643-8320-973662ee2e15"), Name = "Hard" }
            );

            // Seed data for Region
            modelBuilder.Entity<Region>().HasData(
                new Region { Id = Guid.Parse("d889a6b8-7bea-40a4-be8b-b21c9eda2a51"), Name = "North", Code = "N", RegionImageUrl = "n.pjg" },
                new Region { Id = Guid.Parse("39528d95-4f8f-48d9-a685-aded7b946f2f"), Name = "South", Code = "S", RegionImageUrl = "s.jpg" },
                new Region { Id = Guid.Parse("938f4c68-7e31-4427-ab38-48c9f3cdf683"), Name = "East", Code = "E", RegionImageUrl = "e.jpg" },
                new Region { Id = Guid.Parse("b6803ecb-f2a9-4497-94b8-672bab7bf629"), Name = "West", Code = "W", RegionImageUrl = "w.jpg" }
            );
        }
    }
}

	
