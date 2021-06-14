using Microsoft.EntityFrameworkCore;

namespace TestWebApplication.Models
{
  public class ApplicationContext : DbContext
  {
    public DbSet<Deck> Decks { get; set; }
    public DbSet<Card> Сards { get; set; }


    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
      Database.EnsureCreated();
    }
  }
}
