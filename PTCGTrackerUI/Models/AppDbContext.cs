using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PTCGTrackerUI.Models;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<DeckModel> Decks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<DeckModel>(entity =>
        {
            entity.ToTable("Deck");

            entity.HasKey(d => d.deckId);

            entity.Property(d => d.deckId)
                .HasColumnName("d_deckid");

            entity.Property(d => d.userId)
                .HasColumnName("d_userid");

            entity.Property(d => d.name)
                .HasColumnName("d_name");

            entity.Property(d => d.wins)
                .HasColumnName("d_wins");

            entity.Property(d => d.losses)
                .HasColumnName("d_losses");
        });
    }
}