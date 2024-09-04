
using Microsoft.EntityFrameworkCore;
using PowHome.Models;

namespace PowHome.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Specie> Species { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<AdoptionCenter> AdoptionCenters { get; set; }
        public DbSet<Animal> Animals { get; set; }
        public DbSet<AnimalCondition> AnimalConditions { get; set; }
        public DbSet<Sponsorshipment> Sponsorshipments { get; set; }
        public DbSet<Product> Products { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}