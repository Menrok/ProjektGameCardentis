using Microsoft.EntityFrameworkCore;
using ProjektGameCardentis.Entities.Auth;
using ProjektGameCardentis.Entities.Players;

namespace ProjektGameCardentis.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Player> Players => Set<Player>();

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasOne(u => u.Player)
            .WithOne(p => p.User)
            .HasForeignKey<Player>(p => p.UserId);

        modelBuilder.Entity<Player>()
            .OwnsOne(p => p.Deck, deck =>
            {
                deck.OwnsMany(d => d.Cards, card =>
                {
                    card.ToTable("PlayerDeckCards");

                    card.WithOwner()
                        .HasForeignKey("PlayerId");

                    card.HasKey(c => c.Id);

                    card.Property(c => c.Name).IsRequired();
                    card.Property(c => c.ManaCost);
                    card.Property(c => c.EffectValue);
                });
            });
    }
}
