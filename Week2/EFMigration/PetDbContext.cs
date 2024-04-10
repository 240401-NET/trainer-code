using Microsoft.EntityFrameworkCore;

public class PetDbContext : DbContext
{
    public PetDbContext()
    {
    }

    public PetDbContext(DbContextOptions<PetDbContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring (Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.UseSqlServer(File.ReadAllText("connectionstring.txt"));
    }
    DbSet<Pet> pets { get; set; }
    DbSet<Hobby> hobbies { get; set; }
}