using Microsoft.Extensions.DependencyInjection;
using TestWebApplication.Builders;
using TestWebApplication.Interfaces;

namespace TestWebApplication.ServiceCollectionExtensions
{
  public static class ServiceCollectionExtension
  {
    /// <summary>
    /// Добавить DataBuilders
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddDataBuilders(this IServiceCollection services)
      => services.AddTransient<IDeckManagerViewDataBuilder, DeckManagerViewDataBuilder>();
  }
}
