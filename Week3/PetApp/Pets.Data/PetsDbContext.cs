using Microsoft.EntityFrameworkCore;
using Pets.Models;

namespace Pets.Data;

public class PetsDbContext : DbContext {
    public PetsDbContext() : base() {}
    public PetsDbContext(DbContextOptions options) : base(options) {}

    public DbSet<Pet> Pets { get; set; }
    public DbSet<Hobby> Hobbies { get; set; }

}