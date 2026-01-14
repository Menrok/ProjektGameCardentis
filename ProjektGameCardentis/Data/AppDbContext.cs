using Microsoft.EntityFrameworkCore;
using ProjektGameCardentis.Entities;

namespace ProjektGameCardentis.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}
