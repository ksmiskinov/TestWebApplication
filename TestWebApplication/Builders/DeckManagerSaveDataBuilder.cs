using DeckCards.Domain;
using DeckCards.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TestWebApplication.Interfaces;
using TestWebApplication.Models;

namespace TestWebApplication.Builders
{
  public class DeckManagerSaveDataBuilder : IDeckManagerSaveDataBuilder
  {

    private readonly IDeckCardsServices _deckCardsServices;
    private readonly ILogger<DeckManagerSaveDataBuilder> _logger;

    public DeckManagerSaveDataBuilder(ILogger<DeckManagerSaveDataBuilder> logger, IDeckCardsServices deckCardsServices)
    {
      _logger = logger;
      _deckCardsServices = deckCardsServices ?? throw new ArgumentNullException(nameof(IDeckCardsServices));
    }

    async Task<Deck> IDeckManagerSaveDataBuilder.ShuffleDeckSaveBuild(Guid deckId)
    {
      var deck = await _deckCardsServices.GetDeckAsync(deckId);

      if (deck == null)
      {
        _logger.LogInformation("GetDeck: Объект не найден");
        return default;
      }
      deck.ShuffleDeck(new ShuffleRandom());

      return deck;
    }
  }
}
