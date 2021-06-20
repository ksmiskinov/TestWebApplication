using Microsoft.EntityFrameworkCore;
using System;
using DeckCards.Domain;

namespace DeckCards.Data.cs
{
  public class DeckData : DbContext
  {


    public DbSet<Deck> Decks { get; set; }
    public DbSet<Card> Сards { get; set; }


    public DeckData(DbContextOptions<DeckData> options)
        : base(options)
    {
      Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Entity<PositionCard>()
      //    .HasOne(p => p.Card)
      //    .WithOne(t => t.Id)
      //    .OnDelete(DeleteBehavior.Cascade);
    }
  }
}
