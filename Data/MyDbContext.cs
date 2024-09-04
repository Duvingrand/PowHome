
using Microsoft.EntityFrameworkCore;
using PowHome.Models;

namespace PowHome.Data
{
    public class MyDbContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Specie> species { get; set; }
        public DbSet<Condition> conditions { get; set; }
        public DbSet<Donation> donations { get; set; }
        public DbSet<AdoptionCenter> adoption_centers { get; set; }
        public DbSet<Animal> animals { get; set; }
        public DbSet<AnimalCondition> animal_conditions { get; set; }
        public DbSet<Sponsorshipment> sponsorshipments { get; set; }
        public DbSet<Product> products { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
    }
}