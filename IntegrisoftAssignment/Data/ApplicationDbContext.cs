using IntegrisoftAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegrisoftAssignment.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() { }

    public ApplicationDbContext(DbContextOptions options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=Universitate;Trusted_Connection=True;TrustServerCertificate=True;");
        base.OnConfiguring(optionsBuilder);

    }
    
    public DbSet<Note> Note { get; set; }

    public DbSet<Student> Student { get; set; }

    public DbSet<Materie> Materie { get; set; }
}


