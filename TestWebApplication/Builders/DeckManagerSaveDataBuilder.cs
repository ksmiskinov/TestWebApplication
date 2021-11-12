using DeckCards.Domain;
using DeckCards.Services.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApplication.Interfaces;
using TestWebApplication.Models;
using DeckKind = TestWebApplication.Models.DeckKind;

namespace TestWebApplication.Builders
{
  public class DeckManagerSaveDataBuilder : IDeckManagerSaveDataBuilder
  {

    private readonly IDeckCardsServices _deckCardsServices;
    private readonly ILogger<DeckManagerSaveDataBuilder> _logger;

    public DeckManagerSaveDataBuilder(ILogger<DeckManagerSaveDataBuilder> logger, IDeckCardsServices deckCardsServices)
    {
      _logger = logger;
      _deckCardsServices = deckCardsServices ?? throw new ArgumentNullException(nameof(deckCardsServices));
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

    async Task<Deck> IDeckManagerSaveDataBuilder.NewDeckSaveBuild(string name, DeckKind deckKind)
    {

      var decks = await _deckCardsServices.GetDecksAsync();

      if (!decks.Any(x => x.Name.ToLower() == name.ToLower()))
      {
        var positionCards = new List<PositionCard>();
        var position = 1;
        foreach (CardKind kind in Enum.GetValues(typeof(CardKind)))
        {
          foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
          {
            if ((deckKind == DeckKind.Fool || deckKind == DeckKind.Preference || deckKind == DeckKind.Thousand) &&
                (rank == CardRank.Two ||
                 rank == CardRank.Three ||
                 rank == CardRank.Four ||
                 rank == CardRank.Five))
              continue;

            if ((deckKind == DeckKind.Preference || deckKind == DeckKind.Thousand) &&
                rank == CardRank.Six)
              continue;

            if (deckKind == DeckKind.Thousand &&
                rank == CardRank.Eight)
              continue;

            positionCards.Add(PositionCard.New(kind, rank, position++));
          }
        }
        return Deck.New(name, positionCards);
      }

      _logger.LogInformation("NewDeckSaveBuild: Колода с таким именем уже существует. ");
      return default;
    }
  }
}
