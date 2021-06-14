using DeckCards.Domain.Interfaces;
using DeckCards.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DeckCards.Services.Extensions.DependencyInjection
{
  public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddDeckCardsRepositories(this IServiceCollection services)
       => services
         .AddTransient<IDeckCardsRepository, DeckCardsRepository>();
  }
}