using Microsoft.EntityFrameworkCore;
using ProjektGameCardentis.Domain.Entities;

namespace ProjektGameCardentis.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}