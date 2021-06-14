using DeckCards.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace DeckCards.Services.Extensions.DependencyInjection
{
  public static class ServiceCollectionExtension
  {
    public static IServiceCollection AddDeckCardsServices(this IServiceCollection services)
      => services.AddTransient<IDeckCardsServices, DeckCardsServices>();
  }
}