using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PTCGTrackerUI.Models;

public class AppDbContext : IdentityDbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<DeckModel> Decks { get; set; }
    public DbSet<DeckCardModel> DeckCards { get; set; }
    public DbSet<UserModel> AllUsers { get; set; }

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

            entity.Property(d => d.version)
                .HasColumnName("d_version");
        });

        modelBuilder.Entity<DeckCardModel>(entity =>
        {
            entity.ToTable("DeckCard");

            entity.HasKey(c => c.cardId);

            entity.Property(c => c.cardId)
                .HasColumnName("dc_cardid"); 

            entity.Property(c => c.deckId)
                .HasColumnName("dc_deckid");

            entity.Property(c => c.qtylist)
                .HasColumnName("dc_qtylist");

            entity.Property(c => c.qtydeck)
                .HasColumnName("dc_qtydeck");

            entity.Property(c => c.name)
                .HasColumnName("dc_name");

            entity.Property(c => c.set)
                .HasColumnName("dc_set");

            entity.Property(c => c.reg)
                .HasColumnName("dc_reg");

            entity.Property(c => c.type)
                .HasColumnName("dc_type");

            entity.Property(c => c.setNumber)
                .HasColumnName("dc_setnumber");
        });

        modelBuilder.Entity<UserModel>(entity =>
        {
            entity.ToTable("User");

            entity.HasKey(u => u.id);

            entity.Property(u => u.id)
                .HasColumnName("u_userid"); 

            entity.Property(u => u.username)
                .HasColumnName("u_username");

        });
    }
}